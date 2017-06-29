namespace BotRace.Game.Runtime.Rules
{
    public abstract class Rule
    {
        internal Rule Next { get; set; }

        public abstract Game Evaluate(Game game, Bot bot);

        protected Game EvaluateNext(Game game, Bot bot)
        {
            return Next == null
                ? game
                : Next.Evaluate(game, bot);
        }
    }
}
