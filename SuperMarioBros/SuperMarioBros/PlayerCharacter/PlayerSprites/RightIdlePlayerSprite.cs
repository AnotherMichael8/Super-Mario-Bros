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
    public class RightIdlePlayerSprite : AbstractPlayerSprite
    {
        private Rectangle sourceRectangle = new Rectangle(0, 8, 16, 16);
        public RightIdlePlayerSprite(Texture2D texture) : base(texture)
        {
            sourceRectangle = new Rectangle(0, 8 + updatePowerUpSprite, 16, 16 * heightMultiplier);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, (int)Globals.BlockSize, (int)(Globals.BlockSize * heightMultiplier));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0);
        }
    }
}