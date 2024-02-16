using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class PipeSprite
    {
        private Texture2D texture;
        private readonly Rectangle TopLeftPipe = new Rectangle(119, 196, 16, 16);
        private readonly Rectangle TopRightPipe = new Rectangle(136, 196, 16, 16);
        private readonly Rectangle BottomLeftPipe = new Rectangle(119, 213, 16, 16);
        private readonly Rectangle BottomRightPipe = new Rectangle(136, 213, 16, 16);
        public PipeSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, int pipeHeight)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
            spriteBatch.Draw(texture, destinationRectangle, TopLeftPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
            destinationRectangle.X += (int)Globals.BlockSize;
            spriteBatch.Draw(texture, destinationRectangle, TopRightPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
            destinationRectangle.Y += (int)Globals.BlockSize;
            for(int i = 0; i < pipeHeight - 1; i++)
            {
                destinationRectangle.X -= (int)Globals.BlockSize;
                spriteBatch.Draw(texture, destinationRectangle, BottomLeftPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
                destinationRectangle.X += (int)Globals.BlockSize;
                spriteBatch.Draw(texture, destinationRectangle, BottomRightPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
                destinationRectangle.Y += (int)Globals.BlockSize;

            }
        }
    }
}
