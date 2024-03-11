using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collision.CollisionHandlers;
using SuperMarioBros.Enemies;
using SuperMarioBros.PlayerCharacter;
using SuperMarioBros.Collectibles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockType;

namespace SuperMarioBros.Collision
{
    public class CollisionManager
    {
        private Game1 game;
        private IPlayer player; 
        public static List<IGameObject> GameObjectList;
        public static SpriteBatch spriteBatch;
        public CollisionManager(Game1 game, SpriteBatch spriteBatch) 
        { 
            this.game = game;
            GameObjectList = new List<IGameObject>();
            player = game.MarioPlayer;
            CollisionManager.spriteBatch = spriteBatch; 
        }

        public void CheckPlayerCollision()
        {
            PlayerBlockHandler.SetFalling();
            for (int c = 0; c < GameObjectList.Count; c++)
            {
                IGameObject obj = GameObjectList[c];
                CollisionDetector.CheckPlayerCollision(player, obj, game);
            }
            PlayerBlockHandler.SendFallingData(player);
            CollisionDetector.CheckBottomBlockCollision(player);
        }
        public void CheckEnemyCollision()
        {
            for (int i = 0; i < GameObjectList.Count; i++)
            {
                if (GameObjectList[i] is IEnemy enemy)
                {
                    for (int c = 0; c < GameObjectList.Count; c++)
                    {
                        IGameObject obj = GameObjectList[c];
                        CollisionDetector.CheckEnemyCollision(enemy, obj);
                    }
                }
            }
        }
        public void CheckCollectiblesCollision()
        {
            for (int i = 0; i < GameObjectList.Count; i++)
            {
                if (GameObjectList[i] is ICollectibles collectible)
                {
                    CollectibleBlockHandler.SetFalling();
                    for (int c = 0; c < GameObjectList.Count; c++)
                    {
                        IGameObject obj = GameObjectList[c];
                        CollisionDetector.CheckCollectibleCollision(collectible, obj);
                    }
                    CollectibleBlockHandler.SendFallingData(collectible);
                }
            }
        }
        public void CheckPowerUpAbiltiesCollision()
        {
            for (int i = 0; i < GameObjectList.Count; i++)
            {
                if (GameObjectList[i] is IPowerUpAbility ability)
                {
                    for (int c = 0; c < GameObjectList.Count; c++)
                    {
                        IGameObject obj = GameObjectList[c];
                        CollisionDetector.CheckPowerUpAbilityCollision(ability, obj);
                    }
                }
            }
        }
        public static bool IsPipeEnterAble(IPlayer player)
        {
            for (int c = 0; c < GameObjectList.Count; c++)
            {
                IGameObject obj = GameObjectList[c];
                if(obj is Pipe pipe && CollisionDetector.CollidingWithTopOfPipe(player, pipe))
                {
                    return true;
                }
            }
            return false;
        }
        public void Update()
        {
            CheckPlayerCollision();
            CheckEnemyCollision();
            CheckCollectiblesCollision();
            CheckPowerUpAbiltiesCollision();
        }
    }
}
