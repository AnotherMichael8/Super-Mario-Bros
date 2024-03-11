using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collision;
using SuperMarioBros.Collision.SideCollisionHandlers;

namespace SuperMarioBros.Blocks.BlockSprites
{
    public class HorizontalPipeSprite : IPipeSprite
    {
        private Texture2D texture;
        private readonly Rectangle HorizontalTopLeftPipe = new Rectangle(85, 230, 16, 16);
        private readonly Rectangle HorizontalTopRightPipe = new Rectangle(85, 247, 16, 16);
        private readonly Rectangle HorizontalBottomLeftPipe = new Rectangle(102, 230, 16, 16);
        private readonly Rectangle HorizontalBottomRightPipe = new Rectangle(102, 247, 16, 16);
        public HorizontalPipeSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, int pipeHeight, ICollision enterbleSide)
        {
            bool inFrame = false;
            bool onLeft = true;
            SpriteEffects spriteEffect = SpriteEffects.None;
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
            if (enterbleSide is RightCollision)
            {
                onLeft = false;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            for (int i = 0; i < pipeHeight; i++)
            {
                if (CameraController.CheckInFrame(destinationRectangle))
                {
                    inFrame = true;
                    break;
                }
                destinationRectangle.X += (int)Globals.BlockSize;
            }
            destinationRectangle.X = (int)position.X;
            if (inFrame)
            {
                destinationRectangle.X -= CameraController.CameraPosition;
                if (onLeft)
                {
                    spriteBatch.Draw(texture, destinationRectangle, HorizontalTopLeftPipe, color, 0, new Vector2(0), spriteEffect, 0.2f);
                    destinationRectangle.Y += (int)Globals.BlockSize;
                    spriteBatch.Draw(texture, destinationRectangle, HorizontalTopRightPipe, color, 0, new Vector2(0), spriteEffect, 0.2f);
                    destinationRectangle.X += (int)Globals.BlockSize;
                    destinationRectangle.Y -= (int)Globals.BlockSize;
                }
                for (int i = 0; i < pipeHeight - 1; i++)
                {
                    spriteBatch.Draw(texture, destinationRectangle, HorizontalBottomLeftPipe, color, 0, new Vector2(0), spriteEffect, 0.2f);
                    destinationRectangle.Y += (int)Globals.BlockSize;
                    spriteBatch.Draw(texture, destinationRectangle, HorizontalBottomRightPipe, color, 0, new Vector2(0), spriteEffect, 0.2f);
                    destinationRectangle.X += (int)Globals.BlockSize;
                    destinationRectangle.Y -= (int)Globals.BlockSize;
                }
                if (!onLeft)
                {
                    spriteBatch.Draw(texture, destinationRectangle, HorizontalTopLeftPipe, color, 0, new Vector2(0), spriteEffect, 0.2f);
                    destinationRectangle.Y += (int)Globals.BlockSize;
                    spriteBatch.Draw(texture, destinationRectangle, HorizontalTopRightPipe, color, 0, new Vector2(0), spriteEffect, 0.2f);
                    destinationRectangle.X += (int)Globals.BlockSize;
                }
            }
        }
    }
}
