using System.Linq;

using BotRace.Game;
using BotRace.Game.Implementation.CSharp.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotRace.Test.CSharp.Extensions
{
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class ArrayExtensionsTest
    {
        [TestMethod]
        public void ShuffleShouldShoufleTest()
        {
            var ordered = new[] { 1, 2, 3, 4, 5 };

            var shuffled = ordered.Shuffle();

            var isOrdered = true;

            for (int i = 0; i < ordered.Length; i++)
            {
                isOrdered &= (ordered[i] == shuffled[i]);
            }

            Assert.IsFalse(isOrdered, "Items should not be in the same position");

            Assert.AreEqual(ordered.Length, shuffled.Length, "Array lengths should be the same");

            foreach (var item in ordered)
            {
                Assert.IsTrue(shuffled.Contains(item), "All items should exist in the resulting array");
            }
        }

        [TestMethod]
        public void DirectionsShoufleQuality()
        {
            for (int i = 0; i < 15; i++)
            {
                this.PrintDirectionArray(new[] { Direction.N, Direction.E, Direction.S, Direction.W }.Shuffle());    
            }

            Assert.Inconclusive("if runned this should be checked visualy");
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
