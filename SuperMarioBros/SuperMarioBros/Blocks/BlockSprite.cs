using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class BlockSprite
    {
        private Texture2D texture;
        public BlockSprite(Texture2D texture) 
        { 
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle sourceRectangle, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, Globals.BlockSize, Globals.BlockSize);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
        }
    }
}
