﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        protected Rectangle sourceRectangle;
        public Vector2 Position { get; set; }
        protected BlockSprite sprite;
        public static List<IBlock> Blocks = new List<IBlock>();
        public static List<IBlock> ChangedBlocks = new List<IBlock>();
        protected static int tempAnimateCounter;
        public int chunk { get; private set; }
        public AbstractBlock(Vector2 position)
        {
            Position = position;
            chunk = (int)(position.X / Globals.ScreenWidth);
        }
        public virtual void Bump() { }
        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, sourceRectangle, Position, color);
        }
        public virtual Rectangle GetHitBox()
        {
            Rectangle hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
            if (CameraController.CheckInFrame(hitBox))
                return hitBox;
            else
                return Rectangle.Empty;
        }
        public static void UpdateAllBlocks()
        {
            foreach (IBlock block in Blocks)
            {
                block.Update();
            }
            QuestionBlock.UpdateAnimationCounter();
        }
        public static void DrawAllBlocks(SpriteBatch spriteBatch, Color color)
        {
            foreach(IBlock block in Blocks)
            {
                block.Draw(spriteBatch, color);
            }
        }
    }
}