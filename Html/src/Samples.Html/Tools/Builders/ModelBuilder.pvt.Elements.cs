// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// ModelBuilder.pvt.Elements.cs

using Samples.Html.Common;
using Samples.Html.Elements;
using Samples.Html.Types;
using Samples.Html.Utils;

namespace Samples.Html.Tools.Builders
{
    public partial class ModelBuilder
    {
        #region Elements utils

        private static IModelElement CreateElement( IParserNode sourceNode )
        {
            switch( sourceNode.Type ) {
                case ParserNodeType.Document :
                    return new Page();
                case ParserNodeType.Element :
                    return CreateTaggedElement( sourceNode );
                case ParserNodeType.Text :
                    return CreateTextElement( sourceNode );
            }
            throw new AsposeHtmlException( "Unexpected ParserNodeType: [{0}]", sourceNode.Type );
        }

        private static IModelElement CreateTaggedElement( IParserNode sourceNode )
        {
            switch( sourceNode.Tag.ToLower() ) {
                case Constants.Tags.Table :
                    return new Table();
                case Constants.Tags.Tr :
                    return new Tr();
                case Constants.Tags.Td :
                    return new Td();
            }
            throw new AsposeHtmlException( "Unexpected Tag: <{0}>", sourceNode.Tag );
        }

        #endregion
    }
}