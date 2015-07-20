// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// SimpleTextComparator.cs

using Samples.Html.Types;

namespace Samples.Html.Tools.Comparators
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