using System;
using System.Collections.Generic;
using System.Text;
using BotRace.Game;
using BotRace.Game.Implementation;
using Xunit;

namespace Test.CSharp
{
    public class FactoryTests
    {
        Factory factory = new GameImpl.Factory();

        [Fact]
        public void ICanCreateAGame()
        {
            factory.CreateGame(new GameConfig(new[] { new BotStub() }, 
                                              new MazeStub()));


        }
    }
}
