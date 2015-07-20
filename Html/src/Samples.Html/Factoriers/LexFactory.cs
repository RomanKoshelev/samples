// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// LexFactory.cs

using Samples.Html.Tools.Parsers.Concrete.LexicalAnalyzer;
using Samples.Html.Types;

namespace Samples.Html.Factoriers
{
    public class LexFactory : AbstractFactory
    {
        #region Overrides

        public override IParser MakeHtmlParser()
        {
            return new LexParser();
        }

        #endregion
    }
}