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
        int speed = 1;
        Kolobok kolobok;
        Tank tank;
        public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate();
        }

        public void Init()
        {
            kolobok = new Kolobok(200, 200);
            tank = new Tank(300, 200);

            timer1.Interval = 20;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
        }

        private void update(object sender, EventArgs e)
        {
            kolobok.x += speed;
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(kolobok.kolobokImg, kolobok.x, kolobok.y, kolobok.size, kolobok.size);
            //tank.tankImg.RotateFlip(RotateFlipType.Rotate90FlipX);
            graphics.DrawImage(tank.tankImg, tank.x, tank.y, tank.size, tank.size);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
