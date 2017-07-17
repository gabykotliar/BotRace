namespace BotRace.Game.Runtime.Rules
{
    public abstract class StageRule
    {
        internal StageRule Next { get; set; }

        public abstract GameStatus Evaluate(GameStatus status);

        protected GameStatus EvaluateNext(GameStatus status)
        {
            return Next == null
                ? status
                : Next.Evaluate(status);
        }
    }
}
