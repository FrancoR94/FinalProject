using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project
{
    public class Camera
    {
        private RenderWindow window;
        private View view;
        private Vector2f position;


        public Camera(RenderWindow window)
        {
            this.window = window;
            view = window.GetView();
            position = view.Center;
        }


        public void UpdateCamera()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                position.X -= 100 * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                position.X += 100 * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                position.Y -= 100 * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                position.Y += 100 * FrameRate.GetDeltaTime();
            }
            view.Center = position;
            window.SetView(view);
        }
    }
}
