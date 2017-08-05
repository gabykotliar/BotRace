﻿using BotRace.Game.Rules;
using BotRace.Game.Runtime;

namespace BotRace.Game
{
    public class Game : IGame
    {
        private GameStatus status;

        private StageRulePipeline GameStartRules { get; } = new StageRulePipeline();

        private TurnRulePipeline TurnRules { get; } = new TurnRulePipeline();

        private StageRulePipeline TurnEndRules { get; } = new StageRulePipeline();

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
            GameStartRules.Add<TurnsAreRandom>()
                          .Add<EveryoneStartsAtMazeHome>();

            TurnRules.Add<MovingThroughAWallIsInvalid>()
                     .Add<Move>();

            TurnEndRules.Add<GameIsCompletedWhenBotsInTheEndCell>();
        }

        #endregion

        public IGame Setup()
        {
            status = GameStartRules.Eval(status);

            return this;
        }

        public void Play()
        {
            do
            {
                foreach (var bot in status.Bots)
                {
                    PlayerTurn(bot);
                }

                status = TurnEndRules.Eval(status);

            } while (!(status is FinalStatus));

            EndGame();
        }

        private void PlayerTurn(IBot bot)
        {
            var actionRquest = bot.Play();

            var action = new Action { Bot = bot, Movement = actionRquest };

            var actionResponse = TurnRules.Eval(status, action);

            bot.PlayResult(actionResponse);
        }

        private void EndGame()
        {
            foreach (var bot in status.Bots)
            {
                bot.GameResult(status);
            }
        }
    }
}