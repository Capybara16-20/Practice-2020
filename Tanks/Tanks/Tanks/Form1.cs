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
        int riversNumber;
        int wallsNumber;
        int sizeX;
        int sizeY;
        int speed;
        Kolobok kolobok;
        List<Tank> tanks = new List<Tank>();
        List<Apple> apples = new List<Apple>();
        List<Bullet> bullets;
        List<River> rivers = new List<River>();
        List<Wall> walls = new List<Wall>();
        bool started = false;
        bool isGameOver = false;

        public Form1(int sizeX, int sizeY, int tanksNumber, int applesNumber, int riversNumber, int bricksNumber, int speed)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.tanksNumber = tanksNumber;
            this.applesNumber = applesNumber;
            this.riversNumber = riversNumber;
            this.wallsNumber = bricksNumber;
            this.speed = speed;
            this.MinimumSize = new Size(sizeX + 26, sizeY + 49);
            this.MaximumSize = new Size(sizeX + 26, sizeY + 49);
            this.BackgroundImage = new Bitmap(@"..\..\img\background.png");
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
            bullets = new List<Bullet>();
            for (int i = 0; i < tanksNumber + 1; i++)
            {
                if (i == 0)
                {
                    bullets.Add(new Bullet(new Bitmap(@"..\..\img\blueBullet.png")));
                }
                else
                {
                    bullets.Add(new Bullet(new Bitmap(@"..\..\img\greenBullet.png")));
                }
            }
            while (tanks.Count < tanksNumber)
            {
                tanks.Add(CreateEntity.CreateTank(sizeX, sizeY, kolobok, tanks, apples, rivers, walls));
            }
            while (apples.Count < applesNumber)
            {
                apples.Add(CreateEntity.CreateApple(sizeX, sizeY, kolobok, tanks, apples, rivers, walls));
            }
            while (rivers.Count < riversNumber)
            {
                rivers.Add(CreateEntity.CreateRiver(sizeX, sizeY, kolobok, tanks, apples, rivers, walls));
            }
            while (walls.Count < wallsNumber)
            {
                walls.Add(CreateEntity.CreateWall(sizeX, sizeY, kolobok, tanks, apples, rivers, walls));
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
                MoveObjects.Move(kolobok, speed);
                Bound.CheckBounds(sizeX, sizeY, kolobok);
                foreach (Tank tank in tanks)
                {
                    MoveObjects.Move(tank, speed);
                    Bound.CheckBounds(sizeX, sizeY, tank);
                }
                foreach (Bullet bullet in bullets)
                {
                    MoveObjects.Move(bullet, speed);
                }
                for (int i = 1; i < tanksNumber + 1; i++)
                {
                    tanks[i - 1].TankShooting(bullets[i], bullets[i].BulletDisappearance(sizeX, sizeY));
                }
                Collisions.CheckCollisions(sizeX, sizeY, tanks, bullets, apples, rivers, walls, kolobok, ref score, ref isGameOver);
                if (isGameOver)
                {
                    GameOver();
                }
                Invalidate();
            }
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            kolobok.Control(e, sizeX, sizeY, bullets[0]);
        }

        private void TankStepDirection(object sender, EventArgs e)
        {
            StepDirection.TankStepDirection(tanks);
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
            foreach (River river in rivers)
            {
                graphics.DrawImage(river.img, river.x, river.y, river.size, river.size);
            }
            foreach (Wall wall in walls)
            {
                graphics.DrawImage(wall.img, wall.x, wall.y, wall.size, wall.size);
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
            KeyPreview = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            score = 0;
            started = true;
            startButton.Hide();
            startButton.Enabled = false;
        }
    }
}
