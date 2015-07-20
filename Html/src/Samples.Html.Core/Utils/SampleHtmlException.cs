// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// SampleHtmlException.cs

using System;

namespace Samples.Html.Core.Utils
{
    public class SampleHtmlException : Exception
    {
        public SampleHtmlException( string format, params object[] args )
            : base( string.Format( format, args ) ) {}
    }
}