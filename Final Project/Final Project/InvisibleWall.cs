using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project
{
    class InvisibleWall : ICollisionable
    {
        private Vector2f position;
        private Vector2f size;
        public InvisibleWall(Vector2f position, Vector2f size)
        {
            this.position = position;
            this.size = size;
            CollisionManager.GetInstance().AddToCollisionManager(this);
        }

        public FloatRect GetBounds()
        {
            return new FloatRect(position, size);
        }

        public void OnCollisionEnter(ICollisionable other)
        {
        }

        public void OnCollisionExit(ICollisionable other)
        {
        }

        public void OnCollisionStay(ICollisionable other)
        {
        }
    }
}
