using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Final_Project
{
    class Player : GameObjectBase, ICollisionable
    {
        private float speed;
        private List<Bullet> bullets;
        private static int life;
        public Player() : base("sprites" + Path.DirectorySeparatorChar + "Soldier-Guy-PNG" + Path.DirectorySeparatorChar + "_Mode-Gun" + Path.DirectorySeparatorChar + "01-Idle" + Path.DirectorySeparatorChar + "player1.png", new Vector2f(0.0f, 800.0f))
        {
            sprite.Scale = new Vector2f(0.4f, 0.4f);
            speed = 200.0f;
            bullets = new List<Bullet>();
            CollisionManager.GetInstance().AddToCollisionManager(this);
            life = 5;
        }
        public override void Update()
        {
            Movement();
            Attack();
            base.Update();
            /*Shot();
            DestroyBullet();*/
        }

        private void Attack()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) //No deja de imprimirse una vez que presiono, por esto agregue la textura a cada movimiento
            {
                Console.WriteLine("spacebar");
                texture = new Texture( "sprites" + Path.DirectorySeparatorChar + "player3.png");
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(3.0f, 3.0f);
                speed = 200.0f;
            }
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(window);
            }
        }
        private void Movement()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
               /* texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player4.png");
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(3.0f, 3.0f);
                speed = 200.0f;*/
                position.X += speed * FrameRate.GetDeltaTime(); // lo que yo quiera que haya movimiento * la inersa del framerate actual. ESTO ES PARA QUE EL JUEGO CORRA A LA MISMA VELOCIDAD SIN IMPORTAR QUE UNA PC TENGA MAYOR FPS POR SEGUNDO, SE NIVELA
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                /*texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player5.png");
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(3.0f, 3.0f);
                speed = 200.0f;*/
                position.X -= speed * FrameRate.GetDeltaTime();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                /*texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player4.png");
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(3.0f, 3.0f);
                speed = 200.0f;*/
                position.Y += speed * FrameRate.GetDeltaTime();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) //La coordenada Y crece HACIA ABAJO, O SEA INVERTIDO
            {
                /*texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player4.png");
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(3.0f, 3.0f);
                speed = 200.0f;*/
                position.Y -= speed * FrameRate.GetDeltaTime();
            }
            //sprite.Position = position; // vuelvo a setear la posicion del sprite a la posicion que estoy modificando
        }
        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }
        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }
        public void OnCollisionStay(ICollisionable other)
        {
            if (other is Enemy || other is InvisibleWall)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    position.X -= speed * FrameRate.GetDeltaTime(); // lo que yo quiera que haya movimiento * la inersa del framerate actual. ESTO ES PARA QUE EL JUEGO CORRA A LA MISMA VELOCIDAD SIN IMPORTAR QUE UNA PC TENGA MAYOR FPS POR SEGUNDO, SE NIVELA
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    position.X += speed * FrameRate.GetDeltaTime();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    position.Y -= speed * FrameRate.GetDeltaTime();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W)) //La coordenada Y crece HACIA ABAJO, O SEA INVERTIDO
                {
                    position.Y += speed * FrameRate.GetDeltaTime();
                }
                sprite.Position = position;
            }
        }

        public void OnCollisionEnter(ICollisionable other)
        {
            
        }

        public void OnCollisionExit(ICollisionable other)
        {
            if (other is Enemy)
            {
                Console.WriteLine("Player exit");
            }
        }
        public static int GetLife()
        {
            return life;
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
