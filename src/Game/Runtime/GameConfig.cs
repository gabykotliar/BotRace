using System.Collections.Generic;

namespace BotRace.Game.Runtime
{
    public class GameConfig
    {
        public IEnumerable<IBot> Bots { get; set; }

        public IMaze Maze { get; set; }

        public GameConfig(IEnumerable<IBot> bots, IMaze maze)
        {
            Bots = bots;
            Maze = maze;
        }
    }
}
