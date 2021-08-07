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
        private Background background2;
        private LifeCount lifeCount;
        private InvisibleWall invisibleWallSup;
        private InvisibleWall invisibleWallInf;
        private InvisibleWall invisibleWallRight;
        private InvisibleWall invisibleWallLeft;
        private List<Enemy> enemies;
        private Random enemySpawn;
        private Clock clock;
        private float frequency;
        public GamePlay(int maxEnemies)
        {
            clock = new Clock();
            background = new Background(new Vector2f(0.0f, 0.0f));
            //background2 = new Background(new Vector2f(1920.0f, 0.0f));
            player = new Player();
            lifeCount = new LifeCount();
            invisibleWallSup = new InvisibleWall(new Vector2f(0f, 570f), new Vector2f(1920f, 200f));
            invisibleWallInf = new InvisibleWall(new Vector2f(0f, 1075f), new Vector2f(1920f, 200f));
            invisibleWallRight = new InvisibleWall(new Vector2f(0f, 0f), new Vector2f(1f, 1080f));
            invisibleWallLeft = new InvisibleWall(new Vector2f(1920f, 0f), new Vector2f(1f, 1080f));
            enemy = new Enemy(1);
            enemies = new List<Enemy>(); //LOS ENEMIGOS DEBERIAN DE CREARSE EN EL UPDATE
            enemySpawn = new Random();
            int enemiesInGame = enemySpawn.Next(5, maxEnemies);
            for (int i = 0; i < enemiesInGame; i++)
            {
                enemies.Add(new Enemy(1));
            }
            frequency = 1.0f;
        }
        public void Update()
        {
            if (player != null)
            {
                player.Update();
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (clock.ElapsedTime.AsSeconds() > frequency)
                {
                    enemies[i].Update();
                }
            }
            lifeCount.UpdateText();
        }
        public void Draw(RenderWindow window)
        {
            background.Draw(window);
            //background2.Draw(window);
            
            if (player != null)
            {
                player.Draw(window);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(window);
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
