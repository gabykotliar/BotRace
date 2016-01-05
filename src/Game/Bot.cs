namespace BotRace.Game
{
    public interface Bot
    {
        Movement GetMoveRequest();

        void SetCell(Cell currentCell);

        void InvalidMoveResponse();
    }
}
