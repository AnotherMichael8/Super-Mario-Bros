using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Blocks.BlockSprites;

namespace SuperMarioBros.Blocks.BlockType
{
    public class PassThroughFloorBlock : AbstractBlock
    {
        private int width;
        private PassThroughFloorBlockSprite passSprite;
        public PassThroughFloorBlock(Vector2 position, int width) : base(position)
        {
            sourceRectangle = new Rectangle(0, 33, 16, 16);
            passSprite = BlockSpriteFactory.Instance.CreatePassThroughFloorBlockSprite();
            this.width = width;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            for (int w = 0; w < width; w++)
            {
                passSprite.Draw(spriteBatch, new Vector2((int)Position.X + (int)(Globals.BlockSize * w), (int)Position.Y), color);
            }
        }
        public override Rectangle GetHitBox()
        {
            Rectangle hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(Globals.BlockSize * width), (int)(Globals.BlockSize));
            if (CameraController.CheckInFrame(hitBox))
                return hitBox;
            else
                return Rectangle.Empty;
        }
    }
}
