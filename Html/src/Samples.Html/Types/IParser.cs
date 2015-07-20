// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// IParser.cs

namespace Samples.Html.Types
{
    public interface IParser
    {
        IParserNode GetRoot();
        void Parse( string source );
    }
}