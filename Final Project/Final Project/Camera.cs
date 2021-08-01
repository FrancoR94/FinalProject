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
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                position.X += 200 * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                position.X -= 200 * FrameRate.GetDeltaTime();
            }

            
            view.Center = position;
            window.SetView(view);
        }
    }
}
