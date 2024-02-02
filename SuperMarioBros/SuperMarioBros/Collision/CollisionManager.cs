using SuperMarioBros.Enemies;
using SuperMarioBros.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision
{
    public class CollisionManager
    {
        private Game1 game;
        private IPlayer player; 
        public static List<IGameObject> GameObjectList;
        public CollisionManager(Game1 game) 
        { 
            this.game = game;
            GameObjectList = new List<IGameObject>();
            player = game.MarioPlayer;
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
        }
        public void CheckEnemyCollsion()
        {
            for (int i = 0; i < GameObjectList.Count; i++)
            {
                if (GameObjectList[i] is IEnemy enemy)
                {
                    for (int c = 0; c < GameObjectList.Count; c++)
                    {
                        IGameObject obj = GameObjectList[c];
                        CollisionDetector.CheckEnemyCollision(enemy, obj, GameObjectList);
                    }
                }
            }
        }

        public void Update()
        {
            CheckPlayerCollision();
            CheckEnemyCollsion();
        }

    }
}
