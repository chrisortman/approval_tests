using System;
using System.Collections;
using System.Collections.Generic;

namespace ApprovalTests.LockDown
{
    public class IndexPermutations : IEnumerable<int[]>, IEnumerator<int[]>
    {
        private int[] sizes;
        private int[] index;
        private bool finished = false;

        public IndexPermutations(int[] sizes)
        {
            this.sizes = sizes;
            this.index = new int[sizes.Length];
            for (int i = 0; i < sizes.Length; i++)
            {
                index[i] = 0;
            }
            index[0] = -1;
        }

        private void incermentIndex(int index)
        {
            this.index[index]++;
            if (this.index[index].Equals(sizes[index]))
            {
                if (index == sizes.Length - 1)
                {
                    finished = true;
                    return;
                }
                this.index[index] = 0;
                incermentIndex(index + 1);
            }
        }


        public IEnumerator<int[]> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            incermentIndex(0);
            Current = (int[]) index.Clone();
            return !finished;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current
        {
            get { return this; }
        }

        public int[] Current { get; private set; }
    }
}