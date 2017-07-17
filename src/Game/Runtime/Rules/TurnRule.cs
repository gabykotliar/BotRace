namespace BotRace.Game.Runtime.Rules
{
    public abstract class TurnRule
    {
        internal TurnRule Next { get; set; }

        public abstract ActionResult Evaluate(GameStatus status, Action action);

        protected ActionResult EvaluateNext(GameStatus status, Action action)
        {
            return Next == null
                ? new ActionResult { Status = status }
                : Next.Evaluate(status, action);
        }
    }
}