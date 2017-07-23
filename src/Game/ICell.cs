namespace BotRace.Game
{
    public interface ICell
    {        
        bool HasWall(Direction direction);

        ICell Carve(Direction direction);

        bool IsClosed();
    }
}
