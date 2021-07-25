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

        private List<ICollisionable> collisionables;

        private List<KeyValuePair<ICollisionable, ICollisionable>> collisionRegister;

        private CollisionManager()
        {
            collisionables = new List<ICollisionable>();
            collisionRegister = new List<KeyValuePair<ICollisionable, ICollisionable>>();
        }

        public void AddToCollisionManager(ICollisionable collisionable)
        {
            collisionables.Add(collisionable);
        }

        public void RemoveFromCollisionManager(ICollisionable collisionable)
        {
            if (collisionables.Contains(collisionable))
            {
                collisionables.Remove(collisionable);
            }
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < collisionables.Count; i++)// 1[0] - 2[1] - 3[2]
            {
                for (int j = 0; j < collisionables.Count; j++)// 1[0] - 2[1] - 3[2]
                {
                    if (i != j)
                    {
                        KeyValuePair<ICollisionable, ICollisionable> register = new KeyValuePair<ICollisionable, ICollisionable>(collisionables[i], collisionables[j]);

                        if (collisionables[i].GetBounds().Intersects(collisionables[j].GetBounds()))
                        {
                            if (!collisionRegister.Contains(register))
                            {
                                collisionRegister.Add(register);
                                collisionables[i].OnCollisionEnter(collisionables[j]);
                            }
                            collisionables[i].OnCollisionStay(collisionables[j]);
                        }
                        else
                        {
                            if (collisionRegister.Contains(register))
                            {
                                collisionRegister.Remove(register);
                                collisionables[i].OnCollisionExit(collisionables[j]);
                            }
                        }
                    }
                }
            }
        }
    }
}
