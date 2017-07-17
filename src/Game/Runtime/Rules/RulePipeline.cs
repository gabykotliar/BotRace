using System.Linq;
using System.Collections.Generic;

namespace BotRace.Game.Runtime.Rules
{
    public class RulePipeline
    {
        private readonly List<StageRule> rules = new List<StageRule>();

        public RulePipeline Add<T>() where T : StageRule, new()
        {
            var rule = new T();

            if (rules.Any()) rules.Last().Next = rule;

            rules.Add(rule);

            return this;
        }

        public GameStatus Eval(GameStatus status)
        {
            if (!rules.Any()) return status;

            return rules.First().Evaluate(status);
        }
    }
}
