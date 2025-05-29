using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class Collisions
    {
        public static void CheckCollisions(int sizeX, int sizeY, List<Tank> tanks, List<Bullet> bullets, List<Apple> apples, List<River> rivers, List<Wall> walls, Kolobok kolobok, ref int score, ref bool isGameOver)
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < tanks.Count; j++)
                {
                    //Столкновения танков с танками
                    if ((i != j) && (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, tanks[j].x, tanks[j].y, tanks[j].size, tanks[j].size)))
                    {
                        PushingOut(tanks[i], tanks[j]);
                        ChangeDirection.ReverseDirection(tanks[i], tanks[i].direction);
                        ChangeDirection.ReverseDirection(tanks[j], tanks[j].direction);
                    }
                }
                for (int j = 0; j < rivers.Count; j++)
                {
                    //Столкновения танков с реками
                    if ((i != j) && (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, rivers[j].x, rivers[j].y, rivers[j].size, rivers[j].size)))
                    {
                        PushingOut(tanks[i], rivers[j]);
                        ChangeDirection.ReverseDirection(tanks[i], tanks[i].direction);
                    }
                }

                for (int j = 0; j < walls.Count; j++)
                {
                    //Столкновения танков со стенами
                    if ((i != j) && (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, walls[j].x, walls[j].y, walls[j].size, walls[j].size)))
                    {
                        PushingOut(tanks[i], walls[j]);
                        ChangeDirection.ReverseDirection(tanks[i], tanks[i].direction);
                    }
                }

                //Столкновения танков с пулей колобка
                if (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, bullets[0].x, bullets[0].y, bullets[0].size, bullets[0].size))
                {
                    bullets[0].x = -20;
                    bullets[0].y = -20;
                    bullets[0].direction = Direction.UP;
                    tanks.Remove(tanks[i]);
                    tanks.Add(CreateEntity.CreateTank(sizeX, sizeY, kolobok, tanks, apples, rivers, walls));
                }
                if (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, kolobok.x, kolobok.y, kolobok.size, kolobok.size))
                {
                    isGameOver = true;
                }
            }

            for (int i = 0; i < rivers.Count; i++)
            {
                //Столкновения колобка с реками
                if (Colides.Collides(rivers[i].x, rivers[i].y, rivers[i].size, rivers[i].size, kolobok.x, kolobok.y, kolobok.size, kolobok.size))
                {
                    PushingOut(kolobok, rivers[i]);
                    ChangeDirection.ReverseDirection(kolobok, kolobok.direction);
                }
            }

            Wall wallToRemove = new Wall(sizeX, sizeY);
            for (int i = 0; i < walls.Count; i++)
            {
                //Столкновения колобка со стенами
                if (Colides.Collides(walls[i].x, walls[i].y, walls[i].size, walls[i].size, kolobok.x, kolobok.y, kolobok.size, kolobok.size))
                {
                    PushingOut(kolobok, walls[i]);
                    ChangeDirection.ReverseDirection(kolobok, kolobok.direction);
                }
                for (int j = 0; j < bullets.Count; j++)
                {
                    if (Colides.Collides(walls[i].x, walls[i].y, walls[i].size, walls[i].size, bullets[j].x, bullets[j].y, bullets[j].size, bullets[j].size))
                    {
                        wallToRemove = walls[i];
                        bullets[j].x = -20;
                        bullets[j].y = -20;
                        bullets[j].direction = Direction.UP;
                    }
                }
            }
            walls.Remove(wallToRemove);

            for (int i = 0; i < apples.Count; i++)
            {
                //Столкновения колобка с яблоками
                if (Colides.Collides(apples[i].x, apples[i].y, apples[i].size, apples[i].size, kolobok.x, kolobok.y, kolobok.size, kolobok.size))
                {
                    apples.Remove(apples[i]);
                    score += 1;
                    apples.Add(CreateEntity.CreateApple(sizeX, sizeY, kolobok, tanks, apples, rivers, walls));
                }
            }

            for (int i = 1; i < bullets.Count; i++)
            {
                //Столкновения колобка с пулями танков
                if (Colides.Collides(bullets[i].x, bullets[i].y, bullets[i].size, bullets[i].size, kolobok.x, kolobok.y, kolobok.size, kolobok.size))
                {
                    isGameOver = true;
                }
            }
        }

        private static void PushingOut(Entities entity1, FixedEntities entity2)
        {
            Rectangle rect1 = new Rectangle(entity1.x, entity1.y, entity1.size, entity1.size);
            Rectangle rect2 = new Rectangle(entity2.x, entity2.y, entity2.size, entity2.size);
            Rectangle intersect = Rectangle.Intersect(rect1, rect2);
            if (intersect.Width >= intersect.Height)
            {
                if (entity1.y >= entity2.y)
                {
                    entity1.y += intersect.Height;
                }
                else
                {
                    entity1.y -= intersect.Height;
                }
            }
            else
            {
                if (entity1.x >= entity2.x)
                {
                    entity1.x += intersect.Width;
                }
                else
                {
                    entity1.x -= intersect.Width;
                }
            }
        }

        private static void PushingOut(Entities entity1, Entities entity2)
        {
            Rectangle rect1 = new Rectangle(entity1.x, entity1.y, entity1.size, entity1.size);
            Rectangle rect2 = new Rectangle(entity2.x, entity2.y, entity2.size, entity2.size);
            Rectangle intersect = Rectangle.Intersect(rect1, rect2);
            if (intersect.Width >= intersect.Height)
            {
                if (entity1.y >= entity2.y)
                {
                    entity1.y += intersect.Height / 2;
                    entity2.y -= intersect.Height / 2;
                }
                else
                {
                    entity1.y -= intersect.Height / 2;
                    entity2.y += intersect.Height / 2;
                }
            }
            else
            {
                if (entity1.x >= entity2.x)
                {
                    entity1.x += intersect.Width / 2;
                    entity2.x -= intersect.Width / 2;
                }
                else
                {
                    entity1.x -= intersect.Width / 2;
                    entity2.x += intersect.Width / 2;
                }
            }
        }
    }
}
