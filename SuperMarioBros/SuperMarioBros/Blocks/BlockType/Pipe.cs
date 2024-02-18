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
    public class Pipe : AbstractBlock
    {
        private int height;
        private PipeSprite pipeSprite;
        public Pipe(Vector2 position, int height) : base(position)
        {
            sourceRectangle = new Rectangle(0, 16, 16, 16);
            pipeSprite = BlockSpriteFactory.Instance.CreatePipeSprite();
            this.height = height;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            pipeSprite.Draw(spriteBatch, Position, color, height);
        } 
        public override Rectangle GetHitBox()
        {
            Rectangle hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(Globals.BlockSize * 2), (int)(Globals.BlockSize * height));
            if (CameraController.CheckInFrame(hitBox))
                return hitBox;
            else
                return Rectangle.Empty;
        }
    }
}
