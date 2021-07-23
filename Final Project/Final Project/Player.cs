using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
    

namespace Final_Project
{
    class Player
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
        
        private float speed;
        private List<Bullet> bullets;
        public Player()
        {
            texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player1.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(3.0f, 3.0f);
            position = new Vector2f(0.0f, 700.0f);
            sprite.Position = position;
            speed = 200.0f;
            bullets = new List<Bullet>();
            
        }
        public void Update()
        {
            Movement();
            Attack();
            /*Shot();
            DestroyBullet();*/
        }

        private void Attack()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                    
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(window);
            }
        }
        private void Movement()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                position.X += speed * (1.0f / (float)Game.FRAMERATE_LIMIT); // lo que yo quiera que haya movimiento * la inersa del framerate actual. ESTO ES PARA QUE EL JUEGO CORRA A LA MISMA VELOCIDAD SIN IMPORTAR QUE UNA PC TENGA MAYOR FPS POR SEGUNDO, SE NIVELA
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                position.X -= speed * (1.0f / (float)Game.FRAMERATE_LIMIT);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                position.Y += speed * (1.0f / (float)Game.FRAMERATE_LIMIT);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) //La coordenada Y crece HACIA ABAJO, O SEA INVERTIDO
            {
                position.Y -= speed * (1.0f / (float)Game.FRAMERATE_LIMIT);
            }
            sprite.Position = position; // vuelvo a setear la posicion del sprite a la posicion que estoy modificando
        }
        /*private void Shot()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                Vector2f spawnPosition = position;
                spawnPosition.X *= (texture.Size.X * sprite.Scale.X) / 2.0f; //Al ancho del sprite lo divido en dos para que salga por la mitad 
                spawnPosition.Y *= (texture.Size.Y * sprite.Scale.X) / 2.0f;
                bullets.Add(new Bullet(spawnPosition)); //El tipo de dato Leaf se guarda en la lista    
            }
        }
        private void DestroyBullet()
        {
            List<int> indexToDelete = new List<int>();
            for (int i = 0; i < bullets.Count; i++)//Recorro hasta la cantidad de balas que hay!
            {
                bullets[i].Update(); // Como leafs es una lista la tengo que recorrer toda!! Al metodo lo llama quien lo contiene, por eso lo llama Player!!
                if (bullets[i].GetPosition().X > Game.GetWindowSize().X)
                {
                    indexToDelete.Add(i);
                }
            }
            for (int i = indexToDelete.Count - 1; i >= 0; i--) //for reverso! se recorre la lista de atras hacia delante
            {
                bullets[i].Dispose();
                bullets.RemoveAt(i);
            }
        }*/
    }
}
