using System.Collections.Generic;
using System.Linq;

namespace Billing
{
    public class EqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            for (int i = 1; i <= Common.MaxBooks; ++i)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            return obj.Sum(x => x.GetHashCode());
        }
    }
}
