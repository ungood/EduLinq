using System;
using System.Collections.Generic;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0) { throw new ArgumentOutOfRangeException("count"); } 
            // Convert everything to long to avoid overflows. There are other ways of checking 
            // for overflow, but this way make the code correct in the most obvious way. 
            if ((long)start + (long)count - 1L > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            return RangeImpl(start, count);
        }

        private static IEnumerable<int> RangeImpl(int start, int count)
        {
            for(int i = 0; i < count; i++)
                yield return start + i;
        }
    }
}
