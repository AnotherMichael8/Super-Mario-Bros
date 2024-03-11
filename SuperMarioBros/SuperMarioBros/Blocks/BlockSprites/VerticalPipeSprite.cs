using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collision;
using SuperMarioBros.Blocks.BlockSprites;

namespace SuperMarioBros.Blocks
{
    public class VerticalPipeSprite : IPipeSprite
    {
        private Texture2D texture;
        private readonly Rectangle VerticalTopLeftPipe = new Rectangle(119, 196, 16, 16);
        private readonly Rectangle VertcialTopRightPipe = new Rectangle(136, 196, 16, 16);
        private readonly Rectangle VerticalBottomLeftPipe = new Rectangle(119, 213, 16, 16);
        private readonly Rectangle VerticalBottomRightPipe = new Rectangle(136, 213, 16, 16);
        public VerticalPipeSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, int pipeHeight, ICollision enterableSide)
        {
            bool left = false; 
            bool right = false;
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
            if (CameraController.CheckInFrame(destinationRectangle))          
                left = true;       
            destinationRectangle.X += (int)Globals.BlockSize;
            if(left || CameraController.CheckInFrame(destinationRectangle))            
                right = true;
            if (left || right)
            {
                destinationRectangle.X -= (int)Globals.BlockSize + CameraController.CameraPosition;
                spriteBatch.Draw(texture, destinationRectangle, VerticalTopLeftPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
                destinationRectangle.X += (int)Globals.BlockSize;
                spriteBatch.Draw(texture, destinationRectangle, VertcialTopRightPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
                destinationRectangle.Y += (int)Globals.BlockSize;
                for (int i = 0; i < pipeHeight - 1; i++)
                {
                    destinationRectangle.X -= (int)Globals.BlockSize;
                    if(left)
                        spriteBatch.Draw(texture, destinationRectangle, VerticalBottomLeftPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
                    destinationRectangle.X += (int)Globals.BlockSize;
                    if(right)
                        spriteBatch.Draw(texture, destinationRectangle, VerticalBottomRightPipe, color, 0, new Vector2(0), SpriteEffects.None, 0.2f);
                    destinationRectangle.Y += (int)Globals.BlockSize;

                }
            }
        }
    }
}
