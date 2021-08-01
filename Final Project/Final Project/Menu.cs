using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Final_Project
{
    class Menu
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
        private bool endMenu;
        public Menu()
        {
            texture = new Texture("sprites" + Path.DirectorySeparatorChar + "menu.png");
            sprite = new Sprite(texture);
            position = new Vector2f(0.0f, 0.0f);
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                endMenu = true;
            }
        }
        public bool GetEndMenu()
        {
            return endMenu;
        }
    }
}
