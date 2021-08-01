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
        //private Menu menu;
        private InvisibleWall invisibleWallSup;
        private InvisibleWall invisibleWallInf;
        private List<Enemy> enemies;
        public GamePlay()
        {
            //menu = new Menu();
            background = new Background();
            player = new Player();
            enemy = new Enemy();
            lifeCount = new LifeCount();
            invisibleWallSup = new InvisibleWall(new Vector2f(0f, 450f), new Vector2f (1920f, 200f));
            invisibleWallInf = new InvisibleWall(new Vector2f(0f, 1075f), new Vector2f(1920f, 200f));
            enemies = new List<Enemy>();
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
            //menu.Draw(window);
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
