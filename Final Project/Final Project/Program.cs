using System;
using SFML.System;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            //FrameRate.InitFrameRateSystem();
            do
            {
                game.UpdateGame();
                game.DrawGame();
               // FrameRate.OnFrameEnd();
            } while (game.UpdateWindow());
            Console.ReadKey();
        }
    }
}
