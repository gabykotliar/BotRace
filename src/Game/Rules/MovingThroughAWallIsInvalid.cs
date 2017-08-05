using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class MovingThroughAWallIsInvalid : TurnRule
    {
        public override ActionResult Evaluate(GameStatus status, Action action)
        {
            var currentPosition = status.Positions[action.Bot];

            for (int i = 0; i < action.Movement.Speed; i++)
            {
                var currentCell = status.Maze.CellAt(currentPosition);

                if (currentCell.HasWall(action.Movement.Direction))
                {
                    return new InvalidAction { Reason = $"You can't move {action.Movement.Speed} in the {action.Movement.Direction} because there is a wall in your way." };
                }

                currentPosition = currentPosition.At(action.Movement.Direction);
            }

            return EvaluateNext(status, action);
        }
    }
}
