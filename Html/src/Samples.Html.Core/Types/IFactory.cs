// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// IFactory.cs

namespace Samples.Html.Core.Types
{
    public interface IFactory
    {
        IParser MakeHtmlParser();
        IModelBuilder MakeModelBuilder();
        ITextComparator MakeTextComparator();
        IModelWriter MakeHtmlWriter();
        IModelWriter MakeOutlineWriter();
        IModelWriter MakeStructWriter();
    }
}