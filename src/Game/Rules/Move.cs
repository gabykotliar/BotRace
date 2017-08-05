using BotRace.Game.Runtime;

namespace BotRace.Game.Rules
{
    public class Move : TurnRule
    {
        public override ActionResult Evaluate(GameStatus status, Action action)
        {
            var currentPosition = status.Positions[action.Bot];

            for (int i = 0; i < action.Movement.Speed; i++)
            {
                currentPosition = currentPosition.At(action.Movement.Direction);
            }

            status.Positions[action.Bot] = currentPosition;

            return null;
        }
    }
}