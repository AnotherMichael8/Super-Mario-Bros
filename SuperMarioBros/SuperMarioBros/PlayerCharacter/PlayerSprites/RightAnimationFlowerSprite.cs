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
    public class RightAnimationFlowerSprite : AbstractPlayerSprite
    {
        private Rectangle sourceRectangle;
        private Rectangle[] spriteAnimation = { new Rectangle(80, 328, 16, 32), new Rectangle(112, 328, 16, 32), new Rectangle(48, 328, 16, 32) };
        public RightAnimationFlowerSprite(Texture2D texture, PowerUps powerUp) : base(texture, powerUp)
        {
            sourceRectangle = spriteAnimation[0];
        }

        public override void Update(int currentSpeed)
        {
            if (frameCounter >= 60)
            {
                frameCounter = 60;
            }
            else if (frameCounter == 10 || frameCounter == 25 || frameCounter == 40 || frameCounter == 55)
            {
                sourceRectangle = spriteAnimation[2];
            }
            else if (frameCounter == 5 || frameCounter == 20 || frameCounter == 35 || frameCounter == 50)
            {
                sourceRectangle = spriteAnimation[1];
            }
            else if (frameCounter == 0 || frameCounter == 15 || frameCounter == 30 || frameCounter == 45)
            {
                sourceRectangle = spriteAnimation[0];
            }
            frameCounter++;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y + (64 - sourceRectangle.Height * 2), (int)Globals.BlockSize, sourceRectangle.Height * 2);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0);
        }
    }
}
