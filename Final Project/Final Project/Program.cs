using System;
using SFML.System;
using SFML.Audio;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            MusicManager.GetInstance().Play();
            FrameRate.InitFrameRateSystem();
            do
            {
                game.UpdateGame();
                CollisionManager.GetInstance().CheckCollisions();
                game.DrawGame();
                FrameRate.OnFrameEnd();
            } while (game.UpdateWindow());
            
        }
    }
}
