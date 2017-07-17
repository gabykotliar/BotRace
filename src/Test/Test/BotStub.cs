using System;
using BotRace.Game;
using BotRace.Game.Runtime;

namespace Test
{
    internal class BotStub : Bot
    {
        public Movement Play()
        {
            throw new NotImplementedException();
        }

        public void SetCell(Cell currentCell)
        {
            throw new NotImplementedException();
        }

        public void InvalidMoveResponse()
        {
            throw new NotImplementedException();
        }
    }
}
