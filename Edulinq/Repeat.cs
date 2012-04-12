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
            return RepeatImpl(element, count);

        }

        public static IEnumerable<TResult> RepeatImpl<TResult>(TResult element, int count)
        {
           for(var index = 0; index < count; index++)
           {
               yield return element;
           }
        }
    }
}
