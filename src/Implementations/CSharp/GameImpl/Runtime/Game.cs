using System;
using System.Collections.Generic;
using BotRace.Game;
using BotRace.Game.Runtime;
using BotRace.Game.Runtime.Rules;

using IGame = BotRace.Game.Runtime.Game;

namespace GameImpl.Runtime
{
    public class Game : IGame
    {
        private GameStatus status;

        private StageRulePipeline GameSetupStageRules { get; } = new StageRulePipeline();

        private TurnRulePipeline TurnRules { get; } = new TurnRulePipeline();

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
            GameSetupStageRules.Add<TurnsAreRandom>()
                               .Add<EveryoneStartsAtMazeHome>();

            TurnRules.Add<MovingThroughAWallIsInvalid>()
                     .Add<Move>();
        }

        #endregion

        public IGame Setup()
        {
            status = GameSetupStageRules.Eval(status);

            return this;
        }

        public void Play()
        {
            foreach (var bot in status.Bots)
            {
                var actionRquest = bot.Play();

                var action = new BotRace.Game.Runtime.Action { Bot = bot, Movement = actionRquest };

                var actionResponse = TurnRules.Eval(status, action);

                //bot.PlayResult(actionResponse);
            }
        }
    }
}
