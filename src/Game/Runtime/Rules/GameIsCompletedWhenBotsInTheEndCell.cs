using System.Collections.Generic;
using System.Linq;

namespace BotRace.Game.Runtime.Rules
{
    public class GameIsCompletedWhenBotsInTheEndCell : StageRule
    {
        List<Bot> winners = new List<Bot>();

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
