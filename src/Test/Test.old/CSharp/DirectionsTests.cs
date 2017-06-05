using BotRace.Game;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotRace.Test.CSharp
{
    [TestClass]
    public class DirectionsTests
    {
        [TestMethod]
        public void OpositeDirectionisCorrect()
        {
            Assert.AreEqual(Direction.S, Direction.N.Oposite());
            Assert.AreEqual(Direction.N, Direction.S.Oposite());
            Assert.AreEqual(Direction.W, Direction.E.Oposite());
            Assert.AreEqual(Direction.E, Direction.W.Oposite());
        }
    }
}
