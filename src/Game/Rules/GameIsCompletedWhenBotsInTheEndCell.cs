using System.Collections.Generic;
using System.Linq;
using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class GameIsCompletedWhenBotsInTheEndCell : StageRule
    {
        List<IBot> winners = new List<IBot>();

        public override GameStatus Evaluate(GameStatus status)
        {
            var winners = status.Bots.Where(b => status.Positions[b].Equals(status.Maze.Exit));

            if (winners.Any())
            {
                return new FinalStatus(status)
                {
                    Winners = winners                       
                };
            }

            return status;
        }
    }
}
