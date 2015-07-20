// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Tests.Nunit
// Main_Tests.cs

using NUnit.Framework;
using Samples.Html.Nunit.Utils;
using Samples.Html.Types;
using Samples.Html.Utils;

// ========================================================================== []
// 
// This is an abstract tests fixture.
// Please run concrete ones instead of this:
// - HupParser_Tests
// - LexParser_Tests
// 
// Input files are placed in the \App_Data\ folder
// Output files can be found in the \bin\Debug\App_Data\ folder
// 
// ========================================================================== []

namespace Samples.Html.Nunit.Tests
{
    [TestFixture]
    public abstract class Main_Tests : TestBase
    {
        #region Setups

        [SetUp]
        public void BeforeEachTest()
        {
            // The Fixture creates Parser, ModelBuilder, Writers 
            // and other tools wich would be used during the unit tests execution
            CreateTools( GetFactory() );
        }

        // The Factory would determine wich Parser Implementation should be used
        protected abstract IFactory GetFactory();

        #endregion


        #region Tests

        [Test]
        public void Model_has_proper_type()
        {
            // The Builder creates Model using the Parser and the input html data
            // The Model is represented by its tree root element
            // Each element contains its Tag, Text, child Elements, Attributes, Styles, and so on
            // See \Types\IModelElement\ for details
            var model = Builder.BuildModel( Parser, Input );

            // We can view the result in our Unit Test Framework output window
            Log( model.GetType().Name );

            // The Root Element of the Model must be type of 'Page'
            AssertThat.Element_is_Page( model );
        }

        [Test]
        public void Exception_is_thrown_on_unknown_html_enteties()
        {
            // As Model can be easy extended, it has to detect yet unsupported tags and types (e.g. comments)
            var catched = false;
            try {
                Builder.BuildModel( Parser, WrongInput );
            }
            catch( AsposeHtmlException e ) {
                catched = true;
                Log( e.Message );
            }
            Assert.That( catched );
        }

        [Test]
        public void Output_file_is_equal_to_input()
        {
            // Model may be serialized to string using the HtmlWriter and then compared with the original
            var model = Builder.BuildModel( Parser, Input );
            var output = HtmlWriter.Write( model );
            Log( output );

            // We can find the restored Html in this folder: \bin\Debug\App_Data\
            WiteFile( output );

            // Comporator may made some preparation over the strings to ignore insignificant differences
            AssertThat.Output_file_is_equal_to_input( Comparator, Input, output );
        }

        [Test]
        public void Model_struct_is_corrrect()
        {
            // The model is serialized by StructWriter in a special manner to 
            // determine whether its structure correct or not, e.g.: 
            // Page:(0)[]{Table:(0)[border,cellspacing,style]{Tr:(0)[]{T ... {Text:(57)[]{}}}}}
            var model = Builder.BuildModel( Parser, Input );
            var output = StructWriter.Write( model );
            Log( output );
            AssertThat.Model_struct_is_corrrect( output );
        }

        [Test]
        public void Attributes_are_correct()
        {
            // We can obtain Model Items and their attriubutes in such a manner:
            // node[ "table" ][ 0 ].Attributes[ "cellspacing" ]
            var model = Builder.BuildModel( Parser, Input );
            var output = OutlineWriter.Write( model );
            Log( output );
            AssertThat.Attributes_are_corrrect( model );
        }

        [Test]
        public void Styles_are_corrrect()
        {
            // Builder parses a special attribute "style" so the style can be reffered as
            // node[ "table" ][ 0 ][ "tr" ][ 1 ][ "td" ][ 2 ].Styles[ "border" ]
            var model = Builder.BuildModel( Parser, Input );
            var output = OutlineWriter.Write( model );
            Log( output );
            AssertThat.Styles_are_corrrect( model );
        }

        [Test]
        public void Text_is_accessable()
        {
            // To get the Text value, we have to address to the first TextElement:
            // node[ "table" ][ 0 ][ "tr" ][ 0 ][ "td" ][ 1 ].TextElement.Text
            var model = Builder.BuildModel( Parser, Input );
            var output = OutlineWriter.Write( model );
            Log( output );
            AssertThat.Text_is_correct( model );
        }

        #endregion
    }
}