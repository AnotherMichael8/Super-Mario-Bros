using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockSprites
{
    public class SpacePipeSprite : IBlockSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(345, 382, 176, 50);
        public SpacePipeSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, SpriteEffects flip)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y - (int)(2 * 3 * Globals.ScreenSizeMulti), (int)(sourceRectangle.Width * 2 * Globals.ScreenSizeMulti), (int)((sourceRectangle.Height + 3) * 2 * Globals.ScreenSizeMulti));
            if (CameraController.CheckInFrame(destinationRectangle))
            {
                destinationRectangle.X -= CameraController.CameraPositionX;
                destinationRectangle.Y += CameraController.CameraPositionY;
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), flip, 0.01f);
            }
        }
    }
}
