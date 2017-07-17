using BotRace.Game;
using BotRace.Game.Implementation;
using BotRace.Game.Runtime;

using Maze = BotRace.Game.Maze;

namespace GameImpl
{
    public class Factory : BotRace.Game.Factory
    {
        internal MazeGenerator MazeGenerator { get; set; }

        public Factory()
        {
            MazeGenerator = new RecursiveBacktrackingMazeGenerator();
        }

        public Game CreateGame(GameConfig config)
        {
            return new Runtime.Game(config);
        }

        public Maze CreateMaze(int size)
        {
            return MazeGenerator.Create(size);
        }
    }
}
