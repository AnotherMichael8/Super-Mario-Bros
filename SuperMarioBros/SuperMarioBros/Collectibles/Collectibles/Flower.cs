using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collectibles.Collectibles
{
    public class Flower : AbstractCollectibles
    {
        public Flower(Vector2 position) : base(position)
        {
            sprite = CollectiblesSpriteFactory.Instance.CreateFlowerSprite();
        }
    }
}
