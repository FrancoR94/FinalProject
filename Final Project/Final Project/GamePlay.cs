using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.System;
using SFML.Graphics;


namespace Final_Project
{
    class GamePlay
    {
        private Player player;
        private Background background;
        public GamePlay()
        {
            background = new Background();
            player = new Player();
        }
        public void Update()
        {
            player.Update();
        }
        public void Draw(RenderWindow window)
        {
            background.Draw(window);
            player.Draw(window);
        }
    }
}
