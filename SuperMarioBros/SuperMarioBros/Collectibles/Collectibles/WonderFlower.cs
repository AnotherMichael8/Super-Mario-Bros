using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.Camera;
using SuperMarioBros.Collision;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class WonderFlower : AbstractCollectibles
    {
        public override int SpawnDist { get; } = 16;
        private int floatingFactor;
        private int currentVerticalMovementFactor;
        private int counter;
        private bool animationPlaying;
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
            animationPlaying = false;
            StartSpawningCollectible(this);
        }
        public override void Update()
        {
            if (!animationPlaying)
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
            }
            else
            {
                sprite.Update();
                if (counter >= 180)
                {
                    Collectibles.Remove(this);
                    WonderSeed seed = new WonderSeed(new Vector2(Position.X, (int)(Position.Y - Globals.BlockSize)));
                    Collectibles.Add(seed);
                    CollisionManager.GameObjectList.Add(seed);
                }           
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
        public override void Collect()
        {
            CollisionManager.GameObjectList.Remove(this);
            sprite = CollectiblesSpriteFactory.Instance.CreateWonderFlowerCollectionAnimation();
            animationPlaying = true;
            counter = 0;
            CameraController.UpdateObjectQueue.Add(new Tuple<IGameObject, IGameObject>(this, null));
            SoundFactory.Instance.PauseMusic();
            SoundFactory.PlaySound(SoundFactory.Instance.wonderFlowerCollect);
        }
    }
}
