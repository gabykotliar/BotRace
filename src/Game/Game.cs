using System;
using System.Collections.Generic;

namespace BotRace.Game
{
    public class Game
    {
        private readonly List<Bot> bots;

        private readonly Dictionary<Bot, Position> positions;

        public Game(GameConfig config, Func<string, Bot> botBuilder)
        {
            Maze = config.MazeGenerator.Create(config.MazeSize);
            Grid = Maze.ToJson();                        

            bots = new List<Bot>();
            positions = new Dictionary<Bot, Position>();

            foreach (var botUri in config.BotUris)
            {
                var bot = botBuilder(botUri);
                bots.Add(bot);
                AddBotToMaze(bot);
            }
        }

        private void AddBotToMaze(Bot bot)
        {
            positions.Add(bot, Maze.Home);

            bot.SetCell(Maze.CellAt(Maze.Home));
        }

        private Maze Maze { get; set; }

        public string Grid { get; private set; }

        public int GridSize 
        {
            get { return Maze.Height; }
        }

        public void Go()
        {
            foreach (var bot in bots)
            {
                Movement moveRquest = bot.GetMoveRequest();

                try
                {
                    MoveBot(bot, moveRquest);
                }
                catch (InvalidOperationException)
                {
                    bot.InvalidMoveResponse();
                }                
            }
        }

        private void MoveBot(Bot bot, Movement moveRquest)
        {
            var currentPosition = positions[bot];

            for (int i = 0; i < moveRquest.Speed; i++)
            {                
                var currentCell = Maze.CellAt(currentPosition);

                if (currentCell.HasWall(moveRquest.Direction))
                {
                    throw new InvalidOperationException("Invalid move");
                }

                currentPosition = currentPosition.At(moveRquest.Direction);
            }

            positions[bot] = currentPosition;

            bot.SetCell(Maze.CellAt(currentPosition));
        }
    }
}
