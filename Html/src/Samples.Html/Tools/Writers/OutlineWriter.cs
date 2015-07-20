// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// OutlineWriter.cs

using System.Linq;
using System.Text;
using MoreLinq;
using Samples.Html.Common;
using Samples.Html.Types;
using Samples.Html.Utils;

namespace Samples.Html.Tools.Writers
{
    public class OutlineWriter : BaseWriter, IModelWriter
    {
        #region IContentWriter

        string IModelWriter.Write( IModelElement rootElement )
        {
            return WriteElement( rootElement, 0 ) + "\n";
        }

        #endregion


        #region Utils

        private string WriteElement( IModelElement modelElement, int level )
        {
            var sb = new StringBuilder();

            WriteName( modelElement, sb, level );
            WriteAttributes( modelElement, sb, level );
            WriteStyles( modelElement, sb, level );
            WriteText( modelElement, sb );
            WriteChildren( modelElement, sb, level );

            return sb.ToString();
        }

        private static void WriteStyles( IModelElement node, StringBuilder sb, int level )
        {
            if( !node.Styles.Any() ) {
                return;
            }
            sb.AppendFormat( "\n{0}Styles{{", Indent( level + 1 ) );
            sb.Append(
                node.Styles
                    .FoldToStringBy(
                        pair => string.Format( "\n{0}{1}: \"{2}\"",
                            Indent( level + 2 ),
                            pair.Key,
                            pair.Value ),
                        "" )
                );
            sb.Append( "}" );
        }

        private static void WriteAttributes( IModelElement node, StringBuilder sb, int level )
        {
            var attributes = node.Attributes.Where( a => a.Key != Constants.Attributes.Style ).ToList();
            if( !attributes.Any() ) {
                return;
            }
            sb.AppendFormat( "\n{0}Attributres[", Indent( level + 1 ) );
            sb.Append(
                attributes.FoldToStringBy(
                    pair => string.Format( "\n{0}{1} = \"{2}\"",
                        Indent( level + 2 ),
                        pair.Key,
                        pair.Value ),
                    "" )
                );
            sb.Append( "]" );
        }

        private static void WriteName( IModelElement node, StringBuilder sb, int level )
        {
            sb.Append( "\n" );
            sb.Append( Indent( level ) );
            sb.AppendFormat( node.GetType().Name );
        }

        private static void WriteText( IModelElement node, StringBuilder sb )
        {
            if( !node.HasText() || node.Text.Trim() == "" ) {
                return;
            }
            sb.AppendFormat( ": \"{0}\"", node.Text );
        }

        private void WriteChildren( IModelElement node, StringBuilder sb, int level )
        {
            node.Elements.ForEach( e => { sb.Append( WriteElement( e, level + 1 ) ); } );
        }

        #endregion
    }
}