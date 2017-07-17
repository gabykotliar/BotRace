namespace BotRace.Game.Runtime.Rules
{
    public class EveryoneStartsAtMazeHome : StageRule
    {
        public override GameStatus Evaluate(GameStatus status)
        {
            foreach (var bot in status.Bots)
            {
                bot.SetCell(status.Maze.CellAt(status.Maze.Home));
            }

            return EvaluateNext(status);
        }
    }
}