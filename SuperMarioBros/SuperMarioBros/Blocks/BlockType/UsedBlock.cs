using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockType
{
    public class UsedBlock : IBlock
    {
        private Rectangle sourceRectangle = new Rectangle(51, 16, 16, 16);
        private Vector2 position;
        private BlockSprite sprite;
        public UsedBlock(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, sourceRectangle, position, color);
        }
        public void Bump()
        {
            position.Y += 100;
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }
    }
}
