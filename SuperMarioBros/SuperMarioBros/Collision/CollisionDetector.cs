using SuperMarioBros.PlayerCharacter;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Collision
{
    public class CollisionDetector
    {
        public static void CheckPlayerCollision(IPlayer player, IGameObject obj, Game1 game)
        {
            Rectangle playerHitBox = player.GetHitBox();
            Rectangle objHitBox = obj.GetHitBox();
            if (playerHitBox.Intersects(objHitBox))
            {
                ICollision side = SideDetector(playerHitBox, objHitBox);
                if (obj is IBlock)
                {
                    PlayerBlockHandler.HandlePlayerBlockCollision(player, (IBlock)obj, side);
                }
            }
        }
        public static ICollision SideDetector(Rectangle affectedSprite, Rectangle nonAffectedSprite)
        {
            Rectangle intersect = Rectangle.Intersect(affectedSprite, nonAffectedSprite);
            if (intersect.Width > intersect.Height)
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

    }
}
