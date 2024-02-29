using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class RightAnimationMushroomSprite : AbstractPlayerSprite
    {
        private Rectangle[] spriteAnimation = { new Rectangle(0, 88, 16, 16), new Rectangle(18, 80, 16, 24), new Rectangle(36, 72, 16, 32) };
        public RightAnimationMushroomSprite(Texture2D texture, PowerUps powerUp) : base(texture, powerUp)
        {
            sourceRectangle = spriteAnimation[0];
        }

        public override void Update(int currentSpeed)
        {
            if (animationCounter >= 60)
            {
                animationCounter = 60;
            }
            else if (animationCounter == 36 || animationCounter == 54)
            {
                sourceRectangle = spriteAnimation[2];
            }
            else if (animationCounter == 6 || animationCounter == 18 || animationCounter == 30 || animationCounter == 48)
            {
                sourceRectangle = spriteAnimation[1];
            }
            else if (animationCounter == 0 || animationCounter == 12 || animationCounter == 24 || animationCounter == 42)
            {
                sourceRectangle = spriteAnimation[0];
            }
            animationCounter++;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y + (64 - sourceRectangle.Height * 2), (int)Globals.BlockSize, sourceRectangle.Height * 2);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0);
        }
    }
}
