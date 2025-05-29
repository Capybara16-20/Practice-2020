using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class ImgDirection
    {
        public static void ChangeImgDirection(Entities entity, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                entity.img = new Bitmap(@"..\..\img\tank.png");
                entity.img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (direction == Direction.LEFT)
            {
                entity.img = new Bitmap(@"..\..\img\tank.png");
                entity.img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (direction == Direction.UP)
            {
                entity.img = new Bitmap(@"..\..\img\tank.png");
            }
            else if (direction == Direction.DOWN)
            {
                entity.img = new Bitmap(@"..\..\img\tank.png");
                entity.img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
        }
    }
}
