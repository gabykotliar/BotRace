using System;
using BotRace.Game;
using BotRace.Game.Implementation;
using BotRace.Game.Runtime;
using IBot = BotRace.Game.Bot;
using Xunit;

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
            MazeGenerator mg = new RecursiveBacktrackingMazeGenerator();

            var maze = mg.Create(2);

            var bot = new Moq.Mock<IBot>();
            bot.Setup(b => b.Play()).Returns(new Movement(Direction.E));

            var bots = new[] { bot.Object };

            var gameConfig = new GameConfig(bots, maze);

            var g = factory.CreateGame(gameConfig);

            g.Setup();

            g.Play();
        }
        //TODO: Continue here
        public BotRace.Game.Maze GetMaze()
        {
            var cg = BotRace.Game.Implementation.Maze.ClosedGrid(2);
        }

    }
}
