using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class LeftMovingPlayerSprite : IPlayerSprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private readonly Rectangle[] spriteAnimation = { new Rectangle(20, 8, 16, 16), new Rectangle(38, 8, 16, 16), new Rectangle(56, 8, 16, 16) };
        private int frameCounter;
        public LeftMovingPlayerSprite(Texture2D texture)
        {
            this.texture = texture;
            frameCounter = 0;
            sourceRectangle = spriteAnimation[0];
        }

        public void Update(int currentSpeed)
        {
            if (frameCounter >= 24 - 3 * currentSpeed)
            {
                frameCounter = 0;
                sourceRectangle = spriteAnimation[0];
            }
            else if (frameCounter >= 16 - 2 * currentSpeed)
            {
                sourceRectangle = spriteAnimation[1];
            }
            else if (frameCounter >= 8 - currentSpeed)
            {
                sourceRectangle = spriteAnimation[2];
            }
            frameCounter++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.FlipHorizontally, 0);
        }
    }
}
