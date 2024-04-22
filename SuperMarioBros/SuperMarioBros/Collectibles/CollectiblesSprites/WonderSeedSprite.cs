using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SuperMarioBros.Collectibles.CollectiblesSprites
{
    public class WonderSeedSprite : ICollectiblesSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(0, 60, 18, 18);
        private readonly Rectangle flowerAuraSourceRectangle = new Rectangle(5, 488, 36, 34);
        private double dilation;
        private double dilationChanger;
        private Color auraColor;
        private bool auraColorChangerA;
        private bool auraColorChangerB;
        private float rotation;
        private float rotationUpdater;
        private bool wonderSeedCollected;
        private float opacity;
        private int opacityCounter;
        public WonderSeedSprite(Texture2D texture)
        {
            this.texture = texture;
            dilation = 0.05;
            dilationChanger = 0.15;
            auraColor = new Color(72, 72, 255);
            auraColorChangerA = true;
            auraColorChangerB = true;
            rotation = 0;
            rotationUpdater = .0025f;
            opacity = 1;
            wonderSeedCollected = false;
            opacityCounter = 0;
        }
        public void Update(bool wonderSeedCollected)
        {
            if (dilation >= 5 || dilation <= 0)
            {
                dilationChanger *= -1;
            }
            dilation += dilationChanger;
            if (auraColorChangerA)
                auraColor.A += 2;
            else
                auraColor.A -= 2;
            if (auraColorChangerB)
                auraColor.B += 2;
            else
                auraColor.B -= 2;
            if (auraColor.A >= 210)
                auraColorChangerA = false;
            else if (auraColor.B <= 72)
                auraColorChangerA = true;
            if (auraColor.B >= 210)
                auraColorChangerB = false;
            else if (auraColor.B <= 72)
                auraColorChangerB = true;

            if (rotation >= .2f || rotation <= -.2f)
                rotationUpdater *= -1;
            rotation += rotationUpdater;

            if (wonderSeedCollected)
            {
                this.wonderSeedCollected = true;
                opacityCounter++;
            }
            if (opacityCounter > 160)
                opacity -= 0.05f;
        }
        public void Update()
        {
            Update(false);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX, (int)position.Y + CameraController.CameraPositionY, (int)Globals.BlockSize + 4, (int)Globals.BlockSize + 4);
            Vector2 origin = new Vector2(destinationRectangle.Width / 2, destinationRectangle.Height / 2);
            Rectangle auraDestinationRectangle = new Rectangle((int)(position.X - CameraController.CameraPositionX + 18 * Globals.ScreenSizeMulti), (int)(position.Y + 20 * Globals.ScreenSizeMulti) + CameraController.CameraPositionY, (int)(36 * 2 * Globals.ScreenSizeMulti) + 4 * ((int)dilation + 1), (int)(34 * 2 * Globals.ScreenSizeMulti) + 4 * ((int)dilation + 1));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color * opacity, 0, new Vector2(0), SpriteEffects.None, 0.299f);
            if (!wonderSeedCollected)
                spriteBatch.Draw(texture, auraDestinationRectangle, flowerAuraSourceRectangle, auraColor, rotation, origin, SpriteEffects.None, 0.301f);
        }

    }
}
