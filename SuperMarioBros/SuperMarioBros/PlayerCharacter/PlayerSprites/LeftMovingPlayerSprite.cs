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
    public class LeftMovingPlayerSprite : IPlayerSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle();
        private Rectangle destinationRectangle;
        private int frameCounter;
        public LeftMovingPlayerSprite(Texture2D texture)
        {
            this.texture = texture;
            frameCounter = 0;
        }

        public void Update()
        {
            frameCounter++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
        }
    }
}
