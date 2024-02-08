using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class GroundBlock : AbstractBlock
    {
        private int width;
        private int height;
        public GroundBlock(Vector2 position, int width, int height) : base(position)
        {
            sourceRectangle = new Rectangle(0, 16, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            this.width = width;
            this.height = height;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            for(int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    sprite.Draw(spriteBatch, sourceRectangle, new Vector2((int)position.X + (int)(Globals.BlockSize * w), (int)position.Y + (int)(Globals.BlockSize * h)), color);
                }
            }
        }
        public override Rectangle GetHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)(Globals.BlockSize * width), (int)(Globals.BlockSize * height));
        }
    }
}
