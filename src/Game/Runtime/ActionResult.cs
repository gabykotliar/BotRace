using System;

namespace BotRace.Game.Runtime
{
    public class ActionResult
    {
        public GameStatus Status { get; set; }
    }

    public class InvalidAction : ActionResult
    {
        public string Reason { get; set; }
    }

    public class NewPosition
    {
        public GameStatus Status { get; set; }
    }
}