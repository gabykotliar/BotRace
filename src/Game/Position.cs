namespace BotRace.Game
{
    public interface Position
    {
        /// <summary>
        /// Column reference numbered from West to East
        /// </summary>
        int Column { get; }

        /// <summary>
        /// Row reference numbered from Nort to South
        /// </summary>
        int Row { get; }

        Position At(Direction direction);
    }
}