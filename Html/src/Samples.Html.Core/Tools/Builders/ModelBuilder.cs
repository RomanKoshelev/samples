// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// ModelBuilder.cs

using System.Collections.Generic;
using MoreLinq;
using Samples.Html.Core.Common;
using Samples.Html.Core.Elements;
using Samples.Html.Core.Types;
using Samples.Html.Core.Utils;

namespace Samples.Html.Core.Tools.Builders
{
    public partial class ModelBuilder : IModelBuilder
    {
        #region IHtmlModelBuilder

        IModelElement IModelBuilder.BuildModel( IParser parser, string source )
        {
            parser.Parse( source );

            var contentRoot = CreateElementWithDescendants( parser.GetRoot() );

            return contentRoot;
        }

        #endregion


        #region Utils

        private static IModelElement CreateElementWithDescendants( IParserNode sourceNode )
        {
            var element = CreateElement( sourceNode );

            CreateElements( element, sourceNode.Elements );
            CreateAttributes( element, sourceNode.Attributes );
            CreateStyles( element );

            return element;
        }

        private static void CreateStyles( IModelElement element )
        {
            if( !element.Attributes.ContainsKey( Constants.Attributes.Style ) ) {
                return;
            }
            StyleAttributeParser
                .Parse( element.Attributes[ Constants.Attributes.Style ] )
                .ForEach( pair =>
                    element.Styles.Add(
                        pair.Key.ToLower(),
                        pair.Value.Trim()
                        )
                );
        }

        private static void CreateAttributes( IModelElement modelElement, IDictionary< string, string > sourceAttributes )
        {
            sourceAttributes.ForEach( pair =>
                modelElement.Attributes.Add(
                    pair.Key.ToLower(),
                    pair.Value.Trim()
                    )
                );
        }

        private static void CreateElements( IModelElement modelElement, IEnumerable< IParserNode > sourceElements )
        {
            sourceElements.ForEach( n => modelElement.Elements.Add( CreateElementWithDescendants( n ) ) );
        }

        private static IModelElement CreateTextElement( IParserNode sourceNode )
        {
            IModelElement text = new Text();
            text.Text = sourceNode.Text;
            return text;
        }

        #endregion
    }
}