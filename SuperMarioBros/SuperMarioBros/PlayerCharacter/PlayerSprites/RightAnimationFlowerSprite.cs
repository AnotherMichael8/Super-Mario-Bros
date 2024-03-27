using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class RightAnimationFlowerSprite : AbstractPlayerSprite
    {
        private Rectangle[] spriteAnimation = { new Rectangle(80, 328, 16, 32), new Rectangle(112, 328, 16, 32), new Rectangle(48, 328, 16, 32) };
        public RightAnimationFlowerSprite(Texture2D texture, PowerUps powerUp, IPlayerSprite previousSprite) : base(texture, powerUp)
        {
            sourceRectangle = previousSprite.sourceRectangle;
            animationCounter = 60;
        }

        public override void Update(int currentSpeed)
        {
            if (animationCounter == 10 || animationCounter == 25 || animationCounter == 40 || animationCounter == 55)
            {
                UpdatePlayersColor(FlowerAnimColors[2]);
            }
            else if (animationCounter == 5 || animationCounter == 20 || animationCounter == 35 || animationCounter == 50)
            {
                UpdatePlayersColor(FlowerAnimColors[1]);
            }
            else if (animationCounter == 15 || animationCounter == 30 || animationCounter == 45)
            {
                UpdatePlayersColor(FlowerAnimColors[0]);
            }
            else if (animationCounter == 60)
            {
                UpdatePlayersColor(FlowerAnimColors[0]);
            }
            animationCounter--;
            if (animationCounter == 0)
            {
                updatePowerUpSprite = 132;
                PlayerSpriteFactory.Instance.RevertTextureData();
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y + (64 - sourceRectangle.Height * 2), (int)Globals.BlockSize, sourceRectangle.Height * 2);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.None, .02f);
        }
    }
}
