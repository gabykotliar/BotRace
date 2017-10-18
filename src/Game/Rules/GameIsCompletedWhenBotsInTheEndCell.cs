using System.Linq;

using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class GameIsCompletedWhenBotsInTheEndCell : StageRule
    {
        public override GameStatus Evaluate(GameStatus status)
        {
            var botsAtExitCell = status.Bots.Where(b => status.Positions[b].Equals(status.Maze.Exit)).ToList();

            if (!botsAtExitCell.Any()) return status;

            return new FinalStatus(status)
            {
                Winners = botsAtExitCell
            };
        }
    }
}
