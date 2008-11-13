using System;
using ApprovalTests.Exceptions;
using Machine.Specifications;

namespace ApprovalTests.Tests
{
	[Subject(typeof(Approvals))]
	public class when_approval_fails
	{
		It should_get_correct_label =()=> {
			exception = Catch.Exception(()=> Approvals.Approve("Should not approve"));
			((ApprovalMissingException) exception).Approved.ShouldEndWith("when_approval_fails.approved.txt");
		};

		static Exception exception;
	}
}