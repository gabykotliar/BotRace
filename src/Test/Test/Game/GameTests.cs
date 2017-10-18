using System;
using System.Linq;
using System.Linq.Expressions;
using BotRace.Game;
using BotRace.Game.Mazes;
using BotRace.Game.Mazes.Imp;
using BotRace.Game.Rules;
using BotRace.Game.Runtime;
using BotRace.Test;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Test.Game
{
    public class GameTests
    {
        readonly IFactory factory = new Factory(new RecursiveBacktrackingMazeGenerator());

        private readonly ITestOutputHelper output;

        public GameTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private IGame CreateStubGame()
        {
            var mazeStub = new MazeStub();

            return factory.CreateGame(new GameConfig(new[] { new Mock<IBot>().Object },
                                                     mazeStub));
        }

        [Fact]
        public void AGameCanBeCreated()
        {
            var mazeStub = new MazeStub();

            var g = factory.CreateGame(new GameConfig(new[] { new Mock<IBot>().Object }, 
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

            bot.SetupSequence(b => b.Play())
                   .Returns(new Movement(Direction.E))
                   .Returns(new Movement(Direction.E))
                   .Returns(new Movement(Direction.S));

            bot.Setup(b => b.PlayResult(It.IsAny<ActionResult>()));

            Expression<Action<IBot>> endGameCall = b => b.GameResult(
                                                                    It.Is<FinalStatus>(s => s.Winners.Contains(bot.Object))
                                                                    );

            bot.Setup(endGameCall).Verifiable();

            #endregion

            var gameConfig = new GameConfig(new[] { bot.Object }, GetMaze());

            var game = factory.CreateGame(gameConfig);

            //TODO: Create proper test for the event
            ((BotRace.Game.Game)game).GameEvent += (o, args) =>
            {
                // TODO: draw bots in maze
                output.WriteLine(MazeHelper.Draw(args.GameStatus));
            };

            game.Setup();
            game.Play();

            bot.Verify(b => b.Play()); // Direction.E
            bot.Verify(b => b.PlayResult(It.Is<ActionResult>(r => r.Events.Any(e => e is PositionChanged))));

            bot.Verify(b => b.Play()); // Direction.E
            bot.Verify(b => b.PlayResult(It.Is<ActionResult>(r => r.Events.Any(e => e is WallHit))));

            bot.Verify(b => b.Play()); // Direction.S
            bot.Verify(b => b.PlayResult(It.Is<ActionResult>(r => r.Events.Any(e => e is PositionChanged))));

            bot.Verify(endGameCall);
        }

        private IMaze GetMaze()
        {
            //  ___ 
            // |_  |
            // |_|_|
            
            var maze = Maze.ClosedGrid(2);

            maze.Carve(new Position(0, 0), Direction.E);
            maze.Carve(new Position(0, 1), Direction.S);

            return maze;
        }
    }
}
