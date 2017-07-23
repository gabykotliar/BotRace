﻿using System;
using BotRace.Game;
using BotRace.Game.Implementation;
using BotRace.Game.Runtime;
using IBot = BotRace.Game.Bot;
using IPosition = BotRace.Game.Position;
using Position = BotRace.Game.Implementation.Position;
using Xunit;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Linq.Expressions;

namespace Test.CSharp.Game
{
    public class GameTests
    {
        readonly Factory factory = new GameImpl.Factory();

        private BotRace.Game.Runtime.Game CreateStubGame()
        {
            var mazeStub = new MazeStub();

            return factory.CreateGame(new GameConfig(new[] { new Moq.Mock<IBot>().Object },
                                                     mazeStub));
        }

        [Fact]
        public void AGameCanBeCreated()
        {
            var mazeStub = new MazeStub();

            var g = factory.CreateGame(new GameConfig(new[] { new Moq.Mock<IBot>().Object }, 
                                                      mazeStub));

            Assert.NotNull(g);
        }

        [Fact]
        public void AGameCanBeSetup()
        {
            var g = CreateStubGame();

            g.Setup();
        }

        [Fact]
        public void AGameCanBePlayed()
        {
            var g = CreateStubGame();

            g.Setup()
             .Play();
        }

        [Fact]
        public void AGameNeedsToBeSetupBeforePlayed()
        {
            var g = CreateStubGame();

            Assert.ThrowsAny<Exception>(() => g.Play());
        }

        [Fact]
        public void GameIntegrationTest()
        {
            #region Setup bot mock

            var bot = new Mock<IBot>();
            
            bot.Setup(b => b.Play())
               .Returns(new Queue<Movement>(new[] 
                            {
                                new Movement(Direction.E),
                                new Movement(Direction.S)
                            }
                        ).Dequeue)
                .Verifiable();

            // alternaltive setup to the queue
            // bot.SetupSequence(b => b.Play())
            //        .Returns(new Movement(Direction.E))
            //        .Returns(new Movement(Direction.S));

            bot.Setup(b => b.PlayResult(It.IsAny<ActionResult>()));

            Expression<Action<IBot>> endGameCall = b => b.GameResult(
                                                                    It.Is<FinalStatus>(s => s.Winners.Contains(bot.Object))
                                                                    );

            bot.Setup(endGameCall).Verifiable();

            #endregion

            var gameConfig = new GameConfig(new[] { bot.Object }, GetMaze());

            var game = factory.CreateGame(gameConfig);
            game.Setup();
            game.Play();

            bot.Verify(b => b.Play(), Times.Exactly(2));
            bot.Verify(endGameCall);
        }

        public BotRace.Game.Maze GetMaze()
        {
            var maze = BotRace.Game.Implementation.Maze.ClosedGrid(2);

            maze.Carve(new Position(0, 0), Direction.E);
            maze.Carve(new Position(0, 1), Direction.S);

            return maze;
        }
    }
}
