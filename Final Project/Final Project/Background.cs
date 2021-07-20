using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Final_Project
{
    class Background
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
        private Player player;
        public Background()
        {
            texture = new Texture("sprites/background.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            position = new Vector2f(0.0f, 0.0f);
            sprite.Position = position;
        }
        public void Draw (RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
