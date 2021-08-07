﻿using SFML.Graphics;
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
        enum Status { Moving, Attack };
        private Sound sound;
        private float speed;
        private Clock clock;
        private Time currentTime;
        private float time;
        private int life;
        private IntRect frameRect;
        private int sheetColumns = 10;
        private int sheetRows = 1;
        private Clock frameTimer;
        private int currentFrame = 0;
        private float animTime = 2;
        private List<List<Vector2i>> animations;
        private Status status;

        public Enemy(int life) : base("sprites" + Path.DirectorySeparatorChar + "zombie.png", new Vector2f(1500.0f, 800.0f))
        {
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColumns;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
            this.life = life;
            sprite.Scale = new Vector2f(0.5f, 0.5f);
            sprite.Position = position;
            speed = 100.0f;
            SoundBuffer soundBuffer = new SoundBuffer("Audio" + Path.DirectorySeparatorChar + "zombieappears.ogg");
            CollisionManager.GetInstance().AddToCollisionManager(this);
            sound = new Sound(soundBuffer);
            frameTimer = new Clock();
            animations = new List<List<Vector2i>>();
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations[(int)Status.Moving].Add(new Vector2i(0, 0));
            animations[(int)Status.Moving].Add(new Vector2i(1, 0));
            animations[(int)Status.Moving].Add(new Vector2i(2, 0));
            animations[(int)Status.Moving].Add(new Vector2i(3, 0));
            animations[(int)Status.Moving].Add(new Vector2i(4, 0));
            animations[(int)Status.Moving].Add(new Vector2i(5, 0));
            animations[(int)Status.Moving].Add(new Vector2i(6, 0));
            animations[(int)Status.Moving].Add(new Vector2i(7, 0));
            animations[(int)Status.Moving].Add(new Vector2i(8, 0));
            animations[(int)Status.Moving].Add(new Vector2i(9, 0));
            //clock = new Clock();
        }
        public override void Update()
        {
            Movement();
            updateAnimation();
            base.Update();
        }
        private void Movement()
        {
            status = Status.Moving;
            position.X -= speed * FrameRate.GetDeltaTime();
            sprite.Position = position;
        }
        public override void Draw(RenderWindow window)
        {
            //currentTime = clock.ElapsedTime;
            //time = currentTime.AsSeconds() + FrameRate.GetDeltaTime();
            //if (time > 3)
            //{
            base.Draw(window);
            //}
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
        private void updateAnimation()
        {
            switch (status)
            {
                case Status.Moving:
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Moving].Count - 1)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.Moving].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Moving][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Moving][currentFrame].Y * frameRect.Height;
                    break;
            }
        }
    }
}
