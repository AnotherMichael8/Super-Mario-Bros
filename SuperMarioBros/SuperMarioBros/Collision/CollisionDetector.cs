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
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.Blocks.BlockType;

namespace SuperMarioBros.Collision
{
    public class CollisionDetector
    {
        //private static List<Tuple<ICollision, IGameObject, int>> collisionWarning = new List<Tuple<ICollision, IGameObject, int>>();
        private static List<IBlock> bottomCollidedBlocks = new List<IBlock>();
        private static readonly ICollision[] warnRectSides = { new BottomCollision(), new TopCollision(), new RightCollision(), new LeftCollision() };
        public static void CheckPlayerCollision(IPlayer player, IGameObject obj, Game1 game)
        {
            Rectangle playerHitBox;
            if (obj is IBlock)
                playerHitBox = player.GetBlockHitBox();
            else
                playerHitBox = player.GetHitBox();
            Rectangle objHitBox = obj.GetHitBox();
            
            if (playerHitBox.Intersects(objHitBox))
            {
                ICollision side = WarnSideDetector(playerHitBox, objHitBox);
                if (obj is IBlock block)
                {
                    if (block is FlagPole)
                        PlayerBlockHandler.HandleFlagPoleCollision(player, block);
                    else if (side is BottomCollision)
                        bottomCollidedBlocks.Add(block);
                    else
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
        public static void CheckBottomBlockCollision(IPlayer player)
        {
            if (bottomCollidedBlocks.Count > 0)
            {
                IBlock interactedBlock = bottomCollidedBlocks[0];
                int biggestArea = 0;
                Rectangle playerHitBox = player.GetBlockHitBox();
                Rectangle warnPlayerRectangle = new Rectangle(playerHitBox.X, playerHitBox.Y - 9 * (int)(Globals.BlockSize / 32), playerHitBox.Width, (int)(9 * Globals.BlockSize / 32));
                foreach (IBlock block in bottomCollidedBlocks)
                {
                    Rectangle blockHitBox = block.GetHitBox();
                    Rectangle intersectionRect = Rectangle.Intersect(blockHitBox, warnPlayerRectangle);
                    int area = intersectionRect.Width * intersectionRect.Height;
                    if (area > biggestArea)
                    {
                        biggestArea = area;
                        interactedBlock = block;
                    }
                }
                PlayerBlockHandler.HandlePlayerBlockCollision(player, interactedBlock, new BottomCollision());
                bottomCollidedBlocks = new List<IBlock>();
            }

        }
        public static void CheckEnemyCollision(IEnemy enemy, IGameObject obj)
        {
            Rectangle enemyRectangle;
            if (obj is IBlock)
                enemyRectangle = enemy.GetBlockHitBox();
            else
                enemyRectangle = enemy.GetHitBox();
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
        public static void CheckCollectibleCollision(ICollectibles collectible, IGameObject obj)
        {
            Rectangle collectibleRectangle;
            if(obj is IBlock)
                collectibleRectangle = collectible.GetBlockHitBox();
            else
                collectibleRectangle = collectible.GetHitBox();
            Rectangle collisionRectangle = obj.GetHitBox();
            if (collisionRectangle.Intersects(collectibleRectangle))
            {
                ICollision side = SideDetector(collectibleRectangle, collisionRectangle);
                if (obj is IBlock block)
                {
                    CollectibleBlockHandler.HandleCollectibleBlockCollision(collectible, block, side);
                }
            }
        }
        public static void CheckPowerUpAbilityCollision(IPowerUpAbility powerUpAbility, IGameObject obj)
        {
            Rectangle collectibleRectangle;
            if (obj is IBlock)
                collectibleRectangle = powerUpAbility.GetBlockHitBox();
            else
                collectibleRectangle = powerUpAbility.GetHitBox();
            Rectangle collisionRectangle = obj.GetHitBox();
            if (collisionRectangle.Intersects(collectibleRectangle))
            {
                ICollision side = SideDetector(collectibleRectangle, collisionRectangle);
                if (obj is IBlock block)
                {
                    PowerUpAbilityHandler.HandlePowerUpAbilityBlockCollision(powerUpAbility, block, side);
                }
                if(obj is IEnemy enemy)
                {
                    PowerUpAbilityHandler.HandlePowerUpAbilityEnemyCollision(powerUpAbility, enemy, side);
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
            if (collisionWarning.Count > 0)
                return collisionWarning[0].Item1;
            else
                return null;
        }
        public static bool CollidingWithTopOfPipe(IPlayer player, Pipe pipe, ICollision side)
        {
            Type pipeSide = side.GetType();
            Rectangle playerHitBox = player.GetBlockHitBox();
            Rectangle pipeHitBox = pipe.GetEnterPipeHitBox();
            if(playerHitBox.Intersects(pipeHitBox) && pipeSide.Equals(WarnSideDetector(playerHitBox, pipeHitBox).GetType()) && pipe.connectedPipe != null)
                PlayerBlockHandler.HandleEnteringPipe(player, pipe);
            return playerHitBox.Intersects(pipeHitBox) && WarnSideDetector(playerHitBox, pipeHitBox) is TopCollision;
        }
    }
}
