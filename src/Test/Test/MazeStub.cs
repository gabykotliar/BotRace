using System;
using BotRace.Game;
using BotRace.Game.Mazes;

namespace Test
{
    internal class MazeStub : IMaze
    {
        public int Width { get; }

        public int Height { get; }

        public IPosition Home { get; }

        public IPosition Exit { get; }

        public ICell CellAt(IPosition position)
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
