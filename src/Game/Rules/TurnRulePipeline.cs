using System.Collections.Generic;
using System.Linq;
using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class TurnRulePipeline
    {
        private readonly List<TurnRule> rules = new List<TurnRule>();

        public TurnRulePipeline Add<T>() where T : TurnRule, new()
        {
            var rule = new T();

            if (rules.Any()) rules.Last().Next = rule;

            rules.Add(rule);

            return this;
        }

        public ActionResult Eval(GameStatus status, Action action)
        {
            if (!rules.Any()) return new ActionResult { Status = status };

            return rules.First().Evaluate(status, action);
        }
    }
}