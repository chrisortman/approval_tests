using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalTests.LockDown
{
    public class Approvals
    {
        private static readonly object[] EMPTY = {null};

        public static void ApproveAllCombinations<A>(
            IEnumerable<A> aList,
            Func<A, object> processCall)
        {
            ApproveAllCombinations("[{0}]", aList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a));
        }

        public static void ApproveAllCombinations<A, B>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            Func<A, B, object> processCall)
        {
            ApproveAllCombinations("[{0},{1}]", aList, bList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a, b));
        }

        public static void ApproveAllCombinations<A, B, C>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            Func<A, B, C, object> processCall)
        {
            ApproveAllCombinations("[{0},{1},{2}]", aList, bList, cList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a, b, c));
        }

        public static void ApproveAllCombinations<A, B, C, D>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            Func<A, B, C, D, object> processCall)
        {
            ApproveAllCombinations("[{0},{1},{2},{3}]", aList, bList, cList, dList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d));
        }

        public static void ApproveAllCombinations<A, B, C, D, E>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            IEnumerable<E> eList,
            Func<A, B, C, D, E, object> processCall)
        {
            ApproveAllCombinations("[{0},{1},{2},{3},{4}]", aList, bList, cList, dList, eList, EMPTY, EMPTY, EMPTY,
                                   EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e));
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            IEnumerable<E> eList,
            IEnumerable<F> fList,
            Func<A, B, C, D, E, F, object> processCall)
        {
            ApproveAllCombinations("[{0},{1},{2},{3},{4},{5}]", aList, bList, cList, dList, eList, fList, EMPTY, EMPTY,
                                   EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f));
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F, G>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            IEnumerable<E> eList,
            IEnumerable<F> fList,
            IEnumerable<G> gList,
            Func<A, B, C, D, E, F, G, object> processCall)
        {
            ApproveAllCombinations("[{0},{1},{2},{3},{4},{5},{6}]", aList, bList, cList, dList, eList, fList, gList,
                                   EMPTY, EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f, g));
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F, G, H>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            IEnumerable<E> eList,
            IEnumerable<F> fList,
            IEnumerable<G> gList,
            IEnumerable<H> hList,
            Func<A, B, C, D, E, F, G, H, object> processCall)
        {
            ApproveAllCombinations("[{0},{1},{2},{3},{4},{5},{6},{7}]",
                                   aList, bList, cList, dList, eList, fList, gList, hList, EMPTY,
                                   (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f, g, h));
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F, G, H, I>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            IEnumerable<E> eList,
            IEnumerable<F> fList,
            IEnumerable<G> gList,
            IEnumerable<H> hList,
            IEnumerable<I> iList,
            Func<A, B, C, D, E, F, G, H, I, object> processCall)
        {
            ApproveAllCombinations("[{0},{1},{2},{3},{4},{5},{6},{7},{8}]",
                                   aList, bList, cList, dList, eList, fList, gList, hList, iList,
                                   processCall);
        }

        private static void ApproveAllCombinations<A, B, C, D, E, F, G, H, I>(
            String format,
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            IEnumerable<E> eList,
            IEnumerable<F> fList,
            IEnumerable<G> gList,
            IEnumerable<H> hList,
            IEnumerable<I> iList,
            Func<A, B, C, D, E, F, G, H, I, object> processCall)

        {
            var sb = new StringBuilder();
            AllCombinations(aList, bList, cList, dList, eList, fList, gList, hList, iList,
                            (a, b, c, d, e, f, g, h, i) =>
                                {
                                    object result;
                                    try
                                    {
                                        result = processCall(a, b, c, d, e, f, g, h, i);
                                    }
                                    catch (Exception ex)
                                    {
                                        result = ex.Message;
                                    }
                                    var input = String.Format(format, a, b, c, d, e, f, g, h, i);
                                    sb.Append(String.Format("{0} => {1}\r\n", input, result));
                                });

            ApprovalTests.Approvals.Approve(sb);
        }

        
        private static void AllCombinations<A, B, C, D, E, F, G, H, I>(
            IEnumerable<A> aList,
            IEnumerable<B> bList,
            IEnumerable<C> cList,
            IEnumerable<D> dList,
            IEnumerable<E> eList,
            IEnumerable<F> fList,
            IEnumerable<G> gList,
            IEnumerable<H> hList,
            IEnumerable<I> iList,
            Action<A, B, C, D, E, F, G, H, I> processCall)
        {
            foreach (var a in aList)
                foreach (var b in bList)
                    foreach (var c in cList)
                        foreach (var d in dList)
                            foreach (var e in eList)
                                foreach (var f in fList)
                                    foreach (var g in gList)
                                        foreach (var h in hList)
                                            foreach (var i in iList)
                                            {
                                                processCall(a, b, c, d, e, f, g, h, i);
                                            }
        }
    }
}