using BotRace.Game.Runtime;

namespace BotRace.Game
{
    public interface IBot
    {
        Movement Play();

        void PlayResult(ActionResult actionResponse);

        void GameResult(GameStatus status);
    }
}
