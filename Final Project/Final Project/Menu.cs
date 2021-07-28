using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace Final_Project
{
    class Menu
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
        public Menu()
        {
            texture = new Texture("sprites" + Path.DirectorySeparatorChar + "mainMenu.png");
            sprite = new Sprite(texture);
            position = new Vector2f(0.0f, 0.0f);
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
            Console.WriteLine("se dibujo el menu");
        }
        public void Update()
        {
            /*if (MouseUtils.ClickOn(GetBounds(), Mouse.Button.Left))
            {
                Console.WriteLine("Mouse left");
            }

            base.Update();*/
        }
    }
}
