using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public interface IBlock
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Color color);
    }
}
