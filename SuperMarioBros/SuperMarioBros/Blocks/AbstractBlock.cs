using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        protected Vector2 position;
        protected BlockSprite sprite;
        public static List<IBlock> Blocks = new List<IBlock>();
        public AbstractBlock(Vector2 position)
        {
            this.position = position;
        }
        public virtual void Bump() { }
        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, sourceRectangle, position, color);
        }
        public virtual Rectangle GetHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, Globals.BlockSize, Globals.BlockSize);
        }
        public static void UpdateAllBlocks()
        {
            foreach (IBlock block in Blocks)
            {
                block.Update();
            }
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
