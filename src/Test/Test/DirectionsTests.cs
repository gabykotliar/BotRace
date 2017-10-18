using BotRace.Game;
using BotRace.Game.Mazes;
using Xunit;

namespace BotRace.Test.CSharp
{
    public class DirectionsTests
    {
        [Fact]
        public void OpositeDirectionisCorrect()
        {
            Assert.Equal(Direction.S, Direction.N.Oposite());
            Assert.Equal(Direction.N, Direction.S.Oposite());
            Assert.Equal(Direction.W, Direction.E.Oposite());
            Assert.Equal(Direction.E, Direction.W.Oposite());
        }
    }
}
