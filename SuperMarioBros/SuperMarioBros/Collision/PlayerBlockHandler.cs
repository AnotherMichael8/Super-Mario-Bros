using SuperMarioBros.Blocks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.PlayerCharacter;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerStates;

namespace SuperMarioBros.Collision
{
    public class PlayerBlockHandler
    {
        public static bool IsFalling;
        public static void HandlePlayerBlockCollision(IPlayer player, IBlock block, ICollision side)
        {
            Rectangle blockHitBox = block.GetHitBox();
            if (side is TopCollision)
            {
                if (!(player.State is IJumpingPlayerState))
                {
                    player.Position = new Vector2(player.Position.X, blockHitBox.Y - 32);
                    player.OnGround = true;
                    IsFalling = false;
                }
            }
            else if (side is BottomCollision)
            {
                if (player.State is IJumpingPlayerState)
                {
                    block.Bump();
                    player.StopUpwardMovement();
                }
            }
            else if (side is LeftCollision)
            {
                player.Position = new Vector2(blockHitBox.X - 32, player.Position.Y - 1);
                if (AbstractPlayerState.Speed > 1)
                    AbstractPlayerState.Speed -= 3;
            }
            else if (side is RightCollision)
            {
                player.Position = new Vector2(blockHitBox.X + 32, player.Position.Y - 1);
                if (AbstractPlayerState.Speed < -1)
                    AbstractPlayerState.Speed += 3;
            }

        }
        public static void SetFalling()
        {
            IsFalling = true;
        }
        public static void SendFallingData(IPlayer player)
        {
            player.IsFalling = IsFalling;
        }
    }
}
