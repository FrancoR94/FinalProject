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
        enum Status { Idle, Moving, Shot };
        private float speed;
        private List<Bullet> bullets;
        private static int life;
        private IntRect frameRect;
        private int sheetColumns = 10;
        private int sheetRows = 6;
        private Clock frameTimer;
        private int currentFrame = 0;
        private float animTime = 5f;
        private List<List<Vector2i>> animations;
        private Status status;
        public Player() : base("sprites" + Path.DirectorySeparatorChar + "player.png", new Vector2f(0.0f, 800.0f))
        {
            frameRect = new IntRect();
            frameRect.Width = (int)texture.Size.X / sheetColumns;
            frameRect.Height = (int)texture.Size.Y / sheetRows;
            sprite.TextureRect = frameRect;
            sprite.Scale = new Vector2f(1.5f, 1.5f);
            speed = 200.0f;
            bullets = new List<Bullet>();
            CollisionManager.GetInstance().AddToCollisionManager(this);
            life = 5;
            frameTimer = new Clock();
            animations = new List<List<Vector2i>>();
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations.Add(new List<Vector2i>());
            animations[(int)Status.Idle].Add(new Vector2i(0, 0));
            animations[(int)Status.Idle].Add(new Vector2i(1, 0));
            animations[(int)Status.Idle].Add(new Vector2i(2, 0));
            animations[(int)Status.Idle].Add(new Vector2i(3, 0));
            animations[(int)Status.Idle].Add(new Vector2i(4, 0));
            animations[(int)Status.Idle].Add(new Vector2i(5, 0));
            animations[(int)Status.Idle].Add(new Vector2i(6, 0));
            animations[(int)Status.Idle].Add(new Vector2i(7, 0));
            animations[(int)Status.Idle].Add(new Vector2i(8, 0));
            animations[(int)Status.Idle].Add(new Vector2i(9, 0));
            animations[(int)Status.Moving].Add(new Vector2i(0, 1));
            animations[(int)Status.Moving].Add(new Vector2i(1, 1));
            animations[(int)Status.Moving].Add(new Vector2i(2, 1));
            animations[(int)Status.Moving].Add(new Vector2i(3, 1));
            animations[(int)Status.Moving].Add(new Vector2i(4, 1));
            animations[(int)Status.Moving].Add(new Vector2i(5, 1));
            animations[(int)Status.Moving].Add(new Vector2i(6, 1));
            animations[(int)Status.Moving].Add(new Vector2i(7, 1));
            animations[(int)Status.Moving].Add(new Vector2i(8, 1));
            animations[(int)Status.Moving].Add(new Vector2i(9, 1));
            animations[(int)Status.Shot].Add(new Vector2i(0, 2));
            animations[(int)Status.Shot].Add(new Vector2i(1, 2));
            animations[(int)Status.Shot].Add(new Vector2i(2, 2));
            animations[(int)Status.Shot].Add(new Vector2i(3, 2));
            animations[(int)Status.Shot].Add(new Vector2i(4, 2));
            animations[(int)Status.Shot].Add(new Vector2i(5, 2));
            animations[(int)Status.Shot].Add(new Vector2i(6, 2));
            animations[(int)Status.Shot].Add(new Vector2i(7, 2));
            animations[(int)Status.Shot].Add(new Vector2i(8, 2));
            animations[(int)Status.Shot].Add(new Vector2i(9, 2));
        }
        public override void Update()
        {
            Movement();
            updateAnimation();
            Shot();
            //Attack();
            DestroyBullet();
            base.Update();
        }

       /* private void Attack()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) //No deja de imprimirse una vez que presiono, por esto agregue la textura a cada movimiento
            {
                Console.WriteLine("spacebar");
                texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player3.png");
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(3.0f, 3.0f);
                speed = 200.0f;
            }
        }*/

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
            //if (status != Status.Shot)
           // {
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    /* texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player4.png");
                     sprite = new Sprite(texture);
                     sprite.Scale = new Vector2f(3.0f, 3.0f);
                     speed = 200.0f;*/
                    position.X += speed * FrameRate.GetDeltaTime(); // lo que yo quiera que haya movimiento * la inersa del framerate actual. ESTO ES PARA QUE EL JUEGO CORRA A LA MISMA VELOCIDAD SIN IMPORTAR QUE UNA PC TENGA MAYOR FPS POR SEGUNDO, SE NIVELA
                    status = Status.Moving;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    /*texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player5.png");
                    sprite = new Sprite(texture);
                    sprite.Scale = new Vector2f(3.0f, 3.0f);
                    speed = 200.0f;*/
                    position.X -= speed * FrameRate.GetDeltaTime();
                    status = Status.Moving;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    /*texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player4.png");
                    sprite = new Sprite(texture);
                    sprite.Scale = new Vector2f(3.0f, 3.0f);
                    speed = 200.0f;*/
                    position.Y += speed * FrameRate.GetDeltaTime();
                    status = Status.Moving;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W)) //La coordenada Y crece HACIA ABAJO, O SEA INVERTIDO
                {
                    /*texture = new Texture("sprites" + Path.DirectorySeparatorChar + "player4.png");
                    sprite = new Sprite(texture);
                    sprite.Scale = new Vector2f(3.0f, 3.0f);
                    speed = 200.0f;*/
                    position.Y -= speed * FrameRate.GetDeltaTime();
                    status = Status.Moving;
                }
                bool isMovingHorizontaly = !Keyboard.IsKeyPressed(Keyboard.Key.A) && !Keyboard.IsKeyPressed(Keyboard.Key.D);
                bool isMovingVerticaly = !Keyboard.IsKeyPressed(Keyboard.Key.W) && !Keyboard.IsKeyPressed(Keyboard.Key.S);
                if (isMovingHorizontaly && isMovingHorizontaly)
                {
                    status = Status.Idle;
                }
            //}

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
        private void Shot()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                Console.WriteLine("dispara");
                status = Status.Shot;
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
        }
        private void updateAnimation()
        {
            switch (status)
            {
                case Status.Moving:
                    if (frameTimer.ElapsedTime.AsSeconds() > animTime / animations[(int)Status.Moving].Count - 1)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.Moving].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Moving][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Moving][currentFrame].Y * frameRect.Height;
                    break;
                case Status.Idle:
                    if (frameTimer.ElapsedTime.AsSeconds() > animations[(int)Status.Idle].Count - 1)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.Idle].Count - 1)
                        {
                            currentFrame = 0;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Idle][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Idle][currentFrame].Y * frameRect.Height;
                    break;
                case Status.Shot:
                    //animTime = 0.5f;
                    if (frameTimer.ElapsedTime.AsSeconds() > animations[(int)Status.Shot].Count - 1)
                    {
                        currentFrame++;
                        if (currentFrame == animations[(int)Status.Shot].Count - 1)
                        {
                            currentFrame = 0;
                            status = Status.Idle;
                        }
                        frameTimer.Restart();
                    }
                    frameRect.Left = animations[(int)Status.Shot][currentFrame].X * frameRect.Width;
                    frameRect.Top = animations[(int)Status.Shot][currentFrame].Y * frameRect.Height;
                    break;

            }
            sprite.TextureRect = frameRect;
        }
    }
}
