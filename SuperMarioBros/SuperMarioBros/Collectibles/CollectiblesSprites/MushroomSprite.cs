using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles.CollectiblesSprites
{
    public class MushroomSprite : ICollectiblesSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(0, 8, 16, 16);
        public MushroomSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
        }
    }
}
