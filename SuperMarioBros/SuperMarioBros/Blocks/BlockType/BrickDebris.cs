using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Blocks.BlockSprites;

namespace SuperMarioBros.Blocks.BlockType
{
    public class BrickDebris : AbstractBlock
    {
        private DebrisSprite topLeftSprite;
        private DebrisSprite topRightSprite;
        private DebrisSprite bottomLeftSprite;
        private DebrisSprite bottomRightSprite;
        private Vector2[] debrisPositions;
        private double[] debrisTrueXPosition;
        private int verticalMovementFactor;
        public BrickDebris(Vector2 position) : base(position)
        {
            sourceRectangle = new Rectangle(304, 112, 8, 8);
            topLeftSprite = BlockSpriteFactory.Instance.CreateDebrisSprite(SpriteEffects.None);
            topRightSprite = BlockSpriteFactory.Instance.CreateDebrisSprite(SpriteEffects.FlipHorizontally);
            bottomLeftSprite = BlockSpriteFactory.Instance.CreateDebrisSprite(SpriteEffects.FlipVertically);
            bottomRightSprite = BlockSpriteFactory.Instance.CreateDebrisSprite(SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
            verticalMovementFactor = 180;
            debrisPositions = new Vector2[4];
            debrisPositions[0] = position;
            debrisPositions[1] = new Vector2((int)(position.X + 16 * Globals.ScreenSizeMulti), position.Y);
            debrisPositions[2] = new Vector2(position.X, (int)(position.Y + 16 * Globals.ScreenSizeMulti));
            debrisPositions[3] = new Vector2((int)(position.X + 16 * Globals.ScreenSizeMulti), (int)(position.Y + 16 * Globals.ScreenSizeMulti));
        }
        public override void Update()
        {
            debrisPositions[0].X -= 2;
            debrisPositions[1].X += 2;
            debrisPositions[2].X -= 2;
            debrisPositions[3].X += 2;
            for(int i = 0; i < debrisPositions.Length; i++)
            {
                debrisPositions[i].Y -= verticalMovementFactor / 16;
            }
            debrisPositions[0].Y -= 2;
            debrisPositions[1].Y -= 2;
            debrisPositions[2].Y += 2;
            debrisPositions[3].Y += 2;
            verticalMovementFactor -= 10;
            if (debrisPositions[0].Y > Globals.ScreenHeight)
            {
                Blocks.Remove(this);
            }
            topLeftSprite.Update();
            topRightSprite.Update();
            bottomLeftSprite.Update();
            bottomRightSprite.Update();
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            topLeftSprite.Draw(spriteBatch, debrisPositions[0], color);
            topRightSprite.Draw(spriteBatch, debrisPositions[1], color);
            bottomLeftSprite.Draw(spriteBatch, debrisPositions[2], color);
            bottomRightSprite.Draw(spriteBatch, debrisPositions[3], color);
        }
    }
}
