namespace BotRace.Game.Runtime.Rules
{
    public class NullRule : Rule
    {
        public override Game Evaluate(Game game, Bot bot)
        {
            return EvaluateNext(game, bot);
        }
    }
}