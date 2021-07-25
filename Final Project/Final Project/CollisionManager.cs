using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project
{
    class CollisionManager
    {
        private static CollisionManager instance;
        public static CollisionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new CollisionManager();
            }
            return instance;
        }

        private List<ICollisionable> colisionables;

        private List<KeyValuePair<ICollisionable, ICollisionable>> collisionRegister;

        private CollisionManager()
        {
            colisionables = new List<ICollisionable>();
            collisionRegister = new List<KeyValuePair<ICollisionable, ICollisionable>>();
        }

        public void AddToCollisionManager(ICollisionable colisionable)
        {
            colisionables.Add(colisionable);
        }

        public void RemoveFromCollisionManager(ICollisionable colisionable)
        {
            if (colisionables.Contains(colisionable))
            {
                colisionables.Remove(colisionable);
            }
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < colisionables.Count; i++)// 1[0] - 2[1] - 3[2]
            {
                for (int j = 0; j < colisionables.Count; j++)// 1[0] - 2[1] - 3[2]
                {
                    if (i != j)
                    {
                        KeyValuePair<ICollisionable, ICollisionable> register = new KeyValuePair<ICollisionable, ICollisionable>(colisionables[i], colisionables[j]);

                        if (colisionables[i].GetBounds().Intersects(colisionables[j].GetBounds()))
                        {
                            if (!collisionRegister.Contains(register))
                            {
                                collisionRegister.Add(register);
                                colisionables[i].OnCollisionEnter(colisionables[j]);
                            }
                            colisionables[i].OnCollisionStay(colisionables[j]);
                        }
                        else
                        {
                            if (collisionRegister.Contains(register))
                            {
                                collisionRegister.Remove(register);
                                colisionables[i].OnCollisionExit(colisionables[j]);
                            }
                        }
                    }
                }
            }
        }
    }
}
