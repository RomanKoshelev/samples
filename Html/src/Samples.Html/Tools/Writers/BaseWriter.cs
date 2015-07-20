// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// BaseWriter.cs

using System.Collections.Generic;
using System.Text;
using Samples.Html.Types;
using Samples.Html.Utils;

namespace Samples.Html.Tools.Writers
{
    public abstract class BaseWriter
    {
        #region Protected utils

        protected static string FoldAttributes( IDictionary< string, string > attributes )
        {
            return attributes.FoldToStringBy(
                a => string.Format( " {0}=\"{1}\"", a.Key, a.Value ),
                ""
                );
        }

        protected static string Indent( int level )
        {
            return new string( ' ', level );
        }

        protected static void WriteShortAttributes( IModelElement node, StringBuilder sb )
        {
            sb.Append( "[" );
            sb.Append( node.Attributes.FoldToStringBy( a => a.Key, "," ) );
            sb.Append( "]" );
        }

        protected static void WriteFullAttributes( IModelElement node, StringBuilder sb )
        {
            sb.Append( "[" );
            sb.Append( node.Attributes.FoldToStringBy(
                a => string.Format( "{0}=\"{1}\"", a.Key, a.Value ),
                " " )
                );
            sb.Append( "]" );
        }

        protected static void WriteFullStyles( IModelElement node, StringBuilder sb )
        {
            sb.Append( "{" );
            sb.Append( node.Styles.FoldToStringBy(
                a => string.Format( "{0}=\"{1}\"", a.Key, a.Value ),
                ";" )
                );
            sb.Append( "}" );
        }

        #endregion
    }
}