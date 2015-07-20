// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// HapFactory.cs

using Samples.Html.Core.Tools.Parsers.Concrete.HtmlAgilityPack;
using Samples.Html.Core.Types;

namespace Samples.Html.Core.Factoriers
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