using SuperMarioBros.Collectibles;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Blocks.BlockType
{
    public class FlagPole : AbstractBlock
    {
        private FlagPoleSprite flagPoleSprite;
        public FlagPole(Vector2 position) : base(position)
        {
            flagPoleSprite = BlockSpriteFactory.Instance.CreateFlagPoleSprite();
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            flagPoleSprite.Draw(spriteBatch, Position, color);
        }
        public override Rectangle GetHitBox()
        {
            return new Rectangle((int)(Position.X + 8 * Globals.ScreenSizeMulti), (int)(Position.Y + 14), (int)(16 * Globals.ScreenSizeMulti), (int)(306 * Globals.ScreenSizeMulti));
        }
    }
}
