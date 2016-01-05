namespace BotRace.Game
{
    public interface Cell
    {        
        bool HasWall(Direction direction);

        Cell Carve(Direction direction);

        bool IsClosed();
    }
}
