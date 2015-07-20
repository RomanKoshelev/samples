// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// Page.cs

using Samples.Html.Common;

namespace Samples.Html.Elements
{
    public class Page : AbstractlElement
    {
        #region Overrides

        protected override string doGetTag()
        {
            return Constants.Tags.Html;
        }

        #endregion
    }
}