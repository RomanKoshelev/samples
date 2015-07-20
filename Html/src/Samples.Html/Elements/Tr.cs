// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// Tr.cs

using Samples.Html.Common;

namespace Samples.Html.Elements
{
    public class Tr : AbstractlElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.Tr;
        }
    }
}