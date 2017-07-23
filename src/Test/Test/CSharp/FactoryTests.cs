using System;
using System.Collections.Generic;
using System.Text;
using BotRace.Game;
using BotRace.Game.Runtime;
using Xunit;

namespace Test.CSharp
{
    public class FactoryTests
    {
        IFactory factory = new GameImpl.Factory();

        [Fact]
        public void ICanCreateAGame()
        {
            factory.CreateGame(new GameConfig(new[] { new Moq.Mock<IBot>().Object }, 
                                              new MazeStub()));


        }
    }
}
