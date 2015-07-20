// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// IModelBuilder.cs

namespace Samples.Html.Types
{
    public interface IModelBuilder
    {
        IModelElement BuildModel( IParser parser, string source );
    }
}