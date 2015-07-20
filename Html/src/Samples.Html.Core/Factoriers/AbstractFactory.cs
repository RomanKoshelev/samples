// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// AbstractFactory.cs

using Samples.Html.Core.Tools.Builders;
using Samples.Html.Core.Tools.Comparators;
using Samples.Html.Core.Tools.Writers;
using Samples.Html.Core.Types;

namespace Samples.Html.Core.Factoriers
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