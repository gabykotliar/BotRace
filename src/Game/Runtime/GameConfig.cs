using System.Collections.Generic;

namespace BotRace.Game
{
    public class GameConfig
    {
        public IEnumerable<Bot> Bots { get; set; }

        public Maze Maze { get; set; }

        public GameConfig(IEnumerable<Bot> bots, Maze maze)
        {
            Bots = bots;
            Maze = maze;
        }
    }
}
