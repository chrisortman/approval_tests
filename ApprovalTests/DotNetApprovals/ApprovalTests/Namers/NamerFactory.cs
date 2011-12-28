using System;

namespace ApprovalTests.Namers
{
    public class NamerFactory
    {
        public static string AdditionalInformation { get; set; }

        public static void AsMachineSpecificTest()
        {
            AdditionalInformation = "ForMachine." + Environment.MachineName;
        }

        public static void Clear()
        {
            AdditionalInformation = null;
        }
    }
}