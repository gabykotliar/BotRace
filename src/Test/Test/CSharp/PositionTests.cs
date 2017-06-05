using BotRace.Game;
using Xunit;
using Position = BotRace.Game.Implementation.Position;

namespace BotRace.Test.CSharp
{
    public class PositionTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var p = new Position(2, 1);

            Assert.Equal(2, p.Row);
            Assert.Equal(1, p.Column);
        }

        [Fact]
        public void PositionAtTests()
        {
            var p = new Position(2, 1);
            var np = p.At(Direction.N);
            var ep = p.At(Direction.E);
            var wp = p.At(Direction.W);
            var sp = p.At(Direction.S);

            // from
            Assert.Equal(2, p.Row);
            Assert.Equal(1, p.Column);

            // north
            Assert.Equal(1, np.Row); //"nort row"
            Assert.Equal(1, np.Column); //"nort col"

            // east
            Assert.Equal(2, ep.Row); //"east row"
            Assert.Equal(2, ep.Column); //"east col"

            // west
            Assert.Equal(2, wp.Row); //"west row"
            Assert.Equal(0, wp.Column); //"west col"

            // south
            Assert.Equal(3, sp.Row); //"south row"
            Assert.Equal(1, sp.Column); //"south col"
        }
    }
}
