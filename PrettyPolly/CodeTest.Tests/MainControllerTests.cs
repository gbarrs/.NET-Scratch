using CodeTest.Controllers;
using NUnit.Framework;

namespace CodeTest.Tests.Unit
{
    [TestFixture]
    public class MainControllerTests
    {
        private const string _standardText = "abcxyzabc";
        private const string _matchingSubtext = "abc";
        private const string _expectedOutput = "1,7";
        private const string _nonMatchingSubtext = "p";
        private const string _tooLongSubtext = "ThisSubtextIsTooLong";


        [Test]
        public void DoTextMatch_TextAndSubtextEmpty_ViewContainsNoMatchesMessage()
        {
            var mainView = new MainController().DoTextMatch(string.Empty, string.Empty);
            Assert.AreEqual(Controllers.Properties.Resources.textOrSubtextEmptyMessage, mainView.Matches);
        }

        [Test]
        public void DoTextMatch_TextEmpty_ViewContainsNoMatchesMessage()
        {
            var mainView = new MainController().DoTextMatch(string.Empty, _matchingSubtext);
            Assert.AreEqual(Controllers.Properties.Resources.textOrSubtextEmptyMessage, mainView.Matches);
        }

        [Test]
        public void DoTextMatch_SubtextEmpty_ViewContainsNoMatchesMessage()
        {
            var mainView = new MainController().DoTextMatch(_standardText, string.Empty);
            Assert.AreEqual(Controllers.Properties.Resources.textOrSubtextEmptyMessage, mainView.Matches);
        }

        [Test]
        public void DoTextMatch_NoMatches_ViewContainsNoMatchesMessage()
        {
            var mainView = new MainController().DoTextMatch(_standardText, _nonMatchingSubtext);
            Assert.AreEqual(Controllers.Properties.Resources.noMatchesMessage, mainView.Matches);
        }

        [Test]
        public void DoTextMatch_SubtextLongerThanText_ViewContainsSubtextTooLongMessage()
        {
            var mainView = new MainController().DoTextMatch(_standardText, _tooLongSubtext);
            Assert.AreEqual(Controllers.Properties.Resources.subtextTooLongMessage, mainView.Matches);
        }

        [Test]
        public void DoTextMatch_MatchesFound_ViewContainsMatchesMessage()
        {
            var mainView = new MainController().DoTextMatch(_standardText, _matchingSubtext);
            Assert.AreEqual(_expectedOutput, mainView.Matches);
        }

        [Test]
        public void DoTextMatch_CalledMultipleTimes_ViewContainsMatchesMessage()
        {
            var mainController = new MainController();
            mainController.DoTextMatch(_standardText, _matchingSubtext);
            mainController.DoTextMatch(_standardText, _matchingSubtext);
            var mainView = mainController.DoTextMatch(_standardText, _matchingSubtext);
            Assert.AreEqual(_expectedOutput, mainView.Matches);
        }



    }
}
