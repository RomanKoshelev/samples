// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// IModelWriter.cs

namespace Samples.Html.Types
{
    public interface IModelWriter
    {
        string Write( IModelElement rootElement );
    }
}