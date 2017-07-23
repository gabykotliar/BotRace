namespace BotRace.Game
{
    public interface IMaze
    {
        int Width { get; }

        int Height { get; }

        ICell CellAt(IPosition position);

        string ToJson();

        IPosition Home { get; }

        IPosition Exit { get; }
    }
}
