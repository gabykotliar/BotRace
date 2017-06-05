using System;

using BotRace.Game.Implementation;
using Xunit;

namespace BotRace.Test.CSharp.Algoritms
{
    public class RecursiveBacktrackingTests
    {
        [Fact]
        public void GenerateMaze()
        {
            var mg = new RecursiveBacktrackingMazeGenerator();

            var m = mg.Create(20);

            Console.Write(MazeHelper.Draw(m));
        }
    }
}
