﻿using System.Collections.Generic;

namespace BotRace.Game.Runtime
{
    public class GameStatus
    {
        protected IEnumerable<Bot> bots;

        public Dictionary<Bot, Position> Positions { get; private set; }

        public IEnumerable<Bot> Bots
        {
            get => bots;
            set
            {
                bots = value;

                Positions = new Dictionary<Bot, Position>();

                foreach (var bot in bots)
                {
                    Positions.Add(bot, null);
                }
            }
        }

        public Maze Maze { get; set; }
    }

    public class EndStatus : GameStatus
    {
        public EndStatus(GameStatus status)
        {
            this.bots = status.Bots;
            //etc.
        }
    }
}
