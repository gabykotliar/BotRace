using BotRace.Game.Runtime;

namespace BotRace.Game
{
    public interface Bot
    {
        Movement Play();
        void PlayResult(ActionResult actionResponse);
        void GameResult(GameStatus status);
    }
}
