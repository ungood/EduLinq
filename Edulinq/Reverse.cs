using System;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source)
        {
            if(source == null)
                throw new NullReferenceException("source");

            return ReverseImpl(source);
        }

        private static IEnumerable<T> ReverseImpl<T>(this IEnumerable<T> source)
        {
            throw new NotImplementedException();
        }
    }
}
