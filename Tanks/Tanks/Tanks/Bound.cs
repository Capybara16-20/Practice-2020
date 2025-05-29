using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class Bound
    {
        public static void CheckBounds(int sizeX, int sizeY, Entities entity)
        {
            if (entity.x + entity.size > sizeX + 5)
            {
                entity.x = sizeX + 5 - entity.size;
                entity.direction = Direction.LEFT;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.LEFT);
                }
            }
            else if (entity.x < 5)
            {
                entity.x = 5;
                entity.direction = Direction.RIGHT;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.RIGHT);
                }
            }
            else if (entity.y < 5)
            {
                entity.y = 5;
                entity.direction = Direction.DOWN;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.DOWN);
                }
            }
            else if (entity.y + entity.size > sizeY + 5)
            {
                entity.y = sizeY + 5 - entity.size;
                entity.direction = Direction.UP;
                if (entity is Tank)
                {
                    ImgDirection.ChangeImgDirection(entity, Direction.UP);
                }
            }
        }
    }
}
