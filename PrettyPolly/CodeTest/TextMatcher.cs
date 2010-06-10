using System;
using System.Collections.Generic;

namespace CodeTest
{
    public class TextMatcher
    {
        private readonly char[] _text;
        private readonly char[] _subtext;
        private readonly List<Match> _matches = new List<Match>();

        public TextMatcher(string text, string subtext)
        {
            throwExceptionIfConstructorParametersAreNotValid(text, subtext);

            _text = text.ToCharArray();
            _subtext = subtext.ToCharArray();

        }

        private void throwExceptionIfConstructorParametersAreNotValid(string text, string subtext)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("The text parameter was an empty string.");
            }

            if (subtext == null)
            {
                throw new ArgumentNullException("subtext");
            }

            if (string.IsNullOrEmpty(subtext))
            {
                throw new ArgumentException("The subtext parameter was an empty string.");
            }

            if (subtext.Length > text.Length)
            {
                var message = string.Format("The subtext '{0}' is longer than the text '{1}'.", subtext, text);
                throw new SubtextLongerThanTextException(message);
            }
        }

        public void Match()
        {
            var firstSubtextCharacter = _subtext[0];

            for (int i = 0; i < _text.Length; i++)
            {
                if (caseInsensitiveCharactersMatch(firstSubtextCharacter, _text[i]))
                {
                    processMatch(i);
                }
            }
        }

        private bool caseInsensitiveCharactersMatch(Char firstCharacter, Char secondCharacter)
        {
            var lowerCaseFirstCharacter = char.ToLowerInvariant(firstCharacter);
            var lowerCaseSecondCharacter = char.ToLowerInvariant(secondCharacter);
            var charactersMatch = lowerCaseFirstCharacter.CompareTo(lowerCaseSecondCharacter) == 0;
            return charactersMatch;
        }

        private void processMatch(int textCharacterPosition)
        {
            int subtextCharacterPosition = 0;
            int matchStartPosition = textCharacterPosition;

                while (subtextCharacterPosition < _subtext.Length   
                    &&
                    textCharacterPosition < _text.Length
                    &&
                    caseInsensitiveCharactersMatch(_subtext[subtextCharacterPosition], _text[textCharacterPosition]))
            {
                textCharacterPosition++;
                subtextCharacterPosition++;
            }

            if (allSubtextCharactersAreMatched(subtextCharacterPosition))
            {
                const int arrayOffset = 1;
                var match = createMatch(matchStartPosition + arrayOffset);
                _matches.Add(match);
            }
        }

        private bool allSubtextCharactersAreMatched(int subtextCharacterPosition)
        {
            return subtextCharacterPosition == _subtext.Length;
        }

        private Match createMatch(int textCharacterPosition)
        {
            return new Match(textCharacterPosition);
        }

        public IEnumerable<Match> GetMatches()
        {
            return _matches;
        }
    }
}