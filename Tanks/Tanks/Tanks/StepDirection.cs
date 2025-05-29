using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class StepDirection
    {
        public static void TankStepDirection(List<Tank> tanks)
        {
            Random rnd = new Random();
            foreach (Tank tank in tanks)
            {
                int directionValue = rnd.Next(1, 5);
                if (directionValue == 1)
                {
                    tank.direction = Direction.RIGHT;
                    ImgDirection.ChangeImgDirection(tank, Direction.RIGHT);
                }
                else if (directionValue == 2)
                {
                    tank.direction = Direction.LEFT;
                    ImgDirection.ChangeImgDirection(tank, Direction.LEFT);
                }
                else if (directionValue == 3)
                {
                    tank.direction = Direction.UP;
                    ImgDirection.ChangeImgDirection(tank, Direction.UP);
                }
                else if (directionValue == 4)
                {
                    tank.direction = Direction.DOWN;
                    ImgDirection.ChangeImgDirection(tank, Direction.DOWN);
                }
            }
        }
    }
}
