using System.Linq;
using System.Text;
using CodeTest.Views;

namespace CodeTest.Controllers
{
    public class MainController
    {
        private MainView _mainView;
        private readonly StringBuilder _matchesMessage = new StringBuilder();

        public MainView DoTextMatch(string text, string subtext)
        {
            try
            {
                reset();

                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
                {
                    createInputEmptyMatchView(text, subtext);
                    return _mainView;
                }

                var textMatcher = new TextMatcher(text, subtext);
                textMatcher.Match();

                if (textMatcher.GetMatches().Count() == 0)
                {
                    createNoMatchView(text, subtext);
                    return _mainView;
                }

                createMatchView(text, subtext, textMatcher);
                return _mainView;

            }
            catch (SubtextLongerThanTextException)
            {

                createSubtextTooLongMatchView(text, subtext);
                return _mainView;
            }

        }

        private void reset()
        {
            _matchesMessage.Clear();
            _mainView = null;
        }

        private void createInputEmptyMatchView(string text, string subtext)
        {
            var viewText = text ?? string.Empty;
            var viewSubtext = subtext ?? string.Empty;
            _matchesMessage.Append(Properties.Resources.textOrSubtextEmptyMessage);
            createMainView(viewText, viewSubtext);
        }

        private void createMainView(string viewText, string viewSubtext)
        {
            _mainView = new MainView(viewText, viewSubtext, _matchesMessage.ToString());
        }

        private void createNoMatchView(string text, string subtext)
        {
            _matchesMessage.Append(Properties.Resources.noMatchesMessage);
            createMainView(text, subtext);
        }

        private void createSubtextTooLongMatchView(string text, string subtext)
        {
            _matchesMessage.Append(Properties.Resources.subtextTooLongMessage);
            createMainView(text, subtext);
        }

        private void createMatchView(string text, string subtext, TextMatcher textMatcher)
        {
            buildMatchesMessage(textMatcher);
            createMainView(text, subtext);
        }

        private void buildMatchesMessage(TextMatcher textMatcher)
        {
            foreach (var match in textMatcher.GetMatches())
            {
                _matchesMessage.Append(match.StartPosition + ",");
            }

            if (_matchesMessage.Length > 0)
            {
                const int arrayOffset = 1;
                var lastCharacterPosition = _matchesMessage.Length - arrayOffset;
                const int numberOfCharacters = 1;
                _matchesMessage.Remove(lastCharacterPosition, numberOfCharacters);
            }
        }


    }
}
