using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class Coin : AbstractCollectibles
    {
        public override int SpawnDist { get; } = 16;
        public Coin(Vector2 position) : base(position) 
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateCoinSprite();
            verticalMovementFactor = 120;
        }
        public override Rectangle GetHitBox()
        {
            return Rectangle.Empty;
        }
        public override void SpawnCollectible(Vector2 orginalPosition)
        {
            if (verticalMovementFactor < 0 && trueYPosition >= orginalPosition.Y)
            {
                Collectibles.Remove(this);
                spawnCollectible = false;
            }
            else
            {
                trueYPosition -= verticalMovementFactor / 16.0;
                verticalMovementFactor -= 5;
            }

        }
    }
}
