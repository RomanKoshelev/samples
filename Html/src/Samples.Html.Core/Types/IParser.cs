// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// IParser.cs

namespace Samples.Html.Core.Types
{
    public interface IParser
    {
        IParserNode GetRoot();
        void Parse( string source );
    }
}