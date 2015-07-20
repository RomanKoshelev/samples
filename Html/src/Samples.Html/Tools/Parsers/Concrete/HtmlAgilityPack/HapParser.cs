// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// HapParser.cs

using HtmlAgilityPack;
using Samples.Html.Types;

namespace Samples.Html.Tools.Parsers.Concrete.HtmlAgilityPack
{
    // ========================================================================== []
    //
    // Html Agility Pack parses the Html and gives us access to the built nodes 
    // via HtmlDocument object
    // See https://htmlagilitypack.codeplex.com/
    //
    // ========================================================================== []
    public class HapParser : IParser
    {
        #region IHtmlParser

        IParserNode IParser.GetRoot()
        {
            return new HapParserNode( _html.DocumentNode );
        }

        void IParser.Parse( string source )
        {
            _html.LoadHtml( source );
        }

        #endregion


        #region Fields

        private readonly HtmlDocument _html = new HtmlDocument();

        #endregion
    }
}