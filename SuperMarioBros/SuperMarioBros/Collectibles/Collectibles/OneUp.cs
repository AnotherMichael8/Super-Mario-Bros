using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class OneUp : AbstractCollectibles
    {
        public override int SpawnDist { get; } = 16;
        public OneUp(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.Create1UPSprite();
            horizMovementFactor = 24;
            verticalMovementFactor = (int)(10 * Globals.ScreenSizeMulti);
        } 
        public override void MoveLeft()
        {
            horizMovementFactor = -24;
        }
        public override void MoveRight()
        {
            horizMovementFactor = 24;
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
    }
}
