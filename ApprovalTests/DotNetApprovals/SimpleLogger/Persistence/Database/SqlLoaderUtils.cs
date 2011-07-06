using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ApprovalUtilities.SimpleLogger;

namespace ApprovalUtilities.Persistence.Database
{
	public class SqlLoaderUtils
	{
		public static string ExecuteQueryToDisplayString(string query, string connectionString,
		                                                 Func<SqlCommand> commandCreator)
		{
			if (String.IsNullOrEmpty(query))
			{
				return String.Empty;
			}

			try
			{
				string[] dataset = null;
				var headers = new StringBuilder();
				if (connectionString != null)
				{
					dataset = DatabaseUtils.Query(query, connectionString, r => ConvertRowToString(r, headers)).ToArray();
				}
				else if (commandCreator != null)
				{
					dataset = DatabaseUtils.Query(query, commandCreator, r => ConvertRowToString(r, headers)).ToArray();
				}
				return headers + "\r\n" + String.Join("\r\n", dataset);
			}
			catch (Exception ex)
			{
				return LoggerInstance.FormatExeption(ex);
			}
		}

		public static string ConvertRowToString(SqlDataReader row, StringBuilder headers)
		{
			var output = new List<string>();
			for (var i = 0; i < row.FieldCount; i++)
			{
				output.Add("" + row.GetValue(i));
			}
			if (headers.Length == 0)
			{
				for (var i = 0; i < row.FieldCount; i++)
				{
					headers.Append(row.GetName(i) + ", ");
				}
			}
			return String.Join(", ", output.ToArray());
		}
	}
}