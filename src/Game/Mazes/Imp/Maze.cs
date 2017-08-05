using System.Collections.Generic;
using System.Text;

namespace BotRace.Game.Mazes.Imp
{
    public class Maze : IMaze
    {
        private Cell[][] Grid { get; set; }

        protected Maze()
        {
            
        }

        internal static Maze ClosedGrid(int size)
        {
            var grid = new List<Cell[]>();

            for (int row = 0; row < size; row++)
            {
                var cellsRow = new List<Cell>();

                for (int column = 0; column < size; column++)
                {
                    cellsRow.Add(new Cell());
                }

                grid.Add(cellsRow.ToArray());
            }

            return new Maze
            {
                Home = new Position(0,0),
                Exit = new Position(size - 1, size - 1),
                Grid = grid.ToArray()
            };
        }

        internal bool Exists(IPosition position)
        {
            var size = Grid.Length;

            return 0 <= position.Column && position.Column < size && 
                   0 <= position.Row && position.Row < size;
        }

        public int Width => Grid[0].Length;

        public int Height => Grid.Length;

        public ICell CellAt(IPosition position)
        {
            return Grid[position.Row][position.Column];
        }

        public string ToJson()
        {
            var grid = new StringBuilder();

            foreach (var row in Grid)
            {
                foreach (var cell in row)
                {
                    grid.Append(cell.ToJson());
                }
            }


            return grid.ToString();
        }

        public IPosition Home { get; protected set; }

        public IPosition Exit { get; protected set; }

        internal void Carve(Position from, Direction direction)
        {
            var fromCell = CellAt(from);
            var toCell = CellAt(from.At(direction));

            fromCell.Carve(direction);
            toCell.Carve(direction.Oposite());
        }
    }
}
