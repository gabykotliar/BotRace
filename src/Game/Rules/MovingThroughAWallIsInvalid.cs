using BotRace.Game.Mazes;
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
                    return new ActionResult
                    {
                        Status = status,
                        Events = { new WallHit(action.Movement.Speed, action.Movement.Direction) }
                    };
                }

                currentPosition = currentPosition.At(action.Movement.Direction);
            }

            return EvaluateNext(status, action);
        }
    }

    public class WallHit : Event
    {
        public WallHit(int originalSpeed, Direction originalDirection) 
        {
            Message = $"You can't move {originalSpeed} in the {originalDirection} because there is a wall in your way.";
        }
    }
}
