using BotRace.Game.Mazes;
using BotRace.Game.Runtime;

namespace BotRace.Game
{
    public interface IFactory
    {
        IGame CreateGame(GameConfig config);

        IMaze CreateMaze(int size);
    }
}
