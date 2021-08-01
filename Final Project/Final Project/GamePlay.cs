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
        private InvisibleWall invisibleWallSup;
        private InvisibleWall invisibleWallInf;
        private List<Enemy> enemies;
        private Random enemySpawn;
        public GamePlay(int maxEnemies)
        {
            background = new Background();
            player = new Player();
            enemy = new Enemy(1);
            lifeCount = new LifeCount();
            invisibleWallSup = new InvisibleWall(new Vector2f(0f, 450f), new Vector2f (1920f, 200f));
            invisibleWallInf = new InvisibleWall(new Vector2f(0f, 1075f), new Vector2f(1920f, 200f));
            enemies = new List<Enemy>();
            enemySpawn = new Random();
            int enemiesInGame = enemySpawn.Next(5, maxEnemies);
            for (int i = 0; i < enemiesInGame; i++)
            {
                enemies.Add(new Enemy(1));
            }
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
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemy.Draw(window);
                }
               // enemy.Draw(window);
            }
            lifeCount.DrawText(window);
        }
        public void CheckGarbash()
        {
            if (player != null)
            {
                player.CheckGarbash();
                if (player.toDelete)
                {
                    player = null;
                }
            }

            if (enemy != null)
            {
                enemy.CheckGarbash();
                if (enemy.toDelete)
                {
                    enemy = null;
                }
            }
        }
    }
}
