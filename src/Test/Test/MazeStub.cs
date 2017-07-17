using System;
using BotRace.Game;

namespace Test
{
    internal class MazeStub : Maze
    {
        public int Width { get; }

        public int Height { get; }

        public Position Home { get; }

        public Position Exit { get; }

        public Cell CellAt(Position position)
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
