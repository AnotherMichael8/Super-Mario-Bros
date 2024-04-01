using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles.CollectiblesSprites
{
    public class CoinSprite : ICollectiblesSprite
    {
        private Texture2D texture;
        private readonly Rectangle[] spriteAnimation = { new Rectangle(180, 36, 8, 16), new Rectangle(190, 36, 8, 16), new Rectangle(200, 36, 8, 16), new Rectangle(210, 36, 8, 16) };
        private Rectangle sourceRectangle;
        private int animateCounter;
        public CoinSprite(Texture2D texture)
        {
            this.texture = texture;
            sourceRectangle = spriteAnimation[0];
            animateCounter = 0;
        }
        public void Update()
        {
            if (animateCounter >= 12)
            {
                sourceRectangle = spriteAnimation[0];
                animateCounter = 0;
            }
            else if (animateCounter > 9)
                sourceRectangle = spriteAnimation[3];
            else if (animateCounter > 6)
                sourceRectangle = spriteAnimation[2];
            else if (animateCounter > 3)
                sourceRectangle = spriteAnimation[1];
            animateCounter++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX, (int)position.Y + CameraController.CameraPositionY, (int)Globals.BlockSize/2, (int)Globals.BlockSize);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
        }
    }
}
