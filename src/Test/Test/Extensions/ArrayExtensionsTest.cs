using System.Linq;

using System;
using System.Collections.Generic;
using Xunit;

using BotRace.Game;
using BotRace.Game.Mazes;
using BotRace.Game.Mazes.Imp;

namespace BotRace.Test.CSharp.Extensions
{
    public class ArrayExtensionsTest
    {
        [Fact]
        public void ShuffleShouldShoufleTest()
        {
            var ordered = new[] { 1, 2, 3, 4, 5 };

            var shuffled = ordered.Shuffle();

            var isOrdered = true;

            for (int i = 0; i < ordered.Length; i++)
            {
                isOrdered &= (ordered[i] == shuffled[i]);
            }

            Assert.False(isOrdered, "Items should not be in the same position");

            Assert.Equal(ordered.Length, shuffled.Length);
                //"Array should have the same length"

            foreach (var item in ordered)
            {
                Assert.True(shuffled.Contains(item), "All items should exist in the resulting array");
            }
        }

        [Fact(Skip = "if runned this should be checked visualy")]
        public void DirectionsShoufleQuality()
        {
            for (int i = 0; i < 15; i++)
            {
                PrintDirectionArray(new[] { Direction.N, Direction.E, Direction.S, Direction.W }.Shuffle());    
            }
        }

        private void PrintDirectionArray(IEnumerable<Direction> arr)
        {
            foreach (var direction in arr)
            {
                Console.Write(direction + " ");
            }

            Console.WriteLine();
        }
    }
}
