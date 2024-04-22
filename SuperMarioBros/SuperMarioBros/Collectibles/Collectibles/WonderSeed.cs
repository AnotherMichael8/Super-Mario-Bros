using SuperMarioBros.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collectibles.CollectiblesSprites;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class WonderSeed : AbstractCollectibles
    {
        public override int SpawnDist { get; } = 16;
        private int floatingFactor;
        private int currentVerticalMovementFactor;
        private int counter;
        private bool animationPlaying;
        private WonderSeedSprite animationPlayingSprite;
        public WonderSeed(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateWonderSeedSprite();
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
                animationPlayingSprite.Update(animationPlaying);
                if (counter >= 210)
                {
                    CameraController.UpdateObjectQueue.Add(new Tuple<IGameObject, IGameObject>(this, null));
                }
            }
            counter++;
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            base.Draw(spriteBatch, color);
            if(animationPlaying)
                animationPlayingSprite.Draw(spriteBatch, Position, color);
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
            if(sprite is WonderSeedSprite)
                animationPlayingSprite = (WonderSeedSprite)sprite;
            sprite = CollectiblesSpriteFactory.Instance.CreateWonderSeedCollectionAnimation();
            animationPlaying = true;
            counter = 0;
        }
    }
}
