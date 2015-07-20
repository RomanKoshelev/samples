// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// Td.cs

using Samples.Html.Core.Common;

namespace Samples.Html.Core.Elements
{
    public class Td : AbstractlElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.Td;
        }
    }
}