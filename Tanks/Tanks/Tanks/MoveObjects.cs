using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public static class MoveObjects
    {
        public static void Move(Entities entity, int speed)
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
    }
}
