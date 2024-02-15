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
        public Vector2 Position { get; set; }
        protected BlockSprite sprite;
        public static List<IBlock> Blocks = new List<IBlock>();
        public AbstractBlock(Vector2 position)
        {
            Position = position;
        }
        public virtual void Bump() { }
        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, sourceRectangle, Position, color);
        }
        public virtual Rectangle GetHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
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
