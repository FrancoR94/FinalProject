using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using System.IO;

namespace Final_Project
{
    class Enemy
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
        private float speed;

        public Enemy()
        {
            texture = new Texture("sprites" + Path.DirectorySeparatorChar + "zombie1.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(3.0f, 3.0f);
            position = new Vector2f(1500.0f, 700.0f);
            sprite.Position = position;
            speed = 100.0f;
        }
        public void Update()
        {
            Movement();
        }
        private void Movement()
        {
            position.X -= speed * (1.0f / (float)Game.FRAMERATE_LIMIT);
            sprite.Position = position;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

    }
}
