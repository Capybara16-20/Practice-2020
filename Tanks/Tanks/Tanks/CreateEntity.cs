using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class CreateEntity
    {
        public static Tank CreateTank(int sizeX, int sizeY, Kolobok kolobok, List<Tank> tanks, List<Apple> apples, List<River> rivers, List<Wall> walls)
        {
            while (true)
            {
                bool addTank = true;
                Tank tank = new Tank(sizeX, sizeY);
                for (int i = 0; i < tanks.Count; i++)
                {
                    for (int j = 0; j < apples.Count; j++)
                    {
                        if (Colides.Collides(tank.x, tank.y, tank.size, tank.size, apples[j].x, apples[j].y, apples[j].size, apples[j].size))
                        {
                            addTank = false;
                        }
                    }
                    for (int j = 0; j < rivers.Count; j++)
                    {
                        if (Colides.Collides(tank.x, tank.y, tank.size, tank.size, rivers[j].x, rivers[j].y, rivers[j].size, rivers[j].size))
                        {
                            addTank = false;
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {
                        if (Colides.Collides(tank.x, tank.y, tank.size, tank.size, walls[j].x, walls[j].y, walls[j].size, walls[j].size))
                        {
                            addTank = false;
                        }
                    }
                    if (Colides.Collides(tank.x, tank.y, tank.size, tank.size, tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size))
                    {
                        addTank = false;
                    }
                }
                if (Colides.Collides(tank.x, tank.y, tank.size, tank.size, kolobok.x - 50, kolobok.y - 50, kolobok.size + 100, kolobok.size + 100))
                {
                    addTank = false;
                }
                if (addTank)
                {
                    return tank;
                }
            }
        }

        public static Apple CreateApple(int sizeX, int sizeY, Kolobok kolobok, List<Tank> tanks, List<Apple> apples, List<River> rivers, List<Wall> walls)
        {
            while (true)
            {
                bool addApple = true;
                Apple apple = new Apple(sizeX, sizeY);
                for (int i = 0; i < apples.Count; i++)
                {
                    for (int j = 0; j < tanks.Count; j++)
                    {
                        if (Colides.Collides(apple.x, apple.y, apple.size, apple.size, tanks[j].x, tanks[j].y, tanks[j].size, tanks[j].size))
                        {
                            addApple = false;
                        }
                    }
                    for (int j = 0; j < rivers.Count; j++)
                    {
                        if (Colides.Collides(apple.x, apple.y, apple.size, apple.size, rivers[j].x, rivers[j].y, rivers[j].size, rivers[j].size))
                        {
                            addApple = false;
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {
                        if (Colides.Collides(apple.x, apple.y, apple.size, apple.size, walls[j].x, walls[j].y, walls[j].size, walls[j].size))
                        {
                            addApple = false;
                        }
                    }
                    if (Colides.Collides(apple.x, apple.y, apple.size, apple.size, apples[i].x, apples[i].y, apples[i].size, apples[i].size))
                    {
                        addApple = false;
                    }
                }
                if (Colides.Collides(apple.x, apple.y, apple.size, apple.size, kolobok.x - 30, kolobok.y - 30, kolobok.size + 60, kolobok.size + 60))
                {
                    addApple = false;
                }
                if (addApple)
                {
                    return apple;
                }
            }
        }

        public static River CreateRiver(int sizeX, int sizeY, Kolobok kolobok, List<Tank> tanks, List<Apple> apples, List<River> rivers, List<Wall> walls)
        {
            while (true)
            {
                bool addRiver = true;
                River river = new River(sizeX, sizeY);
                for (int i = 0; i < rivers.Count; i++)
                {
                    for (int j = 0; j < tanks.Count; j++)
                    {
                        if (Colides.Collides(river.x, river.y, river.size, river.size, tanks[j].x, tanks[j].y, tanks[j].size, tanks[j].size))
                        {
                            addRiver = false;
                        }
                    }
                    for (int j = 0; j < apples.Count; j++)
                    {
                        if (Colides.Collides(river.x, river.y, river.size, river.size, apples[j].x, apples[j].y, apples[j].size, apples[j].size))
                        {
                            addRiver = false;
                        }
                    }
                    for (int j = 0; j < walls.Count; j++)
                    {
                        if (Colides.Collides(river.x, river.y, river.size, river.size, walls[j].x, walls[j].y, walls[j].size, walls[j].size))
                        {
                            addRiver = false;
                        }
                    }
                    if (Colides.Collides(river.x, river.y, river.size, river.size, rivers[i].x, rivers[i].y, rivers[i].size, rivers[i].size))
                    {
                        addRiver = false;
                    }
                }
                if (Colides.Collides(river.x, river.y, river.size, river.size, kolobok.x - 30, kolobok.y - 30, kolobok.size + 60, kolobok.size + 60))
                {
                    addRiver = false;
                }
                if (addRiver)
                {
                    return river;
                }
            }
        }

        public static Wall CreateWall(int sizeX, int sizeY, Kolobok kolobok, List<Tank> tanks, List<Apple> apples, List<River> rivers, List<Wall> walls)
        {
            while (true)
            {
                bool addWall = true;
                Wall wall = new Wall(sizeX, sizeY);
                for (int i = 0; i < walls.Count; i++)
                {
                    for (int j = 0; j < tanks.Count; j++)
                    {
                        if (Colides.Collides(wall.x, wall.y, wall.size, wall.size, tanks[j].x, tanks[j].y, tanks[j].size, tanks[j].size))
                        {
                            addWall = false;
                        }
                    }
                    for (int j = 0; j < apples.Count; j++)
                    {
                        if (Colides.Collides(wall.x, wall.y, wall.size, wall.size, apples[j].x, apples[j].y, apples[j].size, apples[j].size))
                        {
                            addWall = false;
                        }
                    }
                    for (int j = 0; j < rivers.Count; j++)
                    {
                        if (Colides.Collides(wall.x, wall.y, wall.size, wall.size, rivers[j].x, rivers[j].y, rivers[j].size, rivers[j].size))
                        {
                            addWall = false;
                        }
                    }
                    if (Colides.Collides(wall.x, wall.y, wall.size, wall.size, walls[i].x, walls[i].y, walls[i].size, walls[i].size))
                    {
                        addWall = false;
                    }
                }
                if (Colides.Collides(wall.x, wall.y, wall.size, wall.size, kolobok.x - 30, kolobok.y - 30, kolobok.size + 60, kolobok.size + 60))
                {
                    addWall = false;
                }
                if (addWall)
                {
                    return wall;
                }
            }
        }
    }
}
