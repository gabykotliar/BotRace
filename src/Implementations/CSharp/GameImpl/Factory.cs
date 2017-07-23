using BotRace.Game;
using BotRace.Game.Implementation;
using BotRace.Game.Runtime;

using GameImpl.Runtime;

namespace GameImpl
{
    public class Factory : IFactory
    {
        internal IMazeGenerator MazeGenerator { get; set; }

        public Factory()
        {
            MazeGenerator = new RecursiveBacktrackingMazeGenerator();
        }

        public IGame CreateGame(GameConfig config)
        {
            return new Game(config);
        }

        public IMaze CreateMaze(int size)
        {
            return MazeGenerator.Create(size);
        }
    }
}
