namespace BotRace.Game
{
    public enum Direction
    {
        W = 1,
        S = 2,
        E = 4,
        N = 8,
        All = 15
    }

    public static class DirectionExtensions
    {
        public static Direction Oposite(this Direction direction)
        {
            var orig = (int)direction;

            return (Direction)(orig > 2 
                                   ? orig >> 2 
                                   : orig << 2);
        }
    }
}
