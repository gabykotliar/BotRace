using System;
using BotRace.Game.Rules;
using BotRace.Game.Runtime;
using Action = BotRace.Game.Runtime.Action;

namespace BotRace.Game
{

    public class GameEventArgs : EventArgs
    {
        public GameEventArgs(GameStatus gameStatus)
        {
            GameStatus = gameStatus;
        }

        public GameStatus GameStatus { get; }
    }

    public delegate void GameEventHandler(object sender, GameEventArgs a);


    public class Game : IGame
    {
        public event GameEventHandler GameEvent;

        private GameStatus status;

        internal StageRulePipeline GameStartRules { private get; set; }

        internal TurnRulePipeline TurnRules { private get; set; }

        internal StageRulePipeline TurnEndRules { private get; set; }

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
            
        }

        #endregion

        public IGame Setup()
        {
            status = GameStartRules.Eval(status);

            return this;
        }

        public void Play()
        {
            GameEvent?.Invoke(this, new GameEventArgs(status));

            do
            {
                foreach (var bot in status.Bots)
                {
                    PlayerTurn(bot);

                    GameEvent?.Invoke(this, new GameEventArgs(status));
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
