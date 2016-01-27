using System.Collections.Generic;
using System.Text;

using ICell = BotRace.Game.Cell;

namespace BotRace.Game.Implementation.CSharp
{
    public class Maze : BotRace.Game.Maze
    {
        private Cell[][] Grid { get; set; }

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

            return new Maze { Grid = grid.ToArray() };
        }

        internal bool Exists(BotRace.Game.Position position)
        {
            var size = Grid.Length;

            return 0 <= position.Column && position.Column < size && 
                   0 <= position.Row && position.Row < size;
        }

        public int Width { get { return Grid[0].Length; } }
        
        public int Height { get { return Grid.Length; } }

        public ICell CellAt(BotRace.Game.Position position)
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

        public BotRace.Game.Position Home 
        {
            get
            {
                return new Position(0, 0);
            }
        }

        public BotRace.Game.Position Exit
        {
            get
            {
                return new Position(Height, Width);
            }
        }

        internal void Carve(Position from, Direction direction)
        {
            var fromCell = CellAt(from);
            var toCell = CellAt(from.At(direction));

            fromCell.Carve(direction);
            toCell.Carve(direction.Oposite());
        }
    }
}
