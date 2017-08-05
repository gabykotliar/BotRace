using System.Collections.Generic;
using System.Linq;
using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class StageRulePipeline 
    {
        private readonly List<StageRule> rules = new List<StageRule>();

        public StageRulePipeline Add<T>() where T : StageRule, new()
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
