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
        public GroundBlock(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, sourceRectangle, position, color);
        }
    }
}
