// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Tests.Nunit
// AssertThat.cs

using NUnit.Framework;
using Samples.Html.Elements;
using Samples.Html.Types;

namespace Samples.Html.Nunit.Utils
{
    internal static class AssertThat
    {
        public static void Output_file_is_equal_to_input( ITextComparator textComparator, string inString, string outString )
        {
            Assert.That(
                textComparator.AreEqual( inString, outString ),
                "comparator.AreEqual( inString, outString )"
                );
        }

        public static void Model_struct_is_corrrect( string structOutput )
        {
            Assert.AreEqual(
                "Page:(0)[]{Table:(0)[border,cellspacing,style]{Tr:(0)[]{Td:(0)[]{Text:(57)[]{}}Td:(0)[style]{Text:(57)[]{}}Td:(0)[style]{Text:(57)[]{}}}Tr:(0)[]{Td:(0)[width]{Text:(57)[]{}}Td:(0)[]{Text:(57)[]{}}Td:(0)[]{Text:(57)[]{}}}}}",
                structOutput,
                "structOutput"
                );
        }

        public static void Styles_are_corrrect( IModelElement element )
        {
            Assert.AreEqual(
                "5px green solid",
                element[ "table" ][ 0 ][ "tr" ][ 0 ][ "td" ][ 1 ].Styles[ "border" ],
                "Table attribute"
                );
        }

        public static void Attributes_are_corrrect( IModelElement element )
        {
            Assert.AreEqual(
                "10px",
                element[ "table" ][ 0 ].Attributes[ "cellspacing" ],
                "Table attribute"
                );
        }

        public static void Element_is_Page( IModelElement element )
        {
            Assert.IsInstanceOf< Page >( element, "element is Page" );
        }

        public static void Text_is_correct( IModelElement element )
        {
            Assert.AreEqual(
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit,",
                element[ "table" ][ 0 ][ "tr" ][ 0 ][ "td" ][ 1 ].TextElement.Text,
                "Text"
                )
                ;
        }
    }
}