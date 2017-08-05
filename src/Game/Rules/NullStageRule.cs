using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class NullStageRule : StageRule
    {
        public override GameStatus Evaluate(GameStatus status)
        {
            return EvaluateNext(status);
        }
    }
}