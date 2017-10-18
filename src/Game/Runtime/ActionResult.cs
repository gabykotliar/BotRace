using System;
using System.Collections.Generic;

namespace BotRace.Game.Runtime
{
    public class Event
    {
        public string Message { get; protected set; }

        public Event()
        {
        }

        public Event(string message)
        {
            Message = message;
        }
    }

    public class ActionResult
    {
        public GameStatus Status { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}