using System.Collections.Specialized;

namespace BotRace.Game
{
    public interface MazeGenerator
    {
        Maze Create(int size);
    }
}
