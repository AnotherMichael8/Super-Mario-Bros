using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PowerUpAbilites
{
    public class FireballSprite : IPowerAbilitySprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private readonly Rectangle[] spriteAnimation = { new Rectangle(172, 77, 8, 8), new Rectangle(182, 77, 8, 8), new Rectangle(192, 77, 8, 8), new Rectangle(202, 77, 8, 8) };
        private int animateCounter;
        public FireballSprite(Texture2D texture)
        {
            this.texture = texture;
            animateCounter = 0;
            sourceRectangle = spriteAnimation[0];
        }
        public void Update()
        {
            if (animateCounter == 12)
            {
                sourceRectangle = spriteAnimation[0];
                animateCounter = 0;
            }
            else if (animateCounter == 9)
                sourceRectangle = spriteAnimation[3];
            else if (animateCounter == 6)
                sourceRectangle = spriteAnimation[2];
            else if (animateCounter == 3)
                sourceRectangle = spriteAnimation[1];
            animateCounter++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, (int)(sourceRectangle.Width * 2 * Globals.ScreenSizeMulti), (int)(sourceRectangle.Height * 2 * Globals.ScreenSizeMulti));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.None, 0.1f);
        }
    }
}
