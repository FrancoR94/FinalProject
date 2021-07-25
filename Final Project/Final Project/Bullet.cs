using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace Final_Project
{
    class Bullet
    { 
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
        private float speed;
        private Bullet bullet;
        public Bullet(Vector2f position)
        {
            texture = new Texture("sprites/bullet.jpg"); 
            sprite = new Sprite(texture); 
            sprite.Scale = new Vector2f(0.05f, 0.05f);
            position = new Vector2f(600.0f, 500.0f); 
            sprite.Position = position;
            speed = 200.0f;
        }
        public void Update()
        {
            position.X -= speed * FrameRate.GetDeltaTime();
            sprite.Position = position;     
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
        public void Dispose()
        {
            sprite.Dispose(); 
            texture.Dispose();
        }
        public Vector2f GetPosition() 
        {
            return position;
        }
    }
}
