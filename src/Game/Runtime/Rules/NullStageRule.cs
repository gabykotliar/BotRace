namespace BotRace.Game.Runtime.Rules
{
    public class NullStageRule : StageRule
    {
        public override GameStatus Evaluate(GameStatus status)
        {
            return EvaluateNext(status);
        }
    }
}