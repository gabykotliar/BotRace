using BotRace.Game.Runtime;

namespace BotRace.Game.Implementation
{
    public class Bot : BotRace.Game.Bot
    {
        private string uri;

        public Bot(string uri)
        {
            this.uri = uri;
        }

        public Movement Play()
        {
            return new Movement(Direction.W);
        }

        public void InvalidMoveResponse()
        {
            throw new System.NotImplementedException();
        }
    }
}
