using System.Collections.Generic;

namespace BotRace.Game.Runtime
{
    public class GameStatus
    {
        private Dictionary<Bot, Position> Positions { get; set; }

        public IEnumerable<Bot> Bots { get; set; }

        public Maze Maze { get; set; }

        public Position PositionOf(Bot bot)
        {
            return Positions.ContainsKey(bot) 
                    ? Positions[bot] 
                    : null;
        }
    }
}
