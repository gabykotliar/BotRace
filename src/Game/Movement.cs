using System.ComponentModel;

namespace BotRace.Game
{
    public class Movement
    {
        public Movement(Direction direction)
        {
            if (direction == Direction.All) 
                throw new InvalidEnumArgumentException("direction", (int)Direction.All, typeof(Direction));

            Direction = direction;

            Speed = 1;
        }

        public Direction Direction { get; set; }

        public int Speed { get; set; }
    }
}
