// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// ParserNode.cs

using System.Collections.Generic;
using Samples.Html.Types;

namespace Samples.Html.Tools.Parsers.Abstract
{
    internal abstract class ParserNode : IParserNode
    {
        #region IParserElement

        IEnumerable< IParserNode > IParserNode.Elements
        {
            get { return doGetElements(); }
        }

        public IDictionary< string, string > Attributes
        {
            get { return doGetAttributes(); }
        }

        ParserNodeType IParserNode.Type
        {
            get { return doGetType(); }
        }

        string IParserNode.Tag
        {
            get { return doGetTag(); }
        }

        string IParserNode.Text
        {
            get { return doGetText(); }
        }

        #endregion


        #region Overrides

        protected abstract ParserNodeType doGetType();
        protected abstract string doGetTag();
        protected abstract string doGetText();
        protected abstract IEnumerable< IParserNode > doGetElements();
        protected abstract IDictionary< string, string > doGetAttributes();

        #endregion
    }
}