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
        private LifeCount lifeCount;
        public GamePlay()
        {
            background = new Background();
            player = new Player();
            enemy = new Enemy();
            lifeCount = new LifeCount();
        }
        public void Update()
        {
            if (player != null)
            {
            player.Update();
            }
            if (enemy != null)
            {
            enemy.Update();
            }
            lifeCount.UpdateText();
        }
        public void Draw(RenderWindow window)
        {
            background.Draw(window);
            if (player != null)
            {
            player.Draw(window);
            }
            if (enemy != null)
            {
            enemy.Draw(window);
            }
            lifeCount.DrawText(window);
        }
    }
}
