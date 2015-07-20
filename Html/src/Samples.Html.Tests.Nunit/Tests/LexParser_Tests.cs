// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Tests.Nunit
// LexParser_Tests.cs

using NUnit.Framework;
using Samples.Html.Core.Factories;
using Samples.Html.Core.Types;

// ========================================================================== []
//
// Not implemented yet
// Would use the LexParser
// LexParser should implement the chain: 
//     [html] -> Lexical Analyser -> [tokens] -> Syntax Analyser -> [Syntax Tree]
// See http://www.html5rocks.com/ru/tutorials/internals/howbrowserswork/
//
// ========================================================================== []

namespace Samples.Html.Nunit.Tests
{
    [Ignore( "Not implemented yet" )]
    [TestFixture]
    public class LexParser_Tests : Main_Tests
    {
        protected override IFactory GetFactory()
        {
            return new LexFactory();
        }
    }
}