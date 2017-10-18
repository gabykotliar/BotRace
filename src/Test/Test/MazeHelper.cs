using System.Linq;
using System.Text;

using BotRace.Game;
using BotRace.Game.Mazes;
using BotRace.Game.Mazes.Imp;
using BotRace.Game.Runtime;

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
                    var cell = maze.CellAt(new Position(row, column));
                    graph.Append(cell.HasWall(Direction.S) ? "_" : " ");
                    graph.Append(cell.HasWall(Direction.E) ? "|" : " ");
                }

                graph.AppendLine();
            }

            return graph.ToString();
        }

        public static string Draw(this GameStatus status)
        {
            var graph = new StringBuilder();
            var heigth = status.Maze.Height;
            var width = status.Maze.Width;

            graph.Append(" ");
            graph.AppendLine(string.Join(string.Empty, Enumerable.Repeat("_", width * 2 - 1)));

            for (int row = 0; row < heigth; row++)
            {
                graph.Append("|");

                for (int column = 0; column < width; column++)
                {
                    var cell = status.Maze.CellAt(new Position(row, column));

                    var botInCell = status.Positions.FirstOrDefault(p => p.Value.Row == row && p.Value.Column == column).Key;

                    if (botInCell != null)
                    {
                        graph.Append("1");
                    }
                    else
                    { 
                        graph.Append(cell.HasWall(Direction.S) ? "_" : " ");
                    }

                    graph.Append(cell.HasWall(Direction.E) ? "|" : " ");
                }

                graph.AppendLine();
            }

            return graph.ToString();
        }
    }
}
