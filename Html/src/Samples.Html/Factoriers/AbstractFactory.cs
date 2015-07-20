// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// AbstractFactory.cs

using Samples.Html.Tools.Builders;
using Samples.Html.Tools.Comparators;
using Samples.Html.Tools.Writers;
using Samples.Html.Types;

namespace Samples.Html.Factoriers
{
    public abstract class AbstractFactory : IFactory
    {
        #region IHtmlToolsFactory

        public abstract IParser MakeHtmlParser();

        ITextComparator IFactory.MakeTextComparator()
        {
            return new SimpleTextComparator();
        }

        IModelWriter IFactory.MakeOutlineWriter()
        {
            return new OutlineWriter();
        }

        public IModelWriter MakeStructWriter()
        {
            return new StructWriter();
        }

        IModelBuilder IFactory.MakeModelBuilder()
        {
            return new ModelBuilder();
        }

        IModelWriter IFactory.MakeHtmlWriter()
        {
            return new HtmlWriter();
        }

        #endregion
    }
}