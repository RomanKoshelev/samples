// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// LexFactory.cs

using Samples.Html.Core.Tools.Parsers.Concrete.LexicalAnalyzer;
using Samples.Html.Core.Types;

namespace Samples.Html.Core.Factories
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