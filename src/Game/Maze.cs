namespace BotRace.Game
{
    public interface Maze
    {
        int Width { get; }

        int Height { get; }

        Cell CellAt(Position position);

        string ToJson();

        Position Home { get; }

        Position Exit { get; }
    }
}
