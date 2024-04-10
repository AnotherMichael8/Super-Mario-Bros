using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMarioBros.PlayerCharacter.Interfaces.PowerUp; 

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class WonderOrbPlayerSprite : AbstractPlayerSprite
    {
        private readonly Rectangle[] spriteAnimation = { new Rectangle(0, 224, 12, 11), new Rectangle(13, 224, 12, 11), new Rectangle(26, 224, 12, 11), new Rectangle(39, 224, 12, 11), new Rectangle(52, 224, 12, 11) };
        private int animCounter;
        private double dilation;
        private double dilationUpdater;
        private float rotation;
        private float rotationUpdater;
        private int frameCounter;
        public WonderOrbPlayerSprite(Texture2D texture, PowerUps powerUp) : base(texture, powerUp)
        {
            sourceRectangle = spriteAnimation[0];
            animCounter = 0;
            rotation = 0;
            rotationUpdater = .0025f;
            dilationUpdater = .03;
            dilation = 0;
            frameCounter = 0;
        }
        public override void Update(int currentSpeed)
        {
            if (animCounter == 5)
                sourceRectangle = spriteAnimation[1];
            else if (animCounter == 10)
                sourceRectangle = spriteAnimation[2];
            else if(animCounter == 15)
                sourceRectangle = spriteAnimation[3];
            else if (animCounter == 20)
                sourceRectangle = spriteAnimation[4];
            else if(animCounter == 25)
            {
                sourceRectangle = spriteAnimation[0];
                animCounter = 0;
            }

            if (rotation >= .08f || rotation <= -.08f)
                rotationUpdater *= -1;
            rotation += rotationUpdater;

            if (frameCounter < 110)
            {
                if (frameCounter < 10)
                    dilation += 0.11;
                else if (dilation >= 2 || dilation <= 1)
                {
                    dilationUpdater *= -1;
                    dilation += dilationUpdater;
                }
                else
                    dilation += dilationUpdater;
            }
            else if (frameCounter <= 120)
                dilation -= 0.1818;
            animCounter++;
            frameCounter++;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX + 12, (int)position.Y + CameraController.CameraPositionY + 12, (int)(sourceRectangle.Height * Globals.ScreenSizeMulti * 2 * dilation), (int)(sourceRectangle.Height * Globals.ScreenSizeMulti * 2 * dilation));
            Vector2 origin = new Vector2(6, 5.5f);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White * 0.7f, rotation, origin, SpriteEffects.None, 0f);
        }
    }
}
