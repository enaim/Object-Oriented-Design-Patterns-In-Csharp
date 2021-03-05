using System;

namespace TemplatePattern
{
    abstract class Game
    {
        public abstract void Initialize();
        public abstract void StartPlay();
        public abstract void EndPlay();
        
        public void Play()
        {
            Initialize();
            StartPlay();
            EndPlay();
        }
    }

    class Cricket : Game
    {
        public override void Initialize()
        {
            Console.WriteLine("Cricket Game Initialized! Start playing.");
        }

        public override void StartPlay()
        {
            Console.WriteLine("Cricket Game Started. Enjoy the game!");
        }
        public override void EndPlay()
        {
            Console.WriteLine("Cricket Game Finished!");
        }
    }

    class Football : Game
    {
        public override void Initialize()
        {
            Console.WriteLine("Football Game Initialized! Start playing.");
        }

        public override void StartPlay()
        {
            Console.WriteLine("Football Game Started. Enjoy the game!");
        }
        public override void EndPlay()
        {
            Console.WriteLine("Football Game Finished!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game;

            game = new Cricket();
            game.Play();

            Console.WriteLine();

            game = new Football();
            game.Play();
        }
    }
}

/*
Output:
Cricket Game Initialized! Start playing.
Cricket Game Started. Enjoy the game!
Cricket Game Finished!

Football Game Initialized! Start playing.
Football Game Started. Enjoy the game!
Football Game Finished!
*/