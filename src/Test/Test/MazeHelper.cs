using System.Linq;
using System.Text;

using BotRace.Game;

namespace BotRace.Test
{
    public static class MazeHelper
    {
        public static string Draw(this IMaze maze)
        {
            var graph = new StringBuilder();
            var heigth = maze.Height;
            var width = maze.Width;

            graph.Append(" ");
            graph.AppendLine(string.Join(string.Empty, Enumerable.Repeat("_", width * 2 - 1)));

            for (int row = 0; row < heigth; row++)
            {
                graph.Append("|");

                for (int column = 0; column < width; column++)
                {
                    var cell = maze.CellAt(new Game.Implementation.Position(row, column));
                    graph.Append(cell.HasWall(Direction.S) ? "_" : " ");
                    graph.Append(cell.HasWall(Direction.E) ? "|" : " ");
                }

                graph.AppendLine();
            }

            return graph.ToString();
        }
    }
}
