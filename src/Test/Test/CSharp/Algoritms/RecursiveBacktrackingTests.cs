using System;
#if _FSHARP_IMPL
using BotRace.Game.Implementation.FSharp;
#else
using BotRace.Game.Implementation.CSharp;
#endif

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
