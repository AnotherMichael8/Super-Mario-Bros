﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class RightMovingPlayerSprite : AbstractPlayerSprite
    {
        private Rectangle[] spriteAnimation = { new Rectangle(20, 8, 16, 16), new Rectangle(38, 8, 16, 16), new Rectangle(56, 8, 16, 16) };
        public RightMovingPlayerSprite(Texture2D texture, PowerUps powerUp) : base(texture, powerUp)
        {
            for (int i = 0; i < spriteAnimation.Length; i++)
            {
                spriteAnimation[i].Y += updatePowerUpSprite;
                spriteAnimation[i].Height *= heightMultiplier;
            }
            sourceRectangle = spriteAnimation[0];
        }

        public override void Update(int currentSpeed)
        {
            base.Update(currentSpeed);
            if (animationCounter >= 24 - 3 * currentSpeed)
            {
                animationCounter = 0;
                sourceRectangle = spriteAnimation[0];
            }
            else if(animationCounter >= 16 - 2 * currentSpeed)
            {
                sourceRectangle = spriteAnimation[1];
            }
            else if(animationCounter >= 8 - currentSpeed)
            {
                sourceRectangle = spriteAnimation[2];
            }
            animationCounter++;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            base.Draw(spriteBatch, position, color);
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX, (int)position.Y + CameraController.CameraPositionY, (int)Globals.BlockSize, (int)(Globals.BlockSize * heightMultiplier));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.None, .02f);
        }
    }
}
