using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collectibles;

namespace SuperMarioBros.Blocks.BlockType
{
    public class BreakableBrickBlock : AbstractBlock
    {
        private int bumpCounter;
        private ICollectibles collectible;
        public BreakableBrickBlock(Vector2 position, ICollectibles collectible) : base(position)
        {
            sourceRectangle = new Rectangle(17, 16, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            bumpCounter = -6;
            this.collectible = collectible;
        }
        public override void Update()
        {
            if (bumpCounter > -6)
            {
                Position = new Vector2(Position.X, Position.Y - (int)(bumpCounter * (Globals.BlockSize / 32)));
                bumpCounter--;
            }
        }
        public override void Bump()
        {
            bumpCounter = 5;
        }
    }
}
