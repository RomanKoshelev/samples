// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// ModelBuilder.pvt.Elements.cs

using Samples.Html.Core.Common;
using Samples.Html.Core.Elements;
using Samples.Html.Core.Types;
using Samples.Html.Core.Utils;

namespace Samples.Html.Core.Tools.Builders
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
            throw new SampleHtmlException( "Unexpected ParserNodeType: [{0}]", sourceNode.Type );
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
            throw new SampleHtmlException( "Unexpected Tag: <{0}>", sourceNode.Tag );
        }

        #endregion
    }
}