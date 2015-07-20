// Samples.Html (c) 2015 Roman Koshelev
// Samples.Html.Core
// ITextComparator.cs

namespace Samples.Html.Core.Types
{
    public interface ITextComparator
    {
        bool AreEqual( string s1, string s2 );
    }
}