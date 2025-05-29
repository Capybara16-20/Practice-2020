using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class ChangeDirection
    {
        public static void ReverseDirection(Entities entity, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                entity.direction = Direction.LEFT;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.LEFT);
                }
            }
            else if (direction == Direction.LEFT)
            {
                entity.direction = Direction.RIGHT;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.RIGHT);
                }
            }
            else if (direction == Direction.UP)
            {
                entity.direction = Direction.DOWN;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.DOWN);
                }
            }
            else if (direction == Direction.DOWN)
            {
                entity.direction = Direction.UP;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.UP);
                }
            }
        }
    }
}
