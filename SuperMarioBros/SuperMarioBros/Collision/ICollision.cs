using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision
{
    public interface ICollision
    {
        public Vector2 UpdateDirectionPosition(int width, int height, Vector2 updatePosition);
    }
}

