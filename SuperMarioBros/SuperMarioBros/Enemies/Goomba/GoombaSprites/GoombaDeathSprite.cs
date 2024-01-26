using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies.Goomba.GoombaSprites
{
    public class GoombaDeathSprite : IEnemySprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(36, 16, 16, 16);
        public GoombaDeathSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update() {}
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width * 2, sourceRectangle.Height * 2);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.None, 0.1f);
        }
    }
}
