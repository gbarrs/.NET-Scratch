    using System;
using System.Linq;
using NUnit.Framework;

namespace CodeTest.Tests.Unit
{
    [TestFixture]
    public class TextMatcherTests
    {
        [Test]
        public void Ctor_TextIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new TextMatcher(null, "Not Important"));
        }

        [Test]
        public void Ctor_SubtextIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new TextMatcher("Not Important", null));
        }

        [Test]
        public void Ctor_TextIsEmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new TextMatcher(string.Empty, "Not Important"));
        }

        [Test]
        public void Ctor_SubtextIsEmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new TextMatcher("Not Important", string.Empty));
        }

        [Test]
        public void Ctor_SubtextIsLongerThanText_ThrowsException()
        {
            const string text = "a";
            const string subtext = "ab";
            Assert.Throws<SubtextLongerThanTextException>(() => new TextMatcher(text, subtext));
        }

        [Test]
        public void GetMatches_MatchWasNotCalled_EmptyListReturned()
        {
            var textMatcher = new TextMatcher("Not Important", "Not Important");

            var matches = textMatcher.GetMatches();

            Assert.True(matches.Count() == 0);
        }

        [Test]
        public void Match_TextContainsOneInstanceOfSingleCharacterSubtext_ListContainsOneMatch()
        {
            const string text = "abc";
            const string subtext = "a";
            var textMatcher = new TextMatcher(text, subtext);

            textMatcher.Match();
            var matches = textMatcher.GetMatches();

            Assert.True(matches.Count() == 1);
        }

        [Test]
        public void Match_TextContainsOneInstanceOfSingleCharacterSubtext_MatchHasCorrectStartPosition()
        {
            const string text = "abc";
            const string subtext = "a";
            var textMatcher = new TextMatcher(text, subtext);

            textMatcher.Match();
            var matches = textMatcher.GetMatches();

            Assert.True(matches.First().StartPosition == 1);
        }

        [Test]
        public void Match_TextContainsThreeInstancesOfSingleCharacterSubtext_ListContainsThreeMatches()
        {
            const string text = "abcabcabc";
            const string subtext = "a";
            var textMatcher = new TextMatcher(text, subtext);

            textMatcher.Match();
            var matches = textMatcher.GetMatches();

            Assert.True(matches.Count() == 3);
        }

        [Test]
        public void Match_TextContainsThreeInstancesOfSingleCharacterSubtext_MatchesHaveCorrectStartPositions()
        {
            const string text = "abcabcabc";
            const string subtext = "a";
            var output = new[] { 1, 4, 7 };
            

            var textMatcher = new TextMatcher(text, subtext);
            textMatcher.Match();
            
            var matches = textMatcher.GetMatches();
            const int outputNotFoundValue = 0;
            foreach (int foundInOutput in matches.Select(match => (from o in output
                                                                         where o == match.StartPosition
                                                                         select o).SingleOrDefault()))
            {                
                Assert.AreNotEqual(outputNotFoundValue,foundInOutput);
            }





        }

        [Test]
        public void Match_TextContainsOneInstanceOfMultiCharacterSubtext_ListContainsOneMatch()
        {
            const string text = "abcxyzabc";
            const string subtext = "xyz";
            var textMatcher = new TextMatcher(text, subtext);

            textMatcher.Match();
            var matches = textMatcher.GetMatches();

            Assert.True(matches.Count() == 1);            
        }

        [Test]
        public void Match_TextContainsOneInstanceOfMultiCharacterSubtext_MatchHasCorrectStartPosition()
        {
            const string text = "abcxyzabc";
            const string subtext = "xyz";
            var textMatcher = new TextMatcher(text, subtext);

            textMatcher.Match();
            var matches = textMatcher.GetMatches();

            Assert.True(matches.First().StartPosition == 4);            
        }

        [Test]
        public void Match_UpperCaseTextContainsOneInstanceOfLowerCaseSubtext_CaseInsensitiveMatchOccurs()
        {
            const string text = "abcXYZabc";
            const string subtext = "xyz";
            var textMatcher = new TextMatcher(text, subtext);

            textMatcher.Match();
            var matches = textMatcher.GetMatches();

            Assert.True(matches.First().StartPosition == 4);   
        }

    }
}