// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// StyleAttributeParser.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Html.Utils
{
    internal static class StyleAttributeParser
    {
        public static IDictionary< string, string > Parse( string styles )
        {
            return styles
                .Split(
                    new[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries )
                .Select( x =>
                    x.Split(
                        new[] { ':' },
                        StringSplitOptions.RemoveEmptyEntries )
                )
                .ToDictionary( p => p[ 0 ].Trim(), p => p[ 1 ].Trim() );
        }
    }
}