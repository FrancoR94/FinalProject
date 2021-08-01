using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using System.IO;
using SFML.Audio;

namespace Final_Project
{
    class Enemy : GameObjectBase, ICollisionable
    {
        private Sound sound;
        private float speed;
        private Clock clock;
        private Time currentTime;
        private float time;
        private int life;

        public Enemy(int life) : base("sprites" + Path.DirectorySeparatorChar + "zombie4.png", new Vector2f(1500.0f, 700.0f))
        {
            this.life = life;
            sprite.Scale = new Vector2f(3.0f, 3.0f);
            sprite.Position = position;
            speed = 100.0f;
            SoundBuffer soundBuffer = new SoundBuffer("Audio" + Path.DirectorySeparatorChar + "zombieappears.ogg");
            CollisionManager.GetInstance().AddToCollisionManager(this);
            sound = new Sound(soundBuffer);
            clock = new Clock();
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
            currentTime = clock.ElapsedTime;
            time = currentTime.AsSeconds() + FrameRate.GetDeltaTime();
            if (time > 3)
            {
            base.Draw(window);
            }
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
            sound.Play();
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
