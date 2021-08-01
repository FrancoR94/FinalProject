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
        private Camera camera;
        private Menu menu;
        public Game()
        {
            VideoMode videoMode = new VideoMode();
            videoMode.Height = 1080;
            videoMode.Width = 1920;
            window = new RenderWindow(videoMode, "My Game");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(60);
            camera = new Camera(window);
            menu = new Menu();
            gamePlay = new GamePlay(10);
            MouseUtils.SetWindow(window);
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
            menu.Update();
            gamePlay.Update();
            camera.UpdateCamera();
            windowSize = window.GetView().Size;
        }
        public void DrawGame()
        {
            if (menu.GetEndMenu() == false)
            {
                menu.Draw(window);
            }
            else
            {
                gamePlay.Draw(window);
            }
            window.Display();
        }
        public static Vector2f GetWindowSize()
        {
            return windowSize;
        }
        public void CheckGarbash()
        {
            gamePlay.CheckGarbash();
        }

    }
}
