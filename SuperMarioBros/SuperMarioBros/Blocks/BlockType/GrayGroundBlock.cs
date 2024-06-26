﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockSprites;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class GrayGroundBlock : AbstractBlock
    {
        private int width;
        private int height;
        private GroundBlockSprite groundBlockSprite;
        public GrayGroundBlock(Vector2 position, int width, int height) : base(position)
        {
            sourceRectangle = new Rectangle(0, 134, 16, 16);
            groundBlockSprite = BlockSpriteFactory.Instance.CreateGroundBlockSprite();
            this.width = width;
            this.height = height;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            for(int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    groundBlockSprite.Draw(spriteBatch, sourceRectangle, new Vector2((int)Position.X + (int)(Globals.BlockSize * w), (int)Position.Y + (int)(Globals.BlockSize * h)), color);
                }
            }
        }
        public override Rectangle GetHitBox()
        {
            Rectangle hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(Globals.BlockSize * width), (int)(Globals.BlockSize * height));
            if (CameraController.CheckInFrame(hitBox))
                return hitBox;
            else
                return Rectangle.Empty;
        }
    }
}
