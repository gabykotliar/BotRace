using System.Collections.Generic;

namespace BotRace.Game
{
    public class GameConfig
    {
        public List<string> BotUris { get; set; }

        public MazeGenerator MazeGenerator { get; set; }

        public int MazeSize { get; set; }
    }
}
