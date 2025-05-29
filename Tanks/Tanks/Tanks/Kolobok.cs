using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks
{
    public class Kolobok : Entities
    {
        public Kolobok(int x, int y)
        {
            this.img = new Bitmap(@"..\..\img\kolobok.png");
            this.x = x;
            this.y = y;
            size = 60; 
        }

        public void Control(KeyEventArgs e, int sizeX, int sizeY, Bullet bullet)
        {
            if (e.KeyCode.ToString() == "Left")
            {
                direction = Direction.LEFT;
            }
            else if (e.KeyCode.ToString() == "Right")
            {
                direction = Direction.RIGHT;
            }
            else if (e.KeyCode.ToString() == "Up")
            {
                direction = Direction.UP;
            }
            else if (e.KeyCode.ToString() == "Down")
            {
                direction = Direction.DOWN;
            }
            else if (e.KeyCode.ToString() == "Space")
            {
                if (bullet.BulletDisappearance(sizeX, sizeY))
                {
                    bullet.x = x + size / 2 - bullet.size / 2;
                    bullet.y = y + size / 2 - bullet.size / 2;
                    bullet.direction = direction;
                }
            }
        }
    }
}
