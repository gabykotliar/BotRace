using System;

using BotRace.Game;

using Cell = BotRace.Game.Implementation.Cell;
using Xunit;

namespace BotRace.Test.CSharp
{
    public class CellTests
    {
        [Fact]
        public void OnCreationCellIsClosed()
        {
            Assert.True(new Cell().IsClosed());            
        }

        [Fact]
        public void IsClosedIfHasAllTheWallsTest()
        {
            var cell = new Cell();

            Assert.True(cell.HasWall(Direction.N));
            Assert.True(cell.HasWall(Direction.E));
            Assert.True(cell.HasWall(Direction.S));
            Assert.True(cell.HasWall(Direction.W));
            Assert.True(cell.IsClosed());
        }

        [Fact]
        public void IsNoyClosedIfMissAWallsTest()
        {
            var cell = new Cell();

            cell.Carve(Direction.N);
            
            Assert.False(cell.IsClosed());
        }

        [Fact]
        public void OnCarveOnDirectionOnlyThatWallDisapears()
        {
            var directions = new[] { Direction.N, Direction.E, Direction.W, Direction.S };

            foreach (var direction in directions)
            {
                var carved = new Cell().Carve(direction);

                foreach (var testDirection in directions)
                {
                    Assert.True(carved.HasWall(testDirection) == (direction != testDirection));
                }
            }
        }        

        [Fact]
        public void ToJsonClosedDigitTest()
        {
            var cell = new Cell();

            Assert.True(cell.IsClosed());
            Assert.Equal("F", cell.ToJson());
        }

        [Fact]
        public void ToJson1DigitTest()
        {
            var cell = new Cell();

            cell.Carve(Direction.N);

            Assert.Equal("7", cell.ToJson());
        }

        [Fact]
        public void ToJsonOpenTest()
        {
            var cell = new Cell();

            cell.Carve(Direction.N);
            cell.Carve(Direction.E);
            cell.Carve(Direction.S);
            cell.Carve(Direction.W);
            
            Assert.Equal("0", cell.ToJson());
        }
    }
}
