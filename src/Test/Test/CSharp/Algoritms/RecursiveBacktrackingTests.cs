using System;

using BotRace.Game.Implementation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotRace.Test.CSharp.Algoritms
{
    [TestClass]
    public class RecursiveBacktrackingTests
    {
        [TestMethod]
        public void GenerateMaze()
        {
            var mg = new RecursiveBacktrackingMazeGenerator();

            var m = mg.Create(20);

            Console.Write(MazeHelper.Draw(m));
        }
    }
}
