using BotRace.Game;
using BotRace.Game.Mazes.Imp;
using BotRace.Game.Runtime;

using Xunit;

namespace Test.CSharp
{
    public class FactoryTests
    {
        IFactory factory = new Factory(new RecursiveBacktrackingMazeGenerator());

        [Fact]
        public void ICanCreateAGame()
        {
            factory.CreateGame(new GameConfig(new[] { new Moq.Mock<IBot>().Object }, 
                                              new MazeStub()));


        }
    }
}
