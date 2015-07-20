// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// Page.cs

using Samples.Html.Core.Common;

namespace Samples.Html.Core.Elements
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