using System;
using System.Linq;

namespace BotRace.Game.Mazes.Imp
{
    internal static class ArrayExtensions
    {
        private static Random rnd;

        static ArrayExtensions()
        {
            rnd = new Random();
        }

        internal static T[] Shuffle<T>(this T[] array)
        {
            return array.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}
