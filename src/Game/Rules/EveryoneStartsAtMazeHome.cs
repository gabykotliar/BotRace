using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class EveryoneStartsAtMazeHome : StageRule
    {
        public override GameStatus Evaluate(GameStatus status)
        {
            var home = status.Maze.Home;

            foreach (var bot in status.Bots)
            {
                status.Positions[bot] = home;
            }

            return EvaluateNext(status);
        }
    }
}