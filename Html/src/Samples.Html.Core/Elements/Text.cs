// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// Text.cs

using Samples.Html.Core.Common;
using Samples.Html.Core.Types;

namespace Samples.Html.Core.Elements
{
    public class Text : AbstractlElement, ITextualElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.HasNoTag;
        }
    }
}