using System.Diagnostics;
using System.IO;

namespace ApprovalUtilities.Utilities
{
    public class PathUtilities
    {
        public static string GetDirectoryForCaller()
        {
            return GetDirectoryForCaller(1);
        }

        public static string GetDirectoryForCaller(int callerStackDepth)
        {
        	var stackFrame = new StackTrace(true).GetFrame(callerStackDepth + 1);
        	return GetDirectoryForStackFrame(stackFrame);
        }

    	public static string GetDirectoryForStackFrame(StackFrame stackFrame)
    	{
    		return new FileInfo(stackFrame.GetFileName()).Directory.FullName + "\\";
    	}
    }
}