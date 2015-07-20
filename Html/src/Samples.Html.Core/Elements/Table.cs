// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// Table.cs

using Samples.Html.Core.Common;

namespace Samples.Html.Core.Elements
{
    public class Table : AbstractlElement
    {
        protected override string doGetTag()
        {
            return Constants.Tags.Table;
        }
    }
}