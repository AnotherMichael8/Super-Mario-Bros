using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Camera;
using SuperMarioBros.Collision;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.Blocks.BlockSprites;
using System.Runtime.CompilerServices;

namespace SuperMarioBros.Blocks.BlockType
{
    public class Pipe : AbstractBlock, IPipe
    {
        private int height;
        private IPipeSprite pipeSprite;
        public Pipe connectedPipe { get; private set; }
        public ICollision enterableSide { get; private set; }
        public Vector2 EnterExitPosition { get; private set; }
        public Pipe(Vector2 position, int height, ICollision enterableSide, Pipe connectedPipe = null) : base(position)
        {
            sourceRectangle = new Rectangle(0, 16, 16, 16);
            if (enterableSide is RightCollision || enterableSide is LeftCollision)
            {
                pipeSprite = BlockSpriteFactory.Instance.CreateHorizontalPipeSprite();
                if (enterableSide is LeftCollision)
                    EnterExitPosition = new Vector2((int)(position.X - Globals.BlockSize), (int)(position.Y + Globals.BlockSize / 2));
                else
                    EnterExitPosition = new Vector2((int)(position.X + Globals.BlockSize * height), (int)(position.Y + Globals.BlockSize / 2));
            }
            else
            {
                pipeSprite = BlockSpriteFactory.Instance.CreateVerticalPipeSprite();
                if (enterableSide is TopCollision)
                    EnterExitPosition = new Vector2((int)(position.X + Globals.BlockSize / 2), (int)position.Y);
                else
                    EnterExitPosition = new Vector2((int)(position.X + Globals.BlockSize / 2), (int)(position.Y + Globals.BlockSize * height));
            }
            this.height = height;
            this.connectedPipe = connectedPipe;
            this.enterableSide = enterableSide;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            pipeSprite.Draw(spriteBatch, Position, color, height, enterableSide);
        } 
        public override Rectangle GetHitBox()
        {
            Rectangle hitBox;
            if (enterableSide is RightCollision ||  enterableSide is LeftCollision)
                hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(Globals.BlockSize * height), (int)(Globals.BlockSize * 2));
            else
                hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(Globals.BlockSize * 2), (int)(Globals.BlockSize * height));
            if (CameraController.CheckInFrame(hitBox))
                return hitBox;
            else
                return Rectangle.Empty;
        }
        public Rectangle GetEnterPipeHitBox()
        {
            Rectangle hitBox = GetHitBox();
            Rectangle enterPipeRectangle;
            if(enterableSide is LeftCollision)
            {
                enterPipeRectangle = new Rectangle(hitBox.X, (int)(hitBox.Bottom - 16 * Globals.ScreenSizeMulti), (int)Globals.BlockSize, (int)(16 * Globals.ScreenSizeMulti));
            }
            else if(enterableSide is RightCollision)
            {
                enterPipeRectangle = new Rectangle((int)(hitBox.Right - Globals.BlockSize), (int)(hitBox.Bottom - 16 * Globals.ScreenSizeMulti), (int)Globals.BlockSize, (int)(16 * Globals.ScreenSizeMulti));
            }
            else
                enterPipeRectangle = new Rectangle((int)(hitBox.X + 28 * Globals.ScreenSizeMulti), hitBox.Y, (int)(8 * Globals.ScreenSizeMulti), hitBox.Height);
            return enterPipeRectangle;
        }
    }
}
