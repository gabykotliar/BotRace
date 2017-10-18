using System;
using BotRace.Game.Mazes.Imp;
using Xunit;
using Xunit.Abstractions;

namespace BotRace.Test.CSharp.Algoritms
{
    public class RecursiveBacktrackingTests
    {
        private readonly ITestOutputHelper output;

        public RecursiveBacktrackingTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GenerateMaze()
        {
            var mg = new RecursiveBacktrackingMazeGenerator();

            var m = mg.Create(20);

            output.WriteLine(MazeHelper.Draw(m));
        }
    }
}
