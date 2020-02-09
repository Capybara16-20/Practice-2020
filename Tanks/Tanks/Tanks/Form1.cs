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
        int score = 0;
        int tanksNumber;
        int applesNumber;
        int sizeX;
        int sizeY;
        int speed;
        Kolobok kolobok;
        List<Tank> tanks = new List<Tank>();
        List<Apple> apples = new List<Apple>();
        List<Bullet> bullets;
        List<bool> bulletDisappeared;
        bool started = false;

        public Form1(int sizeX, int sizeY, int tanksNumber, int applesNumber, int speed)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.tanksNumber = tanksNumber;
            this.applesNumber = applesNumber;
            this.speed = speed;
            this.MinimumSize = new Size(sizeX + 26, sizeY + 49);
            this.MaximumSize = new Size(sizeX + 26, sizeY + 49);
            this.BackgroundImage = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\background.png");
            InitializeComponent();
            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OKP);
            Init();
            Invalidate();
        }

        public void Init()
        {
            kolobok = new Kolobok(10, sizeY - 60);
            kolobok.direction = Direction.RIGHT;
            bulletDisappeared = new List<bool>();
            bullets = new List<Bullet>();
            for (int i = 0; i < tanksNumber + 1; i++)
            {
                if (i == 0)
                {
                    bullets.Add(new Bullet(new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\blueBullet.png")));
                }
                else
                {
                    bullets.Add(new Bullet(new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\greenBullet.png")));
                }
                bulletDisappeared.Add(true);
            }
            while (tanks.Count < tanksNumber)
            {
                tanks.Add(CreateTank());
            }
            while (apples.Count < applesNumber)
            {
                apples.Add(CreateApple());
            }

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(TankStepDirection);
            timer2.Start();
        }

        private void update(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score;
            if (started)
            {
                Move(kolobok);
                CheckBounds(kolobok);
                foreach (Tank tank in tanks)
                {
                    Move(tank);
                    CheckBounds(tank);
                }
                foreach (Bullet bullet in bullets)
                {
                    Move(bullet);
                }
                for (int i = 0; i < tanksNumber + 1; i++)
                {
                    bulletDisappeared[i] = BulletDisappearance(bullets[i]);
                }
                CheckCollisions();
                Invalidate();
            }
        }

        private void Move(Entities entity)
        {
            if (entity.direction == Direction.RIGHT)
            {
                entity.x += speed;
                if (entity is Bullet)
                {
                    entity.x += speed * 2;
                }
            }
            else if (entity.direction == Direction.LEFT)
            {
                entity.x -= speed;
                if (entity is Bullet)
                {
                    entity.x -= speed * 2;
                }
            }
            else if (entity.direction == Direction.UP)
            {
                entity.y -= speed;
                if (entity is Bullet)
                {
                    entity.y -= speed * 2;
                }
            }
            else if (entity.direction == Direction.DOWN)
            {
                entity.y += speed;
                if (entity is Bullet)
                {
                    entity.y += speed * 2;
                }
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
            else if (e.KeyCode.ToString() == "Space")
            {
                if (bulletDisappeared[0])
                {
                    bullets[0].x = kolobok.x + kolobok.size / 2 - bullets[0].size / 2;
                    bullets[0].y = kolobok.y + kolobok.size / 2 - bullets[0].size / 2;
                    bullets[0].direction = kolobok.direction;
                    bulletDisappeared[0] = false;
                }
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

        private Apple CreateApple()
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

        private void TankStepDirection(object sender, EventArgs e)
        {
            Random rnd = new Random();
            foreach (Tank tank in tanks)
            {
                int directionValue = rnd.Next(1, 5);
                if (directionValue == 1)
                {
                    tank.direction = Direction.RIGHT;
                    ChangeImgDirection(tank, Direction.RIGHT);
                }
                else if (directionValue == 2)
                {
                    tank.direction = Direction.LEFT;
                    ChangeImgDirection(tank, Direction.LEFT);
                }
                else if (directionValue == 3)
                {
                    tank.direction = Direction.UP;
                    ChangeImgDirection(tank, Direction.UP);
                }
                else if (directionValue == 4)
                {
                    tank.direction = Direction.DOWN;
                    ChangeImgDirection(tank, Direction.DOWN);
                }
            }
        }

        private bool BulletDisappearance(Bullet bullet)
        {
            return ((bullet.x > sizeX + 10) || (bullet.x < -20) || (bullet.y < -20) || (bullet.y > sizeY + 10));
        }

        private void CheckBounds(Entities entity)
        {
            if (entity.x + entity.size > sizeX + 5)
            {
                entity.x = sizeX + 5 - entity.size;
                entity.direction = Direction.LEFT;
                if (entity is Tank)
                {
                    ChangeImgDirection(entity, Direction.LEFT);
                }
            }
            else if (entity.x < 5)
            {
                entity.x = 5;
                entity.direction = Direction.RIGHT;
                if (entity is Tank)
                {
                    ChangeImgDirection(entity, Direction.RIGHT);
                }
            }
            else if (entity.y < 5)
            {
                entity.y = 5;
                entity.direction = Direction.DOWN;
                if (entity is Tank)
                {
                    ChangeImgDirection(entity, Direction.DOWN);
                }
            }
            else if (entity.y + entity.size > sizeY + 5)
            {
                entity.y = sizeY + 5 - entity.size;
                entity.direction = Direction.UP;
                if (entity is Tank)
                {
                    ChangeImgDirection(entity, Direction.UP);
                }
            }
        }

        private void ChangeImgDirection(Entities entity, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                entity.img = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
                entity.img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (direction == Direction.LEFT)
            {
                entity.img = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
                entity.img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (direction == Direction.UP)
            {
                entity.img = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
            }
            else if (direction == Direction.DOWN)
            {
                entity.img = new Bitmap(@"C:\Users\user\Desktop\Папка\EPAM\Внутренние курсы\Practice-2020\Tanks\Tanks\Tanks\img\tank.png");
                entity.img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < tanks.Count; j++)
                {
                    if ((i != j) && (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, tanks[j].x, tanks[j].y, tanks[j].size, tanks[j].size)))
                    {
                        Direction lastDirection1 = tanks[i].direction;
                        Direction lastDirection2 = tanks[j].direction;
                        Rectangle rect1 = new Rectangle(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size);
                        Rectangle rect2 = new Rectangle(tanks[j].x, tanks[j].y, tanks[j].size, tanks[j].size);
                        Rectangle intersect = Rectangle.Intersect(rect1, rect2);
                        if (intersect.Width >= intersect.Height)
                        {
                            if (tanks[i].y >= tanks[j].y)
                            {
                                tanks[i].y += intersect.Height / 2;
                                tanks[j].y -= intersect.Height / 2;
                            }
                            else
                            {
                                tanks[i].y -= intersect.Height / 2;
                                tanks[j].y += intersect.Height / 2;
                            }
                        }
                        else
                        {
                            if (tanks[i].x >= tanks[j].x)
                            {
                                tanks[i].x += intersect.Height / 2;
                                tanks[j].x -= intersect.Height / 2;
                            }
                            else
                            {
                                tanks[i].x -= intersect.Height / 2;
                                tanks[j].x += intersect.Height / 2;
                            }
                        }
                        if (lastDirection1 == Direction.RIGHT)
                        {
                            tanks[i].direction = Direction.LEFT;
                            ChangeImgDirection(tanks[i], Direction.LEFT);
                        }
                        else if (lastDirection1 == Direction.LEFT)
                        {
                            tanks[i].direction = Direction.RIGHT;
                            ChangeImgDirection(tanks[i], Direction.RIGHT);
                        }
                        else if (lastDirection1 == Direction.UP)
                        {
                            tanks[i].direction = Direction.DOWN;
                            ChangeImgDirection(tanks[i], Direction.DOWN);
                        }
                        else if (lastDirection1 == Direction.DOWN)
                        {
                            tanks[i].direction = Direction.UP;
                            ChangeImgDirection(tanks[i], Direction.UP);
                        }

                        if (lastDirection2 == Direction.RIGHT)
                        {
                            tanks[j].direction = Direction.LEFT;
                            ChangeImgDirection(tanks[j], Direction.LEFT);
                        }
                        else if (lastDirection2 == Direction.LEFT)
                        {
                            tanks[j].direction = Direction.RIGHT;
                            ChangeImgDirection(tanks[j], Direction.RIGHT);
                        }
                        else if (lastDirection2 == Direction.UP)
                        {
                            tanks[j].direction = Direction.DOWN;
                            ChangeImgDirection(tanks[j], Direction.DOWN);
                        }
                        else if (lastDirection2 == Direction.DOWN)
                        {
                            tanks[j].direction = Direction.UP;
                            ChangeImgDirection(tanks[j], Direction.UP);
                        }
                    }
                }
                if (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, bullets[0].x, bullets[0].y, bullets[0].size, bullets[0].size))
                {
                    bullets[0].x = -20;
                    bullets[0].y = -20;
                    bullets[0].direction = Direction.UP;
                    tanks.Remove(tanks[i]);
                    tanks.Add(CreateTank());
                }
                if (Colides.Collides(tanks[i].x, tanks[i].y, tanks[i].size, tanks[i].size, kolobok.x, kolobok.y, kolobok.size, kolobok.size))
                {
                    GameOver();
                }
            }
            for (int i = 0; i < apples.Count; i++)
            {
                if (Colides.Collides(apples[i].x, apples[i].y, apples[i].size, apples[i].size, kolobok.x, kolobok.y, kolobok.size, kolobok.size))
                {
                    apples.Remove(apples[i]);
                    score += 1;
                    apples.Add(CreateApple());
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(kolobok.img, kolobok.x, kolobok.y, kolobok.size, kolobok.size);
            foreach (Tank tank in tanks)
            {
                graphics.DrawImage(tank.img, tank.x, tank.y, tank.size, tank.size);
            }
            foreach (Apple apple in apples)
            {
                graphics.DrawImage(apple.img, apple.x, apple.y, apple.size, apple.size);
            }
            foreach (Bullet bullet in bullets)
            {
                graphics.DrawImage(bullet.img, bullet.x, bullet.y, bullet.size, bullet.size);
            }
            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, sizeX + 10, 5);
            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, 5, sizeY + 10);
            graphics.FillRectangle(new SolidBrush(Color.Gray), sizeX + 5, 0, sizeX + 10, sizeY + 10);
            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, sizeY + 5, sizeX + 10, sizeY + 10);
        }

        private void GameOver()
        {
            started = false;
            gameOverLabel.Show();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            score = 0;
            started = true;
            startButton.Hide();
        }
    }
}
