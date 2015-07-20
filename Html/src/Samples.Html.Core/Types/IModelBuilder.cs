// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// IModelBuilder.cs

namespace Samples.Html.Core.Types
{
    public interface IModelBuilder
    {
        IModelElement BuildModel( IParser parser, string source );
    }
}