using System;

using BotRace.Game;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Cell = BotRace.Game.Implementation.Cell;

namespace BotRace.Test.CSharp
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void OnCreationCellIsClosed()
        {
            Assert.IsTrue(new Cell().IsClosed());            
        }

        [TestMethod]
        public void IsClosedIfHasAllTheWallsTest()
        {
            var cell = new Cell();

            Assert.IsTrue(cell.HasWall(Direction.N));
            Assert.IsTrue(cell.HasWall(Direction.E));
            Assert.IsTrue(cell.HasWall(Direction.S));
            Assert.IsTrue(cell.HasWall(Direction.W));
            Assert.IsTrue(cell.IsClosed());
        }

        [TestMethod]
        public void IsNoyClosedIfMissAWallsTest()
        {
            var cell = new Cell();

            cell.Carve(Direction.N);
            
            Assert.IsFalse(cell.IsClosed());
        }

        [TestMethod]
        public void OnCarveOnDirectionOnlyThatWallDisapears()
        {
            var directions = new[] { Direction.N, Direction.E, Direction.W, Direction.S };

            foreach (var direction in directions)
            {
                var carved = new Cell().Carve(direction);

                foreach (var testDirection in directions)
                {
                    Assert.IsTrue(carved.HasWall(testDirection) == (direction != testDirection));
                }
            }
        }        

        [TestMethod]
        public void ToJsonClosedDigitTest()
        {
            var cell = new Cell();

            Assert.IsTrue(cell.IsClosed());
            Assert.AreEqual("F", cell.ToJson());
        }

        [TestMethod]
        public void ToJson1DigitTest()
        {
            var cell = new Cell();

            cell.Carve(Direction.N);

            Assert.AreEqual("7", cell.ToJson());
        }

        [TestMethod]
        public void ToJsonOpenTest()
        {
            var cell = new Cell();

            cell.Carve(Direction.N);
            cell.Carve(Direction.E);
            cell.Carve(Direction.S);
            cell.Carve(Direction.W);
            
            Assert.AreEqual("0", cell.ToJson());
        }
    }
}
