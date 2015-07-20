// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// HapParserNode.cs

using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Samples.Html.Core.Tools.Parsers.Abstract;
using Samples.Html.Core.Types;
using Samples.Html.Core.Utils;

namespace Samples.Html.Core.Tools.Parsers.Concrete.HtmlAgilityPack
{
    internal class HapParserNode : ParserNode
    {
        #region Ctor

        public HapParserNode( HtmlNode node )
        {
            _node = node;
        }

        #endregion


        #region Fields

        private readonly HtmlNode _node;

        #endregion


        #region Overrides

        protected override string doGetText()
        {
            return _node.InnerText;
        }

        protected override string doGetTag()
        {
            return _node.OriginalName;
        }

        protected override ParserNodeType doGetType()
        {
            switch( _node.NodeType ) {
                case HtmlNodeType.Document :
                    return ParserNodeType.Document;
                case HtmlNodeType.Element :
                    return ParserNodeType.Element;
                case HtmlNodeType.Text :
                    return ParserNodeType.Text;
                case HtmlNodeType.Comment :
                    return ParserNodeType.Comment;
            }
            throw new SampleHtmlException( "Unexpected NodeType: [{0}]", _node.NodeType );
        }

        protected override IEnumerable< IParserNode > doGetElements()
        {
            return _node.ChildNodes.Where( NodeIsValid ).Select( n => new HapParserNode( n ) );
        }

        private static bool NodeIsValid( HtmlNode node )
        {
            if( node.NodeType == HtmlNodeType.Text ) {
                if( string.IsNullOrEmpty( node.InnerText.Trim() ) ) {
                    return false;
                }
            }
            return true;
        }

        protected override IDictionary< string, string > doGetAttributes()
        {
            return _node.Attributes.ToDictionary( a => a.Name, a => a.Value );
        }

        #endregion
    }
}