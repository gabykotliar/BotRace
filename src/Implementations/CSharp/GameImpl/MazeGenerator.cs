// http://weblog.jamisbuck.org/2010/12/27/maze-generation-recursive-backtracking    

// http://weblog.jamisbuck.org/2011/2/7/maze-generation-algorithm-recap.html

using BotRace.Game.Implementation.Extensions;
using IMaze = BotRace.Game.IMaze;

namespace BotRace.Game.Implementation
{
    public class RecursiveBacktrackingMazeGenerator : IMazeGenerator
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
