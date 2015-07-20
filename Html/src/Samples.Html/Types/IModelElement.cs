// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// IModelElement.cs

using System.Collections.Generic;

namespace Samples.Html.Types
{
    public interface IModelElement
    {
        string Tag { get; }
        bool IsTagged();
        bool HasClosingTag();
        string Text { get; set; }
        bool HasText();
        IList< IModelElement > Elements { get; }
        IDictionary< string, string > Attributes { get; }
        IDictionary< string, string > Styles { get; }
        IModelElement TextElement { get; }
        IList< IModelElement > this[ string tag ] { get; }
    }
}