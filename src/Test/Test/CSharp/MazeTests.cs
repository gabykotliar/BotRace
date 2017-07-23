using System.Text;
using BotRace.Game;
using BotRace.Game.Implementation;
using Xunit;

namespace BotRace.Test.CSharp
{
    public class MazeTests
    {
        [Fact]
        public void ClosedDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _____");
            expected.AppendLine("|_|_|_|");
            expected.AppendLine("|_|_|_|");
            expected.AppendLine("|_|_|_|");

            Assert.Equal(expected.ToString(), Maze.ClosedGrid(3).Draw());
        }

        [Fact]
        public void CarvedEastGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _____");
            expected.AppendLine("|_ _|_|");
            expected.AppendLine("|_|_|_|");
            expected.AppendLine("|_|_|_|");

            var maze = Maze.ClosedGrid(3);

            maze.Carve(new Position(0, 0), Direction.E);

            Assert.Equal(expected.ToString(), maze.Draw());
        }

        [Fact]
        public void CarvedSouthGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _____");
            expected.AppendLine("| |_|_|");
            expected.AppendLine("|_|_|_|");
            expected.AppendLine("|_|_|_|");

            var maze = Maze.ClosedGrid(3);

            maze.Carve(new Position(0, 0), Direction.S);

            Assert.Equal(expected.ToString(), maze.Draw());
        }

        [Fact]
        public void CarvedSouthAndEastGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _____");
            expected.AppendLine("|  _|_|");
            expected.AppendLine("|_|_|_|");
            expected.AppendLine("|_|_|_|");

            var maze = Maze.ClosedGrid(3);

            maze.Carve(new Position(0, 0), Direction.S);
            maze.Carve(new Position(0, 0), Direction.E);

            Assert.Equal(expected.ToString(), maze.Draw());
        }

        [Fact]
        public void CarvedCenterSouthGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _______");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_| |_|_|");
            expected.AppendLine("|_|_|_|_|");

            var maze = Maze.ClosedGrid(4);

            maze.Carve(new Position(2, 1), Direction.S);

            Assert.Equal(expected.ToString(), maze.Draw());
        }

        [Fact]
        public void CarvedCenterNorthGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _______");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_| |_|_|");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_|_|_|_|");

            var maze = Maze.ClosedGrid(4);

            maze.Carve(new Position(2, 1), Direction.N);

            Assert.Equal(expected.ToString(), maze.Draw());
        }

        [Fact]
        public void CarvedCenterEastGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _______");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_|_ _|_|");
            expected.AppendLine("|_|_|_|_|");

            var maze = Maze.ClosedGrid(4);

            maze.Carve(new Position(2, 1), Direction.E);

            Assert.Equal(expected.ToString(), maze.Draw());
        }

        [Fact]
        public void CarvedCenterWestGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _______");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_|_|_|_|");
            expected.AppendLine("|_ _|_|_|");
            expected.AppendLine("|_|_|_|_|");

            var maze = Maze.ClosedGrid(4);

            maze.Carve(new Position(2, 1), Direction.W);

            Assert.Equal(expected.ToString(), maze.Draw());
        }
       
        [Fact]
        public void ComplexGridDrawTest()
        {
            var expected = new StringBuilder();
            expected.AppendLine(" _________");
            expected.AppendLine("|    _ _ _|");
            expected.AppendLine("| |_|  _  |");
            expected.AppendLine("| |_ _| | |");
            expected.AppendLine("| |  _  | |");
            expected.AppendLine("|_ _ _|_ _|");

            var maze = Maze.ClosedGrid(5);
            
            // row 0 walls
            maze.Carve(new Position(0, 0), Direction.E);
            maze.Carve(new Position(0, 1), Direction.E);
            maze.Carve(new Position(0, 2), Direction.E);
            maze.Carve(new Position(0, 3), Direction.E);

            // row 0 floors
            maze.Carve(new Position(0, 0), Direction.S);
            maze.Carve(new Position(0, 1), Direction.S);

            // row 1 walls
            maze.Carve(new Position(1, 2), Direction.E);
            maze.Carve(new Position(1, 3), Direction.E);

            // row 1 floors
            maze.Carve(new Position(1, 0), Direction.S);
            maze.Carve(new Position(1, 2), Direction.S);
            maze.Carve(new Position(1, 4), Direction.S);

            // row 2 walls
            maze.Carve(new Position(2, 1), Direction.E);

            // row 2 floors
            maze.Carve(new Position(2, 0), Direction.S);
            maze.Carve(new Position(2, 3), Direction.S);
            maze.Carve(new Position(2, 4), Direction.S);

            // row 3 walls
            maze.Carve(new Position(3, 1), Direction.E);
            maze.Carve(new Position(3, 2), Direction.E);

            // row 3 floors
            maze.Carve(new Position(3, 0), Direction.S);
            maze.Carve(new Position(3, 1), Direction.S);
            maze.Carve(new Position(3, 3), Direction.S);
            maze.Carve(new Position(3, 4), Direction.S);

            // row 4 walls
            maze.Carve(new Position(4, 0), Direction.E);
            maze.Carve(new Position(4, 1), Direction.E);
            maze.Carve(new Position(4, 3), Direction.E);

            Assert.Equal(expected.ToString(), maze.Draw());
        }
    }
}
