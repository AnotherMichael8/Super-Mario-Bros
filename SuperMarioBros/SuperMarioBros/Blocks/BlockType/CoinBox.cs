using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.Collectibles;

namespace SuperMarioBros.Blocks.BlockType
{
    public class CoinBox : BreakableBrickBlock
    {
        private int coinTotal;
        private Vector2 coinPosition;
        public CoinBox(Vector2 position) : base(position, new Coin(new Vector2(position.X + (int)(4 * Globals.ScreenSizeMulti), (int)(position.Y - Globals.BlockSize))))
        {
            coinTotal = 14;
            coinPosition = new Vector2(position.X + (int)(4 * Globals.ScreenSizeMulti), (int)(position.Y - Globals.BlockSize));
        }

        public override void Bump(PowerUps powerUp)
        {
            bumpCounter = 5;
            if (coinTotal > 1)
            {
                collectible.StartSpawningCollectible(collectible);
                collectible = new Coin(coinPosition);
                SoundFactory.PlaySound(SoundFactory.Instance.coin);
            }
            else
                SpawnCollectible(collectible);
            coinTotal--;
        }
    }
}
