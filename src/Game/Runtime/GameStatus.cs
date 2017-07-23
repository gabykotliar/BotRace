using System.Collections.Generic;

namespace BotRace.Game.Runtime
{
    public class GameStatus 
    {
        protected IEnumerable<IBot> bots;

        public Dictionary<IBot, IPosition> Positions { get; protected set; }

        public IEnumerable<IBot> Bots
        {
            get => bots;
            set
            {
                bots = value;

                Positions = new Dictionary<IBot, IPosition>();

                foreach (var bot in bots)
                {
                    Positions.Add(bot, null);
                }
            }
        }

        public IMaze Maze { get; set; }
    }

    public class FinalStatus : GameStatus
    {
        public IEnumerable<IBot> Winners { get; set; }

        public FinalStatus(GameStatus status)
        {
            bots = status.Bots;
            Positions = status.Positions;
            Maze = status.Maze;
        }
    }
}
