using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class Mushroom : AbstractCollectibles, IPowerUp
    {
        public override int SpawnDist { get; } = 16;
        public Mushroom(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateMushroomSprite();
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
