using BotRace.Game.Runtime;

namespace BotRace.Game
{
    public interface IFactory
    {
        Runtime.IGame CreateGame(GameConfig config);

        IMaze CreateMaze(int size);
    }
}
