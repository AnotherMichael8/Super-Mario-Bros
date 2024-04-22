using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class GrabPolePlayerSprite : AbstractPlayerSprite
    {
        private SpriteEffects flip;
        public GrabPolePlayerSprite(Texture2D texture, PowerUps powerUp, SpriteEffects flip) : base(texture, powerUp)
        {
            sourceRectangle = new Rectangle(136, 8 + updatePowerUpSprite, 16, 16 * heightMultiplier);
            this.flip = flip;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX, (int)position.Y + CameraController.CameraPositionY, (int)Globals.BlockSize, (int)(Globals.BlockSize * heightMultiplier));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), flip, 0);
        }
    }
}
