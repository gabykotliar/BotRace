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
        private readonly GameStatus status;

        private RulePipeline GameSetupRules { get; } = new RulePipeline();

        private IEnumerable<TurnRule> TurnRules { get; }

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
            GameSetupRules.Add<TurnsAreRandom>()
                          .Add<EveryoneStartsAtMazeHome>();
        }

        #endregion

        public IGame Setup()
        {
            GameSetupRules.Eval(status);

            return this;
        }

        public void Play()
        {
            foreach (var bot in status.Bots)
            {
                Movement moveRquest = bot.Play();

                try
                {
                    //MoveBot(bot, moveRquest);
                }
                catch (InvalidOperationException)
                {
                   // bot.InvalidMoveResponse();
                }
            }
        }

        //private void MoveBot(Bot bot, Movement moveRquest)
        //{
        //    //var currentPosition = positions[bot];

        //    //for (int i = 0; i < moveRquest.Speed; i++)
        //    //{                
        //    //    var currentCell = Maze.CellAt(currentPosition);

        //    //    if (currentCell.HasWall(moveRquest.Direction))
        //    //    {
        //    //        throw new InvalidOperationException("Invalid move");
        //    //    }

        //    //    currentPosition = currentPosition.At(moveRquest.Direction);
        //    //}

        //    //positions[bot] = currentPosition;

        //    //bot.SetCell(Maze.CellAt(currentPosition));
        //}
    }
}
