// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// SimpleTextComparator.cs

using Samples.Html.Core.Types;

namespace Samples.Html.Core.Tools.Comparators
{
    public class SimpleTextComparator : ITextComparator
    {
        #region IHtmlComparator

        bool ITextComparator.AreEqual( string s1, string s2 )
        {
            return Prepare( s1 ) == Prepare( s2 );
        }

        #endregion


        #region Utils

        private static string Prepare( string str )
        {
            return str
                .Replace( " ", "" )
                .Replace( "\r", "" )
                .Replace( "\n", "" )
                .Replace( "\t", "" )
                .Replace( "<html>", "" )
                .Replace( "</html>", "" )
                .ToLower()
                ;
        }

        #endregion
    }
}