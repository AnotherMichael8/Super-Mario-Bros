using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Collision;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.PlayerCharacter;

namespace SuperMarioBros.Blocks.BlockType
{
    public class UsedBlock : AbstractBlock
    {
        private int bumpCounter;
        private ICollectibles collectible;
        private bool noBump;
        public UsedBlock(Vector2 position, ICollectibles collectible) : base(position)
        {
            sourceRectangle = new Rectangle(51, 16, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            bumpCounter = -6;
            this.collectible = collectible;
            noBump = false;
        }
        public override void Update()
        {
            if (bumpCounter > -6 && !noBump)
            {
                Position = new Vector2(Position.X, Position.Y - (int)(bumpCounter * (Globals.BlockSize / 32)));
                bumpCounter--;
            }
            else if(bumpCounter == -6)
            {
                if (collectible is not Coin)
                {
                    collectible.StartSpawningCollectible(collectible);
                }
                bumpCounter--;
                noBump = true;
            }
        }
        public override void Bump(PowerUps powerUp)
        {
            bumpCounter = 5;
        }
    }
}
