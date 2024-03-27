using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class LeftCrouchingPlayerSprite : AbstractPlayerSprite
    {
        public LeftCrouchingPlayerSprite(Texture2D texture, PowerUps powerUp) : base(texture, powerUp)
        {
            sourceRectangle = new Rectangle(116, 40, 16, 24);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            base.Draw(spriteBatch, position, color);
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, (int)(sourceRectangle.Width * 2 * Globals.ScreenSizeMulti), (int)(sourceRectangle.Height * 2 * Globals.ScreenSizeMulti));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.FlipHorizontally, .02f);
        }
    }
}