using System.Collections.Generic;

namespace BotRace.Game.Runtime.Rules
{
    public class GameIsCompletedWhenBotsInTheEndCell : StageRule
    {
        List<Bot> winners = new List<Bot>();

        public override GameStatus Evaluate(GameStatus status)
        {
            return new EndStatus(status);
        }
    }
}
