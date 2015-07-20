// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// HapFactory.cs

using Samples.Html.Tools.Parsers.Concrete.HtmlAgilityPack;
using Samples.Html.Types;

namespace Samples.Html.Factoriers
{
    public class HapFactory : AbstractFactory
    {
        #region Overrides

        public override IParser MakeHtmlParser()
        {
            return new HapParser();
        }

        #endregion
    }
}