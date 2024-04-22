using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System.ComponentModel.Design;
using System;

namespace SuperMarioBros.Collectibles.CollectiblesSprites
{
    public class WonderSeedCollectionAnimationSprite : ICollectiblesSprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle = new Rectangle(5, 488, 36, 34);
        private int counter;
        private double dilation;
        private float opacityChanger;
        private float opacity;
        private Color auraColor;
        private bool auraColorChangerA;
        private bool auraColorChangerB;
        private float rotation;
        private float rotationUpdater;
        private double dilationUpdater;
        public WonderSeedCollectionAnimationSprite(Texture2D texture)
        {
            this.texture = texture;
            counter = 0;
            dilation = 610;
            opacityChanger = 0.003f;
            opacity = 0.4f;
            auraColor = new Color(72, 72, 255);
            auraColorChangerA = true;
            auraColorChangerB = true;
            rotation = 0;
            rotationUpdater = .005f;
            dilationUpdater = 9;
        }
        public void Update()
        {
            counter++;
            /*
            if (counter >= 120)
            {
                dilation += 10;
                opacityChanger = 0.00966f;
            }
            else if (counter >= 90)
                dilation -= 0.8;
            else if (counter >= 60)
                dilation += 0.8;
            else if (counter >= 30)
                dilation -= 0.8;
            else if (counter >= 10)
                dilation += 0.8;
            else if (counter >= 0)
                dilation += 2;
            */
            if (counter >= 190 && counter < 210)
            {
                dilation -= 5;
            }
            else if (counter >= 130 && counter < 160)
            {
                dilation -= dilationUpdater;
                dilationUpdater += dilationUpdater / 30;
            }
            else if (counter >= 100 && counter < 130 || counter >= 160 && counter < 190)
            {
                dilation += dilationUpdater;
                dilationUpdater -= dilationUpdater / 30;
                opacityChanger = 0;
            }
            else if (counter >= 0 && counter < 100)
            {
                dilation -= dilationUpdater;
                dilationUpdater -= dilationUpdater / 120;
            }

            opacity += opacityChanger;

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

            if (rotation >= .3f || rotation <= -.3f)
                rotationUpdater *= -1.8f;
            rotation += rotationUpdater;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX, (int)position.Y + CameraController.CameraPositionY, (int)Globals.BlockSize + 4, (int)Globals.BlockSize + 4);
            Vector2 origin = new Vector2(destinationRectangle.Width / 2, destinationRectangle.Height / 2);
            Rectangle auraDestinationRectangle = new Rectangle((int)(position.X - CameraController.CameraPositionX + 18 * Globals.ScreenSizeMulti), (int)(position.Y + 20 * Globals.ScreenSizeMulti) + CameraController.CameraPositionY, (int)(36 * 2 * Globals.ScreenSizeMulti) + 4 * ((int)dilation + 1), (int)(34 * 2 * Globals.ScreenSizeMulti) + 4 * ((int)dilation + 1));
            spriteBatch.Draw(texture, auraDestinationRectangle, sourceRectangle, auraColor * opacity, rotation, origin, SpriteEffects.None, 0f);
        }
    }
}
