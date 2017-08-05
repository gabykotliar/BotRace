namespace BotRace.Game.Mazes.Imp
{
    public class Cell : ICell
    {
        private readonly BitVector32 walls;

        public Cell()
        {
            walls = new BitVector32((int)Direction.All);
        }

        public bool HasWall(Direction direction)
        {
            return walls[(int)direction];
        }

        public ICell Carve(Direction direction)
        {
            walls[(int)direction] = false;

            return this;
        }

        public bool IsClosed()
        {
            return walls.Data == (int)Direction.All;
        }

        internal string ToJson()
        {
            return walls.Data.ToString("X");
        }
    }
}
