// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Tests.Nunit
// Aux_Tests.cs

using System;
using System.IO;
using System.Linq;
using HtmlAgilityPack;
using MoreLinq;
using NUnit.Framework;
using Samples.Html.Nunit.Utils;

// ========================================================================== []
//
// Auxiliary low-level tests
//
// ========================================================================== []

namespace Samples.Html.Nunit.Tests
{
    [TestFixture]
    public class Aux_Tests : TestBase
    {
        #region HtmlAgilityPack

        [Test]
        public void Read_input_html_file_from_App_Data_folder_using_HtmlAgilityPack()
        {
            File.ReadAllText( InputFileName );
            Console.WriteLine( "done" );
        }

        [Test]
        public void Load_html_file_into_HtmlDocument_using_HtmlAgilityPack()
        {
            var html = new HtmlDocument();
            html.Load( InputFileName );
            Console.WriteLine( "done" );
        }

        [Test]
        public void Enumerate_html_file_nodes_using_HtmlAgilityPack()
        {
            var inString = File.ReadAllText( InputFileName );
            var html = new HtmlDocument();
            html.LoadHtml( inString );

            Console.WriteLine( inString );

            var root = html.DocumentNode;
            var nodes = root.Descendants();
            nodes.Where( n => n.NodeType == HtmlNodeType.Element ).ForEach( n => {
                Console.WriteLine( "{0}{1} = {2}",
                    new string( ' ', n.LinePosition/2 ),
                    n.OriginalName,
                    n.XPath );
            } );

            Console.WriteLine( root.SelectSingleNode( "/table[1]" ).Attributes[ 2 ].Name );
            Console.WriteLine( root.SelectSingleNode( "/table[1]" ).Attributes[ 2 ].Value );

            Assert.That( root.SelectSingleNode( "/table[1]" ).Attributes.Count.Equals( 3 ) );
            Assert.That( root.SelectSingleNode( "/table[1]/tr[2]/td[1]" ).Attributes.Count.Equals( 1 ) );
            Assert.That( root.SelectSingleNode( "/table[1]/tr[1]/td[1]" ).Attributes.Count.Equals( 0 ) );
        }
    }

    #endregion
}