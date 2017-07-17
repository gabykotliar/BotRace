using System;
using System.Linq;

namespace BotRace.Game.Runtime.Rules
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