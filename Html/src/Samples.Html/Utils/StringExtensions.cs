// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// StringExtensions.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Html.Utils
{
    public static class StringExtensions
    {
        public static string FoldToStringBy<T>(
            this IEnumerable< T > enumerable,
            Func< T, string > selector,
            string delimiter = ", ",
            string emptyResult = "" )
        {
            var list = enumerable as IList< T > ?? enumerable.ToList();
            if( !list.Any() ) {
                return emptyResult;
            }
            return list.Select( selector ).Aggregate( ( a, s ) => string.Format( "{0}{1}{2}", a, delimiter, s ) );
        }
    }
}