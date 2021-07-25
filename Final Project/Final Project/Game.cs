using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace Final_Project
{
    class Game
    {
        private static Vector2f windowSize;
        private RenderWindow window;
        private GamePlay gamePlay;
        public Game()
        {
            VideoMode videoMode = new VideoMode();
            videoMode.Height = 1080;
            videoMode.Width = 1920;
            window = new RenderWindow(videoMode, "My Game");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(60);
            gamePlay = new GamePlay();
        }
        private void CloseWindow(object sender, EventArgs e)
        {
            window.Close();
        }
        public bool UpdateWindow()
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            return window.IsOpen;
        }
        public void UpdateGame()
        {
            gamePlay.Update();
            windowSize = window.GetView().Size;
        }
        public void DrawGame()
        {
            gamePlay.Draw(window);
            window.Display();
        }
        public static Vector2f GetWindowSize()
        {
            return windowSize;
        }
    }
}
