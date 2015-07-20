// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// IModelWriter.cs

namespace Samples.Html.Core.Types
{
    public interface IModelWriter
    {
        string Write( IModelElement rootElement );
    }
}