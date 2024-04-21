using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockSprites;

namespace SuperMarioBros.Blocks.BlockType
{
    public class SpacePipe : AbstractBlock
    {
        private SpacePipeSprite spacePipeSprite;
        private SpriteEffects flip;
        public SpacePipe(Vector2 position, bool flip) : base(position)
        {
            spacePipeSprite = BlockSpriteFactory.Instance.CreateSpacePipeSprite();
            if (flip)
                this.flip = SpriteEffects.FlipHorizontally;
            else
                this.flip = SpriteEffects.None;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            spacePipeSprite.Draw(spriteBatch, Position, color, flip);
        }
        public override Rectangle GetHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)(176 * 2 * Globals.ScreenSizeMulti), (int)(50 * 2 * Globals.ScreenSizeMulti));
        }
    }
}
