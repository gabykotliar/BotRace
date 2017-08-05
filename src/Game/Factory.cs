using BotRace.Game.Mazes;
using BotRace.Game.Runtime;

namespace BotRace.Game
{
    public class Factory : IFactory
    {
        private IMazeGenerator MazeGenerator { get; }

        public Factory(IMazeGenerator mazeGenerator)
        {
            MazeGenerator = mazeGenerator;
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
