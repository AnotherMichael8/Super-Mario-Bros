using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class Mushroom : AbstractCollectibles
    {
        private int movement;
        public Mushroom(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateMushroomSprite();
            movementFactor = 24;
        }
        public override void MoveLeft()
        {
            movement = 2;
        }
        public override void MoveRight()
        {
            movement = -2;
        }
    }
}
