// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Tests.Nunit
// HupParser_Tests.cs

using NUnit.Framework;
using Samples.Html.Core.Factories;
using Samples.Html.Core.Types;

// ========================================================================== []
//
// These tests use the HapParser, based on the "Html Agility Pack" nuget package 
// Html Agility Pack (hap) parses the Html and gives us access to the built nodes 
// See https://htmlagilitypack.codeplex.com/
//
// ========================================================================== []

namespace Samples.Html.Nunit.Tests
{
    [TestFixture]
    public class HupParser_Tests : Main_Tests
    {
        protected override IFactory GetFactory()
        {
            return new HapFactory();
        }
    }
}