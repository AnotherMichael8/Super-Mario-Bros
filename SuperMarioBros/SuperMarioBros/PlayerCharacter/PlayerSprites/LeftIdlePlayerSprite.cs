using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class LeftIdlePlayerSprite : IPlayerSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(0, 8, 16, 16);
        private int frameCounter;
        public LeftIdlePlayerSprite(Texture2D texture)
        {
            this.texture = texture;
            frameCounter = 0;
        }

        public void Update(int currentSpeed)
        {
            frameCounter++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width * 2, sourceRectangle.Height * 2);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.FlipHorizontally, 0);
        }
    }
}