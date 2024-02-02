using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockType
{
    public class QuestionBlock : IBlock
    {
        private Rectangle sourceRectangle;
        private Rectangle[] spriteAnimation = { new Rectangle(298, 78, 16, 16), new Rectangle(315, 78, 16, 16), new Rectangle(332, 78, 16, 16) };
        private Vector2 position;
        private BlockSprite sprite;
        private int animateCounter;
        public QuestionBlock(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            sourceRectangle = spriteAnimation[0];
            animateCounter = 0;
        }
        public void Update() 
        {
            if (animateCounter > 48)
            {
                sourceRectangle = spriteAnimation[0];
                animateCounter = 0;
            }
            else if (animateCounter > 38)
                sourceRectangle = spriteAnimation[1];
            else if (animateCounter > 30)
                sourceRectangle = spriteAnimation[2];
            else if (animateCounter > 20)
                sourceRectangle = spriteAnimation[1];
            animateCounter++;
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, sourceRectangle, position, color);
        }
        public void Bumb()
        {
            position.Y -= 100;
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }
    }
}
