using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockType
{
    public class BreakableBrickBlock : AbstractBlock
    {
        private int bumpCounter;
        public BreakableBrickBlock(Vector2 position) : base(position)
        {
            sourceRectangle = new Rectangle(17, 16, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            bumpCounter = -6;
        }
        public override void Update()
        {
            if (bumpCounter > -6)
            {
                position.Y -= bumpCounter;
                bumpCounter--;
            }
        }
        public override void Bump()
        {
            bumpCounter = 5;
        }
    }
}
