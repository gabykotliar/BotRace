using System;
using System.Collections.Generic;
using System.Text;

namespace BotRace.Game
{
    public interface Factory
    {
        Runtime.Game CreateGame(GameConfig config);

        Maze CreateMaze(int size);
    }
}
