using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class GroundBlock : IBlock
    {
        private Rectangle sourceRectangle = new Rectangle(0, 16, 16, 16);
        private Vector2 position;
        private BlockSprite sprite;
        private int width;
        private int height;
        public GroundBlock(Vector2 position, int width, int height)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            this.width = width;
            this.height = height;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            for(int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    sprite.Draw(spriteBatch, sourceRectangle, new Vector2((int)position.X + 32 * w, (int)position.Y + 32 * h), color);
                }
            }
            sprite.Draw(spriteBatch, sourceRectangle, position, color);
        }
        public void Bump()
        {
            position.Y += 100;
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, 32 * width, 32 * height);
        }
    }
}
