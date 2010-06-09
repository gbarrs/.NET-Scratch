using System;

namespace CodeTest
{
    public class Match
    {
        private readonly int _startPosition;

        public Match(int startPosition)
        {
            if (startPosition < 1)
            {
                var message = string.Format("The start position of a match cannot be less than one. The start position supplied was '{0}'.  Do you have an 'off by one' error?", startPosition);
                throw new ArgumentException(message);
            }
            _startPosition = startPosition;
        }

        public int StartPosition
        {
            get
            {
                return _startPosition;
            }
        }
    }
}