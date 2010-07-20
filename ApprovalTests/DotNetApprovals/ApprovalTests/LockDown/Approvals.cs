using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalTests;

namespace ApprovalTests.LockDown
{
    public class Approvals
    {
        public static void LockDown<A, B, C>(Func<A, B, C> processCall, IEnumerable<A> parameter1, IList<B> parameter2)
        {
            StringBuilder sb = new StringBuilder();

            var p1 = parameter1.ToList();
            var p2 = parameter2.ToList();

            IndexPermutations perms = new IndexPermutations(new int[] {p1.Count, p2.Count});

            foreach (var indexs in perms)
            {
                var parameters = new object[] {p1[indexs[0]], p2[indexs[1]]};
                C result = processCall.Invoke(p1[indexs[0]], p2[indexs[1]]);
                sb.Append(String.Format("{0} = {1} \r\n", parameters.ToReadableString(), result))
                    ;
            }

            ApprovalTests.Approvals.Approve(sb);
        }
    }
}