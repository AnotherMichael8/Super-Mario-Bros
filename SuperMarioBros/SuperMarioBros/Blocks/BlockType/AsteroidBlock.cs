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
    public class AsteroidBlock : AbstractBlock
    {
        public int height { get; private set; }
        public int width { get; private set; }
        private AsteroidBlockSprite asteroidSprite;
        public double HorzSpeed { get; protected set; }
        public double VertSpeed { get; protected set; }
        protected Vector2 directionVector;
        private double maxVertSpeed;
        private double trueYPos;
        private double trueXPos;
        private double changeYPos;
        public AsteroidBlock(Vector2 position, Vector2 directionVector, int width = 3, int height = 3) : base(position)
        {
            asteroidSprite = BlockSpriteFactory.Instance.CreateAsteroidSprite();
            this.height = height;
            this.width = width;
            this.directionVector = directionVector;
            HorzSpeed = directionVector.X;
            VertSpeed = directionVector.Y;
            trueYPos = position.Y;
            trueXPos = position.X;
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
            trueYPos += VertSpeed;
            trueXPos += HorzSpeed;
            Position = new Vector2((int)trueXPos, (int)trueYPos);
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
