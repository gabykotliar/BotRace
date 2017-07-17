using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BotRace.Game.Implementation;
using BotRace.Game.Runtime;
using BotRace.Game.Runtime.Rules;
using Xunit;
using IBot = BotRace.Game.Bot;

namespace Test.CSharp.Game.Rules
{
    public class EveryoneStartsAtMazeHomeTests
    {
        [Fact]
        public void EvaluatingTheRuleSetsEveryBotAtHomeCell()
        {
            var rule = new EveryoneStartsAtMazeHome();

            var home = new Position(0, 0);
            var mm = new Moq.Mock<Maze>();

            mm.Setup(m => m.Home).Returns(home);

            var gs = new GameStatus
            {
                Maze = mm.Object,
                Bots = new List<Bot>
                {
                    new Bot(string.Empty),
                    new Bot(string.Empty),
                    new Bot(string.Empty)
                }
            };

            var ngs = rule.Evaluate(gs);

            Assert.All(ngs.Bots, b => Assert.Equal(home, ngs.PositionOf(b)));
        }
    }
}
