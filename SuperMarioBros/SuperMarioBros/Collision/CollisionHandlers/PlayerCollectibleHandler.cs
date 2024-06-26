﻿using SuperMarioBros.Collectibles;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.PlayerCharacter;
using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
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
                player.PowerUpMushroom();
                //PlayerSpriteFactory.Instance. UpdatePowerUp(PowerUp.PowerUps.MUSHROOM);
            }
            else if(collectible is Flower)
            {
                player.PowerUpFlower();
                //PlayerSpriteFactory.Instance.UpdatePowerUp(PowerUp.PowerUps.FIREFLOWER);
            }
            else if (collectible is OneUp)
            {
                player.Jump();
            }
            
            else if(collectible is Star)
            {
                player.PowerUpStar();
            }
            else if(collectible is WonderFlower)
            {
                player.TriggerWonderState(new Vector2((int)collectible.GetPositionX(), (int)collectible.GetPositionY()));
            }
            else if(collectible is WonderSeed)
            {
                player.WonderEventEnd();
            }
        }
    }
}
