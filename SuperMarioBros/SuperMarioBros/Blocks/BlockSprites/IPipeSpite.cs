using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockSprites
{
    public interface IPipeSprite
    {
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, int pipeHeight, ICollision enterableSide);
    }
}
