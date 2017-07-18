using System.Collections.Generic;

using BotRace.Game.Implementation;
using BotRace.Game.Runtime;
using BotRace.Game.Runtime.Rules;

using Xunit;

using IMaze = BotRace.Game.Maze;

namespace Test.CSharp.Game.Rules
{
    public class EveryoneStartsAtMazeHomeTests
    {
        [Fact]
        public void EvaluatingTheRuleSetsEveryBotAtHomeCell()
        {
            var mm = new Moq.Mock<IMaze>();

            var home = new Position(0, 0);
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

            // on new game status there are no positions set
            Assert.All(gs.Bots, b => Assert.Null(gs.Positions[b]));

            var ngs = new EveryoneStartsAtMazeHome().Evaluate(gs);

            Assert.All(ngs.Bots, b => Assert.Equal(gs.Maze.Home, ngs.Positions[b]));
        }
    }
}
