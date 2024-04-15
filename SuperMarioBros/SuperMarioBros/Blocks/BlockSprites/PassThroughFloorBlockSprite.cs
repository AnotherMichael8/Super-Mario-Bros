using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SuperMarioBros.Blocks.BlockSprites
{
    public class PassThroughFloorBlockSprite : IBlockSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(25, 599, 16, 3);
        public PassThroughFloorBlockSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)Globals.BlockSize, (int)(sourceRectangle.Height * 2 * Globals.ScreenSizeMulti));
            if (CameraController.CheckInFrame(destinationRectangle))
            {
                destinationRectangle.X -= CameraController.CameraPositionX;
                destinationRectangle.Y += CameraController.CameraPositionY;
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.4f);
            }
        }
    }
}
