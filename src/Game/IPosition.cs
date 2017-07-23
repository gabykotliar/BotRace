namespace BotRace.Game
{
    public interface IPosition
    {
        /// <summary>
        /// Column reference numbered from West to East
        /// </summary>
        int Column { get; }

        /// <summary>
        /// Row reference numbered from Nort to South
        /// </summary>
        int Row { get; }

        IPosition At(Direction direction);
    }
}