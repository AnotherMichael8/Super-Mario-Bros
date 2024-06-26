﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public class DeathPlayerSprite : AbstractPlayerSprite
    {
         
        public DeathPlayerSprite(Texture2D texture, PowerUps powerUp) : base(texture, powerUp)
        {
            sourceRectangle = new Rectangle(116, 8 + updatePowerUpSprite, 16, 16 * heightMultiplier);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPositionX, (int)position.Y + CameraController.CameraPositionY, (int)Globals.BlockSize, (int)(Globals.BlockSize * heightMultiplier));
            //Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, (int)Globals.BlockSize, (int)(Globals.BlockSize * heightMultiplier));
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.None, 0);
        }
    }
}
