using System;
using System.Collections;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        //static private readonly Dictionary<Type, Object> cache = new Dictionary<Type, object>();  

        public static IEnumerable<TResult> Empty<TResult>()
        {
            return EmptyCache<TResult>.Instance;
        }

        private class EmptyCache<TResult>
        {
            public static readonly IEnumerable<TResult> Instance = new TResult[0];
        }
    }
}
