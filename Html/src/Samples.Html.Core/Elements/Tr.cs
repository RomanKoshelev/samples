// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// Tr.cs

using Samples.Html.Core.Common;

namespace Samples.Html.Core.Elements
{
    public class Tr : AbstractlElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.Tr;
        }
    }
}