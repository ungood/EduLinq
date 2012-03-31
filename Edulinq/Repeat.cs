using System;
using System.Collections.Generic;
using System.Text;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if (count < 0) { throw new ArgumentOutOfRangeException("count"); } 

            throw new NotImplementedException();
        }
    }
}
