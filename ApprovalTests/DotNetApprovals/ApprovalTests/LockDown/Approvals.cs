using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalTests.LockDown
{
    public class Approvals
    {
        private static object[] EMPTY = {null};
        public static void LockDown<A>(
            IList<A> aList,
            Func<A, object> processCall)
        {
            LockDown("[{0}]", aList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a));
        }
        public static void LockDown<A, B>(
            IList<A> aList,
            IList<B> bList,
            Func<A, B, object> processCall)
        {
            LockDown("[{0},{1}]", aList, bList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a, b));
        }
        public static void LockDown<A, B, C>(
           IList<A> aList,
           IList<B> bList,
           IList<C> cList,
            Func<A, B, C, object> processCall)
        {
            LockDown("[{0},{1},{2}]", aList, bList, cList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a, b, c));
        }
        public static void LockDown<A, B, C, D>(
           IList<A> aList,
           IList<B> bList,
           IList<C> cList,
           IList<D> dList,
           Func<A, B, C, D, object> processCall)
        {
            LockDown("[{0},{1},{2},{3}]", aList, bList, cList, dList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d));
        }
        public static void LockDown<A, B, C, D, E>(
           IList<A> aList,
           IList<B> bList,
           IList<C> cList,
           IList<D> dList,
           IList<E> eList,
           Func<A, B, C, D, E, object> processCall)
        {
            LockDown("[{0},{1},{2},{3},{4}]", aList, bList, cList, dList, eList, EMPTY, EMPTY, EMPTY, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d,e));
        }
        public static void LockDown<A, B, C, D, E, F>(
           IList<A> aList,
           IList<B> bList,
           IList<C> cList,
           IList<D> dList,
           IList<E> eList,
           IList<F> fList,
           Func<A, B, C, D, E, F, object> processCall)
        {
            LockDown("[{0},{1},{2},{3},{4},{5}]",aList, bList, cList, dList, eList, fList, EMPTY, EMPTY, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f));
        }
        
        public static void LockDown<A, B, C, D, E, F, G>(
            IList<A> aList,
            IList<B> bList,
            IList<C> cList,
            IList<D> dList,
            IList<E> eList,
            IList<F> fList,
            IList<G> gList,
            
            Func<A, B, C, D, E, F, G,  object> processCall)
        {
            LockDown("[{0},{1},{2},{3},{4},{5},{6}]",aList, bList, cList, dList, eList, fList, gList, EMPTY, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f, g));
        }
        public static void LockDown<A, B, C, D, E, F, G, H>(
            IList<A> aList,
            IList<B> bList,
            IList<C> cList,
            IList<D> dList,
            IList<E> eList,
            IList<F> fList,
            IList<G> gList,
            IList<H> hList,
            Func<A, B, C, D, E, F, G, H, object> processCall)
        {
            LockDown("[{0},{1},{2},{3},{4},{5},{6},{7}]",
                aList, bList, cList, dList, eList, fList, gList, hList, EMPTY,
                     (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f, g, h));
        }

        public static void LockDown<A, B, C, D, E, F, G, H, I>(
            IList<A> aList,
            IList<B> bList,
            IList<C> cList,
            IList<D> dList,
            IList<E> eList,
            IList<F> fList,
            IList<G> gList,
            IList<H> hList,
            IList<I> iList,
            Func<A, B, C, D, E, F, G, H, I, object> processCall)
        {
            LockDown("[{0},{1},{2},{3},{4},{5},{6},{7},{8}]",
               aList, bList, cList, dList, eList, fList, gList, hList, iList,
                    (a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f, g, h,i));
     
        }

        private static void LockDown<A, B, C, D, E, F, G, H, I>(
            String format,
            IList<A> aList,
            IList<B> bList,
            IList<C> cList,
            IList<D> dList,
            IList<E> eList,
            IList<F> fList,
            IList<G> gList,
            IList<H> hList,
            IList<I> iList,
            Func<A, B, C, D, E, F, G, H, I, object> processCall)

        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in aList)
            {
                foreach (var b in bList)
                {
                    foreach (var c in cList)
                    {
                        foreach (var d in dList)
                        {
                            foreach (var e in eList)
                            {
                                foreach (var f in fList)
                                {
                                    foreach (var g in gList)
                                    {
                                        foreach (var h in hList)
                                        {
                                            foreach (var i in iList)
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

                                                var input = String.Format(format, a, b,
                                                                          c, d, e, f, g, h, i);
                                                sb.Append(String.Format("{0} => {1}\r\n",input, result));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ApprovalTests.Approvals.Approve(sb);
        }
    }
}