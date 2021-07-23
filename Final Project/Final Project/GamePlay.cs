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
        private Enemy enemy;
        private Background background;
        private Background2 background2;
        private Background3 background3;
        private Background4 background4;
        private Background5 background5;
        private Background6 background6;
        public GamePlay()
        {
            background = new Background();
            background2 = new Background2();
            background3 = new Background3();
            background4 = new Background4();
            background5 = new Background5();
            background6 = new Background6();
            player = new Player();
            enemy = new Enemy();
        }
        public void Update()
        {
            player.Update();
            enemy.Update();
        }
        public void Draw(RenderWindow window)
        {
            background.Draw(window);
            background2.Draw(window);
            background3.Draw(window);
            background4.Draw(window);
            background5.Draw(window);
            background6.Draw(window);
            player.Draw(window);
            enemy.Draw(window);
        }
    }
}
