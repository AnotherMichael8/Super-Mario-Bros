using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.Enemies;
using SuperMarioBros.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collision
{
    public class PlayerEnemyHandler
    {
        public static void HandlePlayerEnemyCollision(IPlayer player, IEnemy enemy, ICollision side)
        {
            if(side is TopCollision)
            {
                enemy.Kill();
            }
            else
            {
                player.Position = new Vector2(enemy.Position.X - 32, player.Position.Y);
            }
        }
    }
}
