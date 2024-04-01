using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class DebrisSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(304, 112, 8, 8);
        private SpriteEffects spriteEffect;
        private int cnt;
        public DebrisSprite(Texture2D texture, SpriteEffects spriteEffect)
        {
            this.texture = texture;
            this.spriteEffect = spriteEffect;
            cnt = 0;
        }
        public void Update()
        {
            if (cnt > 5)
            {
                switch (spriteEffect)
                {
                    case SpriteEffects.None:
                        spriteEffect = SpriteEffects.FlipHorizontally;
                        break;
                    case SpriteEffects.FlipHorizontally:
                        spriteEffect = SpriteEffects.None;
                        break;
                    case SpriteEffects.FlipVertically:
                        spriteEffect = SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally;
                        break;
                    case SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally:
                        spriteEffect = SpriteEffects.FlipVertically;
                        break;
                }
                cnt = 0;
            }
            cnt++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(16 * Globals.ScreenSizeMulti), (int)(16 * Globals.ScreenSizeMulti));
            if (CameraController.CheckInFrame(destinationRectangle))
            {
                destinationRectangle.X -= CameraController.CameraPositionX;
                destinationRectangle.Y += CameraController.CameraPositionY;
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), spriteEffect, 0f);
            }
        }
    }
}
