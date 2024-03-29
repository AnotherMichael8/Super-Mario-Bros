using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles.CollectiblesSprites
{
    internal class WonderFlowerSprite : ICollectiblesSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(0, 43, 16, 16);
        private readonly Rectangle flowerAuraSourceRectangle = new Rectangle(5, 488, 36, 34);
        private double dilation;
        private double dilationChanger;
        private Color auraColor;
        private bool auraColorChangerA;
        private bool auraColorChangerB;
        public WonderFlowerSprite(Texture2D texture)
        {
            this.texture = texture;
            dilation = 0.05;
            dilationChanger = 0.2;
            auraColor = new Color(0, 96, 255);
            auraColorChangerA = true;
            auraColorChangerB = true;
        }
        public void Update()
        {
            if (dilation >= 7 || dilation <= 0)
            {
                dilationChanger *= -1;
            }
            dilation += dilationChanger;
            if(auraColorChangerA)
                auraColor.A += 2;
            else
                auraColor.A -= 2;
            if(auraColorChangerB)
                auraColor.B += 2;
            else
                auraColor.B -= 2;
            if (auraColor.A >= 255)
                auraColorChangerA = false;
            else if (auraColor.B <= 0)
                auraColorChangerA = true;
            if(auraColor.B >= 255)
                auraColorChangerB = false;
            else if (auraColor.B <= 96)
                auraColorChangerB = true;    
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, (int)Globals.BlockSize + 4, (int)Globals.BlockSize + 4);
            Rectangle auraDestinationRectangle = new Rectangle((int)(position.X - CameraController.CameraPosition - 20 * Globals.ScreenSizeMulti) - (int)dilation * 2, (int)(position.Y - 18 * Globals.ScreenSizeMulti) - (int)dilation * 2, (int)(36 * 2 * Globals.ScreenSizeMulti) + 4 * ((int)dilation + 1), (int)(34 * 2 * Globals.ScreenSizeMulti) + 4 * ((int)dilation + 1));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.3f);
            spriteBatch.Draw(texture, auraDestinationRectangle, flowerAuraSourceRectangle, auraColor, 0, new Vector2(0), SpriteEffects.None, 0.3f);
        }
    }
}
