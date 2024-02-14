using SuperMarioBros.PlayerCharacter;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.Blocks;
using SuperMarioBros.Enemies;
using SuperMarioBros.Enemies.Koopa;
using System.Net.Http.Headers;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Collision.CollisionHandlers;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Collision
{
    public class CollisionDetector
    {
        //private static List<Tuple<ICollision, IGameObject, int>> collisionWarning = new List<Tuple<ICollision, IGameObject, int>>();
        private static readonly ICollision[] warnRectSides = { new BottomCollision(), new TopCollision(), new RightCollision(), new LeftCollision() };
        public static void CheckPlayerCollision(IPlayer player, IGameObject obj, Game1 game)
        {
            Rectangle playerHitBox = player.GetHitBox();
            Rectangle objHitBox = obj.GetHitBox();
            
            if (playerHitBox.Intersects(objHitBox))
            {
                ICollision side = WarnSideDetector(playerHitBox, objHitBox);
                if (obj is IBlock block)
                {
                    PlayerBlockHandler.HandlePlayerBlockCollision(player, block, side);
                }
                else if(obj is IEnemy enemy)
                {
                    if (enemy is Koopa koopa)
                    {
                        PlayerEnemyHandler.HandlePlayerKoopaCollision(player, koopa, side);
                    }
                    else
                    {
                        PlayerEnemyHandler.HandlePlayerEnemyCollision(player, enemy, side);
                    }
                }
                else if(obj is ICollectibles item)
                {
                    PlayerCollectibleHandler.HandlePlayerCollectibleCollision(player, item, side);
                }
            }
        }
        public static void CheckEnemyCollision(IEnemy enemy, IGameObject obj, List<IGameObject> gameObjectList)
        {
            Rectangle enemyRectangle = enemy.GetHitBox();
            Rectangle collisionRectangle = obj.GetHitBox();
            if (collisionRectangle.Intersects(enemyRectangle))
            {
                ICollision side = SideDetector(enemyRectangle, collisionRectangle);
                if (obj is IBlock block)
                {
                    EnemyBlockHandler.HandleEnemyBlockCollision(enemy, block, side);
                }
            }
        }
        public static ICollision SideDetector(Rectangle affectedSprite, Rectangle nonAffectedSprite)
        {
            Rectangle intersect = Rectangle.Intersect(affectedSprite, nonAffectedSprite);
            if (intersect.Width >= intersect.Height)
            {
                if (affectedSprite.Top < nonAffectedSprite.Top && affectedSprite.Bottom < nonAffectedSprite.Bottom)
                {
                    return new TopCollision();
                }
                else
                {
                    return new BottomCollision();
                }
            }
            else
            {
                if (affectedSprite.Left < nonAffectedSprite.Left && affectedSprite.Right < nonAffectedSprite.Right)
                {
                    return new LeftCollision();
                }
                else
                {
                    return new RightCollision();
                }
            }
        }
        public static ICollision WarnSideDetector(Rectangle playerHitBox, Rectangle objHitBox)
        {
            List<Tuple<ICollision, int>> collisionWarning = new List<Tuple<ICollision, int>>();
            Rectangle[] warnPlayerRectangles = { new Rectangle(playerHitBox.X, playerHitBox.Y - 9 * (int)(Globals.BlockSize/32), playerHitBox.Width, (int)(9 * Globals.BlockSize / 32)), new Rectangle(playerHitBox.X, playerHitBox.Bottom, playerHitBox.Width, (int)(9 * Globals.BlockSize / 32)), new Rectangle((int)(playerHitBox.X - 9 * (Globals.BlockSize / 32)), playerHitBox.Y, (int)(9 * (Globals.BlockSize / 32)), playerHitBox.Height), new Rectangle(playerHitBox.Right, playerHitBox.Y, (int)(9 * (Globals.BlockSize / 32)), playerHitBox.Height) };
            for (int i = 0; i < warnPlayerRectangles.Length; i++)
            {
                if (warnPlayerRectangles[i].Intersects(objHitBox))
                {
                    Rectangle intersectRect = Rectangle.Intersect(objHitBox, warnPlayerRectangles[i]);
                    Tuple<ICollision,  int> newCollision = new Tuple<ICollision, int>(warnRectSides[i], intersectRect.Width * intersectRect.Height);
                    if (collisionWarning.Count > 0)
                    {
                        int collisionWarningSize = collisionWarning.Count;
                        for (int c = 0; c < collisionWarningSize; c++)
                        {
                            if (collisionWarning[c].Item2 < newCollision.Item2)
                            {
                                collisionWarning.Insert(c, newCollision);
                                break;
                            }
                            if (c == collisionWarning.Count - 1)
                            {
                                collisionWarning.Add(newCollision);
                            }
                        }
                    }
                    else
                    {
                        collisionWarning.Add(newCollision);
                    }
                }
            }
            return collisionWarning[0].Item1;
        }
        public void DrawHitBox(Rectangle hitBox)
        {
            //CollisionManager.spriteBatch.Draw(
        }
    }
}
