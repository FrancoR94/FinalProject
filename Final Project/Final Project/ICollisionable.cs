using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project
{
    interface ICollisionable
    {

        public FloatRect GetBounds();
        public void OnCollisionStay(ICollisionable other);
        public void OnCollisionEnter(ICollisionable other);
        public void OnCollisionExit(ICollisionable other);

    }
}
