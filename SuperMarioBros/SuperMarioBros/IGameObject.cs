using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public interface IGameObject
    {
        public int chunk { get; }
        public Rectangle GetHitBox();
    }
}
