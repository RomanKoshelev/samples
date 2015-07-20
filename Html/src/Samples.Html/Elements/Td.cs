// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// Td.cs

using Samples.Html.Common;

namespace Samples.Html.Elements
{
    public class Td : AbstractlElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.Td;
        }
    }
}