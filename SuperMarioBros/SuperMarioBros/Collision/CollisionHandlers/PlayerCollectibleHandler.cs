using SuperMarioBros.Collectibles;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision.CollisionHandlers
{
    public class PlayerCollectibleHandler
    {
        public static void HandlePlayerCollectibleCollision(IPlayer player, ICollectibles collectible, ICollision side)
        {
            collectible.Collect();
            if(collectible is Mushroom)
            {
                //player.MakeBig();
            }
            else if(collectible is Flower)
            {
                //player.MakeFire();
            }
            /*
            else if(collectible is Star)
            {
                player.BecomeStar()
            }
            else if(collectible is Coin)
            {
                AddCoin
            }
            else if(collectible is 1Up)
            {
                IncrementLives
            }
            */
        }
    }
}
