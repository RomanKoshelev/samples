// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// IParserNode.cs

using System.Collections.Generic;

namespace Samples.Html.Core.Types
{
    public interface IParserNode
    {
        ParserNodeType Type { get; }
        string Tag { get; }
        string Text { get; }
        IEnumerable< IParserNode > Elements { get; }
        IDictionary< string, string > Attributes { get; }
    }
}