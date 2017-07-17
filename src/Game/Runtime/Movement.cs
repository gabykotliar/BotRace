namespace BotRace.Game.Runtime
{
    public class Movement
    {
        private const int MinimumSpeed = 1;

        public Movement(Direction direction)
        {
            if (direction == Direction.All) 
                throw new System.ArgumentException($"A specific direction must be specified. {(int)Direction.All} is invalid");

            Direction = direction;

            Speed = MinimumSpeed;
        }

        public Direction Direction { get; set; }

        public int Speed { get; set; }
    }
}
