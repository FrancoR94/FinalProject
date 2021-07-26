using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using System.IO;

namespace Final_Project
{
    class Enemy : GameObjectBase, ICollisionable
    {

        private float speed;

        public Enemy() : base("sprites" + Path.DirectorySeparatorChar + "zombie4.png", new Vector2f(1500.0f, 700.0f))
        {
            sprite.Scale = new Vector2f(3.0f, 3.0f);
            sprite.Position = position;
            speed = 100.0f;
            CollisionManager.GetInstance().AddToCollisionManager(this);
        }
        public override void Update()
        {
            Movement();
            base.Update();
        }
        private void Movement()
        {
            position.X -= speed * FrameRate.GetDeltaTime();
            sprite.Position = position;
        }
        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
        }
        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }
        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }
        public void OnCollisionEnter(ICollisionable other)
        {
            
        }

        public void OnCollisionExit(ICollisionable other)
        {
            
        }

        public void OnCollisionStay(ICollisionable other)
        {
            if (other is Player)
            {
                position.X += speed * FrameRate.GetDeltaTime();
                sprite.Position = position;
            }
        }
    }
}
