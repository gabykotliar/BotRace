using System;

namespace BotRace.Game.Mazes.Imp
{
    public class Position : IPosition
    {
        public Position(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public int Column { get; private set; }

        public int Row { get; private set; }

        public BotRace.Game.IPosition At(Direction direction)
        {
            switch (direction)
            {
                case Direction.N: return new Position(Row - 1, Column);
                case Direction.E: return new Position(Row, Column + 1);
                case Direction.S: return new Position(Row + 1, Column);
                case Direction.W: return new Position(Row, Column - 1);
            }

            throw new InvalidOperationException();
        }

        public override bool Equals(object obj)
        {
            var pos = obj as Position;

            return pos != null &&
                   (pos.Column == Column && pos.Row == Row);
        }

        public override int GetHashCode()
        {
            return Column ^ Row;
        }
    }
}
