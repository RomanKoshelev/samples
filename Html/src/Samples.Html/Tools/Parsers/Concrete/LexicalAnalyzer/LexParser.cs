// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html
// LexParser.cs

using System;
using Samples.Html.Types;

namespace Samples.Html.Tools.Parsers.Concrete.LexicalAnalyzer
{
    // ========================================================================== []
    //
    // LexParser should implement the chain: 
    //     [html] -> Lexical Analyser -> [tokens] -> Syntax Analyser -> [Syntax Tree]
    // See http://www.html5rocks.com/ru/tutorials/internals/howbrowserswork/
    //
    // ========================================================================== []
    public class LexParser : IParser
    {
        public IParserNode GetRoot()
        {
            throw new NotImplementedException();
        }

        public void Parse( string source )
        {
            throw new NotImplementedException();
        }
    }
}