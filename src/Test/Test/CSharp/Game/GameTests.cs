using System;
using BotRace.Game;

using Xunit;

namespace Test.CSharp.Game
{
    public class GameTests
    {
        readonly Factory factory = new GameImpl.Factory();

        private BotRace.Game.Runtime.Game CreateStubGame()
        {
            var mazeStub = new MazeStub();

            return factory.CreateGame(new GameConfig(new[] { new BotStub() },
                                                     mazeStub));
        }

        [Fact]
        public void AGameCanBeCreated()
        {
            var mazeStub = new MazeStub();

            var g = factory.CreateGame(new GameConfig(new[] { new BotStub() }, 
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
        public void ANeedsToBeSetupBeforePlayed()
        {
            var g = CreateStubGame();

            Assert.ThrowsAny<Exception>(() => g.Play());
        }
    }
}
