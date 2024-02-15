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
        private int movement;
        public override int SpawnDist { get; } = 16;
        public Mushroom(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateMushroomSprite();
            horizMovementFactor = 24;
            verticalMovementFactor = 10;
        }
        public override void MoveLeft()
        {
            movement = 2;
        }
        public override void MoveRight()
        {
            movement = -2;
        }
        public override void SpawnCollectible(Vector2 orginalPosition)
        {
            if (trueYPosition <= orginalPosition.Y - Globals.BlockSize)
            {
                trueYPosition = orginalPosition.Y - Globals.BlockSize;
                spawnCollectible = false;
            }
            else
                trueYPosition -= verticalMovementFactor / 16.0;
        }
    }
}
