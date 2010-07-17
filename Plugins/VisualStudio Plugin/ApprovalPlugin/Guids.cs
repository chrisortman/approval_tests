// Guids.cs
// MUST match guids.h
using System;

namespace ApprovalTest.ApprovalPlugin
{
    static class GuidList
    {
        public const string guidApprovalPluginPkgString = "22ee3851-8133-49d0-b22a-05c36acb5fe3";
        public const string guidApprovalPluginCmdSetString = "bfa2a2c4-6254-4bab-93e1-4018d3a2f0f0";

        public static readonly Guid guidApprovalPluginCmdSet = new Guid(guidApprovalPluginCmdSetString);
    };
}