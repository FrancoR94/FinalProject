using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using System.IO;

namespace Final_Project
{
    class Enemy : GameObjectBase
    {
       
        private float speed;

        public Enemy() : base ("sprites" + Path.DirectorySeparatorChar + "zombie1.png", new Vector2f(1500.0f, 700.0f))
        {
            
            sprite.Scale = new Vector2f(3.0f, 3.0f);
            
            sprite.Position = position;
            speed = 100.0f;
        }
        public void Update()
        {
            Movement();
        }
        private void Movement()
        {
            position.X -= speed * FrameRate.GetDeltaTime();
            sprite.Position = position;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

    }
}
