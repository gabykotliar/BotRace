using System;
using BotRace.Game;
using BotRace.Game.Runtime;
using BotRace.Game.Runtime.Rules;

using IGame = BotRace.Game.Runtime.Game;

namespace GameImpl.Runtime
{
    public class Game : IGame
    {
        private GameStatus status;

        private StageRulePipeline SetupRules { get; } = new StageRulePipeline();

        private TurnRulePipeline TurnRules { get; } = new TurnRulePipeline();

        private StageRulePipeline EndTurnRules { get; } = new StageRulePipeline();

        #region Constructor

        public Game(GameConfig config)
        {
            status = new GameStatus
            {
                Bots = config.Bots,
                Maze = config.Maze
            };

            SetupGameRules();
        }

        private void SetupGameRules()
        {
            SetupRules.Add<TurnsAreRandom>()
                               .Add<EveryoneStartsAtMazeHome>();

            TurnRules.Add<MovingThroughAWallIsInvalid>()
                     .Add<Move>();
        }

        #endregion

        public IGame Setup()
        {
            status = SetupRules.Eval(status);

            return this;
        }

        public void Play()
        {
            do
            {
                foreach (var bot in status.Bots)
                {
                    PlayPlayerTurn(bot);
                }

                status = EndTurnRules.Eval(status);

            } while (!(status is EndStatus));

            EndGame();
        }

        private void EndGame()
        {
            //bot.PlayResult(status);
        }

        private void PlayPlayerTurn(Bot bot)
        {
            var actionRquest = bot.Play();

            var action = new BotRace.Game.Runtime.Action { Bot = bot, Movement = actionRquest };

            var actionResponse = TurnRules.Eval(status, action);
            
            //bot.PlayResult(actionResponse);
        }
    }
}
