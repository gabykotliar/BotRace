namespace BotRace.Game.Implementation
{
    public class Bot : BotRace.Game.Bot
    {
        private string uri;

        public Bot(string uri)
        {
            this.uri = uri;
        }

        public Movement GetMoveRequest()
        {
            return new Movement(Direction.W);
        }

        public void SetCell(BotRace.Game.Cell currentCell)
        {
            throw new System.NotImplementedException();
        }

        public void InvalidMoveResponse()
        {
            throw new System.NotImplementedException();
        }
    }
}
