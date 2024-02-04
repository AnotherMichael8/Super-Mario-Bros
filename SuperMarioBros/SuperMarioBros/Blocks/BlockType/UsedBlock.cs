using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockType
{
    public class UsedBlock : AbstractBlock
    {
        public UsedBlock(Vector2 position) : base(position)
        {
            sourceRectangle = new Rectangle(51, 16, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
        }
    }
}
