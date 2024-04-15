using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Blocks.BlockSprites;

namespace SuperMarioBros.Blocks.BlockType
{
    internal class AsteroidBlock : AbstractBlock
    {
        private int height;
        private int width;
        private AsteroidBlockSprite asteroidSprite;
        public double HorzSpeed { get; private set; }
        public AsteroidBlock(Vector2 position, Vector2 directionVector) : base(position)
        {
            sourceRectangle = new Rectangle(0, 33, 16, 16);
            asteroidSprite = BlockSpriteFactory.Instance.CreateAsteroidSprite();
            height = 3;
            width = 3;
            HorzSpeed = directionVector.X;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    asteroidSprite.Draw(spriteBatch, new Vector2((int)Position.X + (int)(Globals.BlockSize * w), (int)Position.Y + (int)(Globals.BlockSize * h)), color);
                }
            }
        }
        public override void Update()
        {
            base.Update();
            Position = new Vector2((int)(Position.X + HorzSpeed), (int)Position.Y);
        }
        public override Rectangle GetHitBox()
        {
            Rectangle hitBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(Globals.BlockSize * height), (int)(Globals.BlockSize * height));
            if (CameraController.CheckInFrame(hitBox))
                return hitBox;
            else
                return Rectangle.Empty;
        }
    }
}
