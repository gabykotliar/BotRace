using BotRace.Game.Mazes;
using BotRace.Game.Rules;
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
            var game = new Game(config);

            game.GameStartRules = new StageRulePipeline()
                .Add<TurnsAreRandom>()
                .Add<EveryoneStartsAtMazeHome>(); 

            game.TurnRules = new TurnRulePipeline()
                .Add<MovingThroughAWallIsInvalid>()
                .Add<Move>();

            game.TurnEndRules = new StageRulePipeline()
                .Add<GameIsCompletedWhenBotsInTheEndCell>();

            return game;
        }

        public IMaze CreateMaze(int size)
        {
            return MazeGenerator.Create(size);
        }
    }
}
