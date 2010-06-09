using System;
using Xunit;

namespace CodeTest.Tests.Unit
{
    public class MatchTests
    {
        public void Ctor_StartPositionIsLessThanOne_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Match(0));
        }

        public void Ctor_StartPositionSupplied_StartPositionAvailable()
        {
            const int someStartPosition = 3;
            var match = new Match(someStartPosition);
            Assert.Equal(someStartPosition,match.StartPosition);
        }
    }
}