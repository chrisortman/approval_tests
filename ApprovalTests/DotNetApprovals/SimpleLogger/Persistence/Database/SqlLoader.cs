using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ApprovalUtilities.SimpleLogger;

namespace ApprovalUtilities.Persistence.Database
{
	public abstract class SqlLoader<T> : ILoader<T>, IExecutableQuery
	{
		public readonly Func<SqlCommand> CommandCreator;
		public readonly string ConnectionString;

		protected SqlLoader(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		protected SqlLoader(Func<SqlCommand> commandCreator)
		{
			this.CommandCreator = commandCreator;
		}

		public abstract T Load();

		public abstract string GetQuery();

		public string ExecuteQuery(string query)
		{
			if (string.IsNullOrEmpty(query))
			{
				return string.Empty;
			}

			try
			{
				string[] dataset = null;
				if (ConnectionString != null)
				{
					dataset = DatabaseUtils.Query(query, ConnectionString, ConvertRowToString).ToArray();
				}
				else if (CommandCreator != null)
				{
					dataset = DatabaseUtils.Query(query, CommandCreator, ConvertRowToString).ToArray();
				}
				return string.Join("\r\n", dataset);
			}
			catch (Exception ex)
			{
				return LoggerInstance.FormatExeption(ex);
			}
		}

		private static string ConvertRowToString(SqlDataReader row)
		{
			var output = new List<string>();
			for (var i = 0; i < row.FieldCount; i++)
			{
				output.Add("" + row.GetValue(i));
			}
			return string.Join(", ", output.ToArray());
		}
	}
}