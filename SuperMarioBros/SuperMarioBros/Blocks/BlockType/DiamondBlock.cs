using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockType
{
    public class DiamondBlock : AbstractBlock
    {
        public DiamondBlock(Vector2 position) : base(position)
        {
            sourceRectangle = new Rectangle(0, 33, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
        }
    }
}
