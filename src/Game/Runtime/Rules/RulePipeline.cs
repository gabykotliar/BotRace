using System;
using System.Linq;
using System.Collections.Generic;

namespace BotRace.Game.Runtime.Rules
{
    internal class RulePipeline
    {
        private readonly List<Rule> rules = new List<Rule>();

        public void Add<T>() where T : Rule, new()
        {
            var rule = new T();

            if (rules.Any()) rules.Last().Next = rule;

            rules.Add(rule);
        }

        public void Eval()
        {
            rules.First().Evaluate(null);
        }
    }
}
