// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// AsposeHtmlException.cs

using System;

namespace Samples.Html.Utils
{
    public class AsposeHtmlException : Exception
    {
        public AsposeHtmlException( string format, params object[] args )
            : base( string.Format( format, args ) ) {}
    }
}