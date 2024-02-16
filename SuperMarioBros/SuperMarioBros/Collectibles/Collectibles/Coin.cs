using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collision;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class Coin : AbstractCollectibles
    {
        public override int SpawnDist { get; } = 16;
        public Coin(Vector2 position) : base(position) 
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateCoinSprite();
            verticalMovementFactor = (int)(120 * Globals.ScreenSizeMulti);
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
                CollisionManager.GameObjectList.Remove(this);
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
