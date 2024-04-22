using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class FlagPoleSprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle = new Rectangle(0, 588, 16, 160);
        private readonly Rectangle castleLeftSourceRectangle = new Rectangle(24, 684, 48, 80);
        public FlagPoleSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(sourceRectangle.Width * 2 * Globals.ScreenSizeMulti), (int)(sourceRectangle.Height * 2 * Globals.ScreenSizeMulti));
            Rectangle castleDestinationRect = new Rectangle((int)(position.X + Globals.BlockSize * 4), (int)(Globals.ScreenHeight - Globals.BlockSize * 2 - 160 * Globals.ScreenSizeMulti), castleLeftSourceRectangle.Width * 2, castleLeftSourceRectangle.Height * 2);
            if (CameraController.CheckInFrame(destinationRectangle))
            {
                destinationRectangle.X -= CameraController.CameraPositionX;
                destinationRectangle.Y += CameraController.CameraPositionY;
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
            }
            if (CameraController.CheckInFrame(castleDestinationRect))
            {
                castleDestinationRect.X -= CameraController.CameraPositionX;
                castleDestinationRect.Y += CameraController.CameraPositionY;
                spriteBatch.Draw(texture, castleDestinationRect, castleLeftSourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
            }

        }
    }
}
