// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Tests.Nunit
// TestBase.cs

using System;
using System.IO;

namespace Samples.Html.Nunit.Utils
{
    public class TestBase
    {
        #region Utils

        protected void CreateTools( IFactory factory )
        {
            Input = ReadInputHtml();
            WrongInput = ReadWrongHtml();

            Parser = factory.MakeHtmlParser();
            Builder = factory.MakeModelBuilder();

            Comparator = factory.MakeTextComparator();
            HtmlWriter = factory.MakeHtmlWriter();
            StructWriter = factory.MakeStructWriter();
            OutlineWriter = factory.MakeOutlineWriter();

            Log( "[Using {0}]\n", factory.GetType().Name );
        }

        protected static string ReadInputHtml()
        {
            return File.ReadAllText( InputFileName );
        }

        protected static void WiteFile( string outString )
        {
            File.WriteAllText( OutputFileName, outString );
        }

        protected static string ReadWrongHtml()
        {
            return File.ReadAllText( WrongFileName );
        }

        protected static void Log( string str )
        {
            Console.WriteLine( str );
        }

        protected static void Log( string format, params object[] args )
        {
            Console.WriteLine( format, args );
        }

        #endregion


        #region Constants

        protected const string WrongFileName = @"App_Data\wrong.html";
        protected const string InputFileName = @"App_Data\input.html";
        protected const string OutputFileName = @"App_Data\output.html";

        #endregion


        #region Fields

        protected string Input { get; set; }
        protected string WrongInput { get; set; }
        protected IModelBuilder Builder { get; set; }
        protected IParser Parser { get; set; }
        protected ITextComparator Comparator { get; set; }
        protected IModelWriter HtmlWriter { get; set; }
        protected IModelWriter StructWriter { get; set; }
        protected IModelWriter OutlineWriter { get; set; }

        #endregion
    }
}