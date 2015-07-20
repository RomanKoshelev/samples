// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// Text.cs

using Samples.Html.Common;
using Samples.Html.Types;

namespace Samples.Html.Elements
{
    public class Text : AbstractlElement, ITextualElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.HasNoTag;
        }
    }
}