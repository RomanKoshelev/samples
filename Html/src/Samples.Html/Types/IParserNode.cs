// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// IParserNode.cs

using System.Collections.Generic;

namespace Samples.Html.Types
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