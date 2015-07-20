// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// AbstractlElement.cs

using System.Collections.Generic;
using System.Linq;
using Samples.Html.Core.Types;

namespace Samples.Html.Core.Elements
{
    public abstract class AbstractlElement : IModelElement
    {
        #region IHtmlModelElement

        public IModelElement IModelElement
        {
            get { return this; }
        }

        IList< IModelElement > IModelElement.Elements
        {
            get { return _elements; }
        }

        string IModelElement.Tag
        {
            get { return doGetTag(); }
        }

        string IModelElement.Text { get; set; }

        IDictionary< string, string > IModelElement.Attributes
        {
            get { return _attributes; }
        }

        public IDictionary< string, string > Styles
        {
            get { return _styles; }
        }

        IModelElement IModelElement.TextElement
        {
            get { return _elements.OfType< ITextualElement >().First(); }
        }

        public IList< IModelElement > this[ string tag ]
        {
            get { return _elements.Where( e => e.Tag == tag ).ToList(); }
        }

        bool IModelElement.HasClosingTag()
        {
            return doHasClosingTag();
        }

        bool IModelElement.IsTagged()
        {
            return doGetTag() != null;
        }

        bool IModelElement.HasText()
        {
            return !string.IsNullOrEmpty( IModelElement.Text );
        }

        #endregion


        #region Overrides

        protected virtual bool doHasClosingTag()
        {
            return IModelElement.IsTagged();
        }

        protected abstract string doGetTag();

        #endregion


        #region Fields

        private readonly List< IModelElement > _elements = new List< IModelElement >();
        private readonly IDictionary< string, string > _attributes = new Dictionary< string, string >();
        private readonly IDictionary< string, string > _styles = new Dictionary< string, string >();

        #endregion
    }
}