// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// HtmlWriter.cs

using System.Text;
using MoreLinq;
using Samples.Html.Core.Types;

namespace Samples.Html.Core.Tools.Writers
{
    public class HtmlWriter : BaseWriter, IModelWriter
    {
        #region IContentWriter

        string IModelWriter.Write( IModelElement rootElement )
        {
            return WriteElement( rootElement, 0 );
        }

        #endregion


        #region Utils

        private string WriteElement( IModelElement modelElement, int level )
        {
            var sb = new StringBuilder();

            WriteOpeningTag( modelElement, sb, level );
            WriteText( modelElement, sb, level );
            WriteChildren( modelElement, sb, level );
            WriteClosingTag( modelElement, sb, level );

            return sb.ToString();
        }

        private static void WriteOpeningTag( IModelElement node, StringBuilder sb, int level )
        {
            if( !node.IsTagged() ) {
                return;
            }
            sb.Append( Indent( level ) );
            sb.AppendFormat(
                node.HasClosingTag() ? "<{0}{1}>" : "<{0}{1}/>",
                node.Tag,
                FoldAttributes( node.Attributes )
                );
            sb.Append( "\n" );
        }

        private static void WriteClosingTag( IModelElement node, StringBuilder sb, int level )
        {
            if( !node.IsTagged() || !node.HasClosingTag() ) {
                return;
            }
            sb.Append( Indent( level ) );
            sb.AppendFormat( "</{0}>", node.Tag );
            sb.Append( "\n" );
        }

        private static void WriteText( IModelElement node, StringBuilder sb, int level )
        {
            if( !node.HasText() || node.Text.Trim() == "" ) {
                return;
            }
            sb.Append( Indent( level ) );
            sb.Append( node.Text );
            sb.Append( "\n" );
        }

        private void WriteChildren( IModelElement node, StringBuilder sb, int level )
        {
            node.Elements.ForEach( e => { sb.Append( WriteElement( e, level + 1 ) ); } );
        }

        #endregion
    }
}