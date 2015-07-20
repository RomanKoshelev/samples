// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// Table.cs

using Samples.Html.Common;

namespace Samples.Html.Elements
{
    public class Table : AbstractlElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.Table;
        }
    }
}