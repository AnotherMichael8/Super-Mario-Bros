﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Camera;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class LeftJumpingPlayerSprite : AbstractPlayerSprite
    {
        public LeftJumpingPlayerSprite(Texture2D texture, PowerUps powerUp) : base(texture, powerUp)
        {
            sourceRectangle = new Rectangle(96, 8 + updatePowerUpSprite, 16, 16 * heightMultiplier);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            base.Draw(spriteBatch, position, color);
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX, (int)position.Y + CameraController.CameraPositionY, (int)Globals.BlockSize, (int)(Globals.BlockSize * heightMultiplier));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.FlipHorizontally, .02f);
        }
    }
}