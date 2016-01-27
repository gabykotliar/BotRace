using BotRace.Game;

using Microsoft.VisualStudio.TestTools.UnitTesting;

#if _FSHARP_IMPL 
using Position = BotRace.Game.Implementation.FSharp.Position;
#else
using Position = BotRace.Game.Implementation.CSharp.Position;
#endif

namespace BotRace.Test.CSharp
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var p = new Position(2, 1);

            Assert.AreEqual(2, p.Row);
            Assert.AreEqual(1, p.Column);
        }

        [TestMethod]
        public void PositionAtTests()
        {
            var p = new Position(2, 1);
            var np = p.At(Direction.N);
            var ep = p.At(Direction.E);
            var wp = p.At(Direction.W);
            var sp = p.At(Direction.S);

            // from
            Assert.AreEqual(2, p.Row);
            Assert.AreEqual(1, p.Column);

            // north
            Assert.AreEqual(1, np.Row, "nort row");
            Assert.AreEqual(1, np.Column, "nort col");

            // east
            Assert.AreEqual(2, ep.Row, "east row");
            Assert.AreEqual(2, ep.Column, "east col");

            // west
            Assert.AreEqual(2, wp.Row, "west row");
            Assert.AreEqual(0, wp.Column, "west col");

            // south
            Assert.AreEqual(3, sp.Row, "south row");
            Assert.AreEqual(1, sp.Column, "south col");
        }
    }
}
