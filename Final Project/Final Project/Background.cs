using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;


namespace Final_Project
{
    class Background
    {
        
        private Sprite sprite;
        private Vector2f position;
        private readonly string background1 = "sprites" + Path.DirectorySeparatorChar + "PNG" + Path.DirectorySeparatorChar + "Postapocalypce2" + Path.DirectorySeparatorChar + "Bright" + Path.DirectorySeparatorChar + "sky.png";
        private readonly string background2 = "sprites" + Path.DirectorySeparatorChar + "PNG" + Path.DirectorySeparatorChar + "Postapocalypce2" + Path.DirectorySeparatorChar + "Bright" + Path.DirectorySeparatorChar + "back.png";
        private readonly string background3 = "sprites" + Path.DirectorySeparatorChar + "PNG" + Path.DirectorySeparatorChar + "Postapocalypce2" + Path.DirectorySeparatorChar + "Bright" + Path.DirectorySeparatorChar + "houses.png";
        private readonly string background4 = "sprites" + Path.DirectorySeparatorChar + "PNG" + Path.DirectorySeparatorChar + "Postapocalypce2" + Path.DirectorySeparatorChar + "Bright" + Path.DirectorySeparatorChar + "car.png";
        private readonly string background5 = "sprites" + Path.DirectorySeparatorChar + "PNG" + Path.DirectorySeparatorChar + "Postapocalypce2" + Path.DirectorySeparatorChar + "Bright" + Path.DirectorySeparatorChar + "fence.png";
        private readonly string background6 = "sprites" + Path.DirectorySeparatorChar + "PNG" + Path.DirectorySeparatorChar + "Postapocalypce2" + Path.DirectorySeparatorChar + "Bright" + Path.DirectorySeparatorChar + "road.png";
        List<Texture> textures = new List<Texture>();
        List<Sprite> sprites = new List<Sprite>();
        public Background()
        {
            AddTexture();
            for (int i = 0; i < textures.Count; i++)
            {
                sprite = new Sprite(textures[i]);
                sprites.Add(sprite);
            }
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            position = new Vector2f(0.0f, 0.0f);
            sprite.Position = position;
        }
        private void AddTexture()
        {
            Texture sky = new Texture(background1);
            Texture back = new Texture(background2);
            Texture houses = new Texture(background3);
            Texture car = new Texture(background4);
            Texture fence = new Texture(background5);
            Texture road = new Texture(background6);
            textures.Add(sky);
            textures.Add(back);
            textures.Add(houses);
            textures.Add(car);
            textures.Add(fence);
            textures.Add(road);
        }
        public void Draw(RenderWindow window)
        {

            for (int i = 0; i < sprites.Count; i++)
            {
                window.Draw(sprites[i]);
            }
        }
    }
}
