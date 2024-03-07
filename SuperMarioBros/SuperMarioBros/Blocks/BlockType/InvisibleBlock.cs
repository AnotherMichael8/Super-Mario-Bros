using SuperMarioBros.Collectibles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Blocks.BlockType
{
    public class InvisibleBlock : AbstractBlock
    {
        private int bumpCounter;
        private ICollectibles collectible;
        public InvisibleBlock(Vector2 position, ICollectibles collectible) : base(position)
        {
            bumpCounter = -6;
            this.collectible = collectible;
        }
        public override void Update()
        {
            if (bumpCounter > -6)
            {
                Position = new Vector2(Position.X, Position.Y - (int)(bumpCounter * (Globals.BlockSize / 32)));
                bumpCounter--;
            }
        }
        public override void Draw(SpriteBatch spriteBatch, Color color) { }
        public override void Bump(PowerUps powerUp)
        {
            SpawnCollectible(collectible);
        }
    }
}
