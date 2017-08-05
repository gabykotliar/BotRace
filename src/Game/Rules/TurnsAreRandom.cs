using System;
using System.Linq;
using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class TurnsAreRandom : StageRule
    {
        private static readonly Random Rnd;

        static TurnsAreRandom()
        {
            Rnd = new Random();
        }

        public override GameStatus Evaluate(GameStatus status)
        {
            status.Bots = status.Bots.ToArray().OrderBy(x => Rnd.Next()).ToArray();

            return EvaluateNext(status);
        }
    }
}