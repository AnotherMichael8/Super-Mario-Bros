using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class WonderFlower : AbstractCollectibles
    {
        public override int SpawnDist { get; } = 16;
        private int floatingFactor;
        private int currentVerticalMovementFactor;
        private int counter;
        public WonderFlower(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateWonderFlowerSprite();
            horizMovementFactor = 0;
            verticalMovementFactor = (int)(10 * Globals.ScreenSizeMulti);
            floatingFactor = (int)(1 * Globals.ScreenSizeMulti);
            IsFalling = true;
            spawnCollectible = false;
            counter = 0;
            currentVerticalMovementFactor = 0;
        }
        public override void Update()
        {
            verticalMovementFactor -= (int)(3 * Globals.ScreenSizeMulti);
            base.Update();
            verticalMovementFactor = 0;
            if (counter == 0)
            {
                currentVerticalMovementFactor += floatingFactor;
                verticalMovementFactor = currentVerticalMovementFactor;
            }
            else if (counter == 1)
                counter = -1;
            if (verticalMovementFactor / (16 * Globals.ScreenSizeMulti) > 1 || verticalMovementFactor / (16 * Globals.ScreenSizeMulti) < -1)
            {
                floatingFactor *= -1;
            }
            counter++;
        }
        public override void SpawnCollectible(Vector2 orginalPosition)
        {
            if (trueYPosition <= orginalPosition.Y - Globals.BlockSize)
            {
                trueYPosition = orginalPosition.Y - Globals.BlockSize;
                spawnCollectible = false;
                verticalMovementFactor = 0;
            }
            else
                trueYPosition -= verticalMovementFactor / 16.0;
        }
    }
}
