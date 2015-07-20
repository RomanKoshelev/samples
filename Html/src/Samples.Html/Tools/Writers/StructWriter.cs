// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// StructWriter.cs

using System.Text;
using MoreLinq;
using Samples.Html.Types;

namespace Samples.Html.Tools.Writers
{
    public class StructWriter : BaseWriter, IModelWriter
    {
        #region IContentWriter

        string IModelWriter.Write( IModelElement rootElement )
        {
            return WriteElement( rootElement );
        }

        #endregion


        #region Utils

        private string WriteElement( IModelElement modelElement )
        {
            var sb = new StringBuilder();

            WriteName( modelElement, sb );
            WriteText( modelElement, sb );
            WriteShortAttributes( modelElement, sb );
            WriteChildren( modelElement, sb );

            return sb.ToString();
        }

        private static void WriteText( IModelElement node, StringBuilder sb )
        {
            sb.AppendFormat( "({0})", node.Text == null ? 0 : node.Text.Length );
        }

        private static void WriteName( IModelElement node, StringBuilder sb )
        {
            sb.AppendFormat( node.GetType().Name );
            sb.Append( ":" );
        }

        private void WriteChildren( IModelElement node, StringBuilder sb )
        {
            sb.Append( "{" );
            node.Elements.ForEach( e => { sb.Append( WriteElement( e ) ); } );
            sb.Append( "}" );
        }

        #endregion
    }
}