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
        public int height { get; private set; }
        public int width { get; private set; }
        private AsteroidBlockSprite asteroidSprite;
        public double HorzSpeed { get; private set; }
        public double VertSpeed { get; private set; }
        private double maxVertSpeed;
        private double trueYPos;
        private double trueXPos;
        private double changeYPos;
        public AsteroidBlock(Vector2 position, Vector2 directionVector) : base(position)
        {
            asteroidSprite = BlockSpriteFactory.Instance.CreateAsteroidSprite();
            height = 3;
            width = 3;
            HorzSpeed = directionVector.X;
            maxVertSpeed = directionVector.Y;
            VertSpeed = 0;
            trueYPos = position.Y;
            trueXPos = position.X;
            changeYPos = 0.01;
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
            trueYPos += maxVertSpeed;
            Position = new Vector2((int)(Position.X + HorzSpeed), (int)trueYPos);
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
