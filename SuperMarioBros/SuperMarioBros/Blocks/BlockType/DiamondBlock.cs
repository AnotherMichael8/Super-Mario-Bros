using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Camera;

namespace SuperMarioBros.Blocks.BlockType
{
    public class DiamondBlock : AbstractBlock
    {
        private int height;
        public DiamondBlock(Vector2 position, int height) : base(position)
        {
            sourceRectangle = new Rectangle(0, 33, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            this.height = height;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            for (int h = 0; h < height; h++)
            {
                sprite.Draw(spriteBatch, sourceRectangle, new Vector2((int)Position.X, (int)Position.Y + (int)(Globals.BlockSize * h)), color);
            }
        }
        public override Rectangle GetHitBox()
        {
            Rectangle hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)(Globals.BlockSize * height));
            if (CameraController.CheckInFrame(hitBox))
                return hitBox;
            else
                return Rectangle.Empty;
        }
    }
}
