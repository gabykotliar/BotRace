// http://weblog.jamisbuck.org/2010/12/27/maze-generation-recursive-backtracking    

using BotRace.Game.Implementation.CSharp.Extensions;
using IMaze = BotRace.Game.Maze;

namespace BotRace.Game.Implementation.CSharp
{
    public class RecursiveBacktrackingMazeGenerator : MazeGenerator
    {
        public IMaze Create(int size)
        {
            var maze = Maze.ClosedGrid(size);

            var startPosition = new Position(0, 0);

            CarvePassageFrom(startPosition, maze);

            return maze;
        }

        private void CarvePassageFrom(Position pos, Maze maze)
        {
            var directions = new[] { Direction.N, Direction.E, Direction.S, Direction.W }.Shuffle();

            foreach (var direction in directions)
            {
                var targetPosition = (Position)pos.At(direction);

                if (maze.Exists(targetPosition) && maze.CellAt(targetPosition).IsClosed())
                {
                    maze.Carve(pos, direction);

                    CarvePassageFrom(targetPosition, maze);
                }
            }
        }
    }
}
