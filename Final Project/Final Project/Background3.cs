using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Final_Project
{

    class Background3
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;

        public Background3()
        {
            texture = new Texture("sprites" + Path.DirectorySeparatorChar + "PNG" + Path.DirectorySeparatorChar + "Postapocalypce2" + Path.DirectorySeparatorChar + "Bright" + Path.DirectorySeparatorChar + "houses.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            position = new Vector2f(0.0f, 0.0f);
            sprite.Position = position;
        }
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}

