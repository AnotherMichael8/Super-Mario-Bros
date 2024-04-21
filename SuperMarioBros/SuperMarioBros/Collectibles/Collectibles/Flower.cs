using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class Flower : AbstractCollectibles, IPowerUp
    {
        public override int SpawnDist { get; } = 16;
        public Flower(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateFlowerSprite();
            verticalMovementFactor = (int)(10 * Globals.ScreenSizeMulti);
        }
        public override void SpawnCollectible(Vector2 orginalPosition)
        {
            if (trueYPosition <= orginalPosition.Y - Globals.BlockSize)
            {
                trueYPosition = orginalPosition.Y - Globals.BlockSize;
                spawnCollectible = false;
                verticalMovementFactor = (int)(16 * Globals.ScreenSizeMulti);
            }
            else
                trueYPosition -= verticalMovementFactor / 16.0;
        }
        public override void Collect()
        {
            base.Collect();
            SoundFactory.PlaySound(SoundFactory.Instance.collectPowerUp);
        }
    }
}
