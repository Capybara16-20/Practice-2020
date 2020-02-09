using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Form1 : Form
    {
        int tanksNumber = 5;
        int sizeX = 500;
        int sizeY = 500;
        //int speed = 100;
        Kolobok kolobok;
        List<Tank> tanks = new List<Tank>();
        public Form1()
        {
            this.MinimumSize = new Size(sizeX + 26, sizeY + 49);
            this.MaximumSize = new Size(sizeX + 26, sizeY + 49);
            this.BackgroundImage = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\background.png");
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.KeyDown += new KeyEventHandler(OKP);
            Init();
            Invalidate();
        }

        public void Init()
        {
            kolobok = new Kolobok(10, sizeY - 60);
            kolobok.direction = Direction.RIGHT;
            while (tanks.Count < tanksNumber)
            {
                tanks.Add(CreateTank());
            }
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            timer2.Interval = 700;
            timer2.Tick += new EventHandler(TankStepDirection);
            timer2.Start();
        }

        private void update(object sender, EventArgs e)
        {
            Move(kolobok);
            CheckBounds(kolobok);
            foreach (Tank tank in tanks)
            {
                Move(tank);
                CheckBounds(tank);
            }
            CheckCollisions();
            Invalidate();
        }

        private void Move(Entities entity)
        {
            if (entity.direction == Direction.RIGHT)
            {
                entity.x += 1;
            }
            else if (entity.direction == Direction.LEFT)
            {
                entity.x -= 1;
            }
            else if (entity.direction == Direction.UP)
            {
                entity.y -= 1;
            }
            else if (entity.direction == Direction.DOWN)
            {
                entity.y += 1;
            }
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Left")
            {
                kolobok.direction = Direction.LEFT;
            }
            else if (e.KeyCode.ToString() == "Right")
            {
                kolobok.direction = Direction.RIGHT;
            }
            else if (e.KeyCode.ToString() == "Up")
            {
                kolobok.direction = Direction.UP;
            }
            else if (e.KeyCode.ToString() == "Down")
            {
                kolobok.direction = Direction.DOWN;
            }
        }

        private Tank CreateTank()
        {
            while (true)
            {
                bool addTank = true;
                Tank tank = new Tank(sizeX, sizeY);
                for (int i = 0; i < tanks.Count; i++)
                {
                    if (Colides.Collides(tank.x, tank.y, tank.size, tank.size, tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size))
                    {
                        addTank = false;
                    }
                }
                if (Colides.Collides(tank.x, tank.y, tank.size, tank.size, kolobok.x - 30, kolobok.y - 30, kolobok.size + 60, kolobok.size + 60))
                {
                    addTank = false;
                }
                if (addTank)
                {
                    return tank;
                }
            }
        }

        private void TankStepDirection(object sender, EventArgs e)
        {
            Random rnd = new Random();
            foreach (Tank tank in tanks)
            {
                int directionValue = rnd.Next(1, 5);
                if (directionValue == 1)
                {
                    tank.direction = Direction.RIGHT;
                    ChangeTankImgDirection(tank, Direction.RIGHT);
                }
                else if (directionValue == 2)
                {
                    tank.direction = Direction.LEFT;
                    ChangeTankImgDirection(tank, Direction.LEFT);
                }
                else if (directionValue == 3)
                {
                    tank.direction = Direction.UP;
                    ChangeTankImgDirection(tank, Direction.UP);
                }
                else if (directionValue == 4)
                {
                    tank.direction = Direction.DOWN;
                    ChangeTankImgDirection(tank, Direction.DOWN);
                }
            }
        }

        private void CheckBounds(Entities entity)
        {
            foreach (Tank tank in tanks)
            {
                if (entity.x + entity.size > sizeX + 5)
                {
                    entity.x = sizeX + 5 - entity.size;
                    entity.direction = Direction.LEFT;
                    ChangeTankImgDirection(tank, Direction.LEFT);
                }
                else if (entity.x < 5)
                {
                    entity.x = 5;
                    entity.direction = Direction.RIGHT;
                    ChangeTankImgDirection(tank, Direction.RIGHT);
                }
                else if (entity.y < 5)
                {
                    entity.y = 5;
                    entity.direction = Direction.DOWN;
                    ChangeTankImgDirection(tank, Direction.DOWN);
                }
                else if (entity.y + entity.size > sizeY + 5)
                {
                    entity.y = sizeY + 5 - entity.size;
                    entity.direction = Direction.UP;
                    ChangeTankImgDirection(tank, Direction.UP);
                }
            }
        }

        private void ChangeTankImgDirection(Tank tank, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                tank.tankImg = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
                tank.tankImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (direction == Direction.LEFT)
            {
                tank.tankImg = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
                tank.tankImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (direction == Direction.UP)
            {
                tank.tankImg = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
            }
            else if (direction == Direction.DOWN)
            {
                tank.tankImg = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
                tank.tankImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < tanksNumber; i++)
            {
                for (int j = 0; j < tanksNumber; j++)
                {
                    if ((i != j) && (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, tanks[j].x, tanks[j].y, tanks[j].size, tanks[j].size)))
                    {
                        Direction lastDirection1 = tanks[i].direction;
                        Direction lastDirection2 = tanks[j].direction;
                        if (lastDirection1 == Direction.RIGHT)
                        {
                            tanks[i].x -= 1;
                            tanks[i].direction = Direction.LEFT;
                            ChangeTankImgDirection(tanks[i], Direction.LEFT);
                        }
                        else if (lastDirection1 == Direction.LEFT)
                        {
                            tanks[i].x += 1;
                            tanks[i].direction = Direction.RIGHT;
                            ChangeTankImgDirection(tanks[i], Direction.RIGHT);
                        }
                        else if (lastDirection1 == Direction.UP)
                        {
                            tanks[i].y -= 1;
                            tanks[i].direction = Direction.DOWN;
                            ChangeTankImgDirection(tanks[i], Direction.DOWN);
                        }
                        else if (lastDirection1 == Direction.DOWN)
                        {
                            tanks[i].y += 1;
                            tanks[i].direction = Direction.UP;
                            ChangeTankImgDirection(tanks[i], Direction.UP);
                        }

                        if (lastDirection2 == Direction.RIGHT)
                        {
                            tanks[j].x -= 1;
                            tanks[j].direction = Direction.LEFT;
                            ChangeTankImgDirection(tanks[j], Direction.LEFT);
                        }
                        else if (lastDirection2 == Direction.LEFT)
                        {
                            tanks[j].x += 1;
                            tanks[j].direction = Direction.RIGHT;
                            ChangeTankImgDirection(tanks[j], Direction.RIGHT);
                        }
                        else if (lastDirection2 == Direction.UP)
                        {
                            tanks[j].y -= 1;
                            tanks[j].direction = Direction.DOWN;
                            ChangeTankImgDirection(tanks[j], Direction.DOWN);
                        }
                        else if (lastDirection2 == Direction.DOWN)
                        {
                            tanks[j].y += 1;
                            tanks[j].direction = Direction.UP;
                            ChangeTankImgDirection(tanks[j], Direction.UP);
                        }
                    }
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(kolobok.kolobokImg, kolobok.x, kolobok.y, kolobok.size, kolobok.size);
            foreach (Tank tank in tanks)
            {
                graphics.DrawImage(tank.tankImg, tank.x, tank.y, tank.size, tank.size);
            }
            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, sizeX + 10, 5);
            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, 5, sizeY + 10);
            graphics.FillRectangle(new SolidBrush(Color.Gray), sizeX + 5, 0, sizeX + 10, sizeY + 10);
            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, sizeY + 5, sizeX + 10, sizeY + 10);
        }
    }
}
