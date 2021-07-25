using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Final_Project
{
    class LifeCount
    {
        private Text text;
        private Texture texture;
        private RenderStates renderState;
        private Vector2f position;
        public LifeCount()
        {
            Font spooky = new Font("Fonts" + Path.DirectorySeparatorChar + "Frightmare.ttf");
            renderState = new RenderStates(texture);
            text = new Text("Your life\n     " + Player.GetLife(), spooky);
            text.FillColor = Color.Green;
            text.OutlineColor = Color.Black;
            text.OutlineThickness = 2.0f;
            text.Position = new SFML.System.Vector2f(750.0f, 50.0f);
            text.Scale = new SFML.System.Vector2f(4.0f, 2.0f);
            position = text.Position;
        }

        public void DrawText(RenderWindow window)
        {
            text.Draw(window, renderState);
        }

        public void UpdateText()
        {
            //position.X += 100.0f * FrameRate.GetDeltaTime();
            text.Position = position;
        }

    }
}
