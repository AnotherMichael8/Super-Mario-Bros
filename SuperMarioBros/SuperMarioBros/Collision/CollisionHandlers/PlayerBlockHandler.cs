using SuperMarioBros.Blocks;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.PlayerCharacter;
using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerStates;
using SuperMarioBros.Blocks.BlockType;

namespace SuperMarioBros.Collision
{
    public class PlayerBlockHandler
    {
        private static bool IsFalling;
        public static void HandlePlayerBlockCollision(IPlayer player, IBlock block, ICollision side)
        {
            Rectangle blockHitBox = block.GetHitBox();
            if (side is TopCollision && block is not InvisibleBlock)
            {
                if (player.State is not IJumpingPlayerState)
                {
                    Rectangle playerHitBox = player.GetHitBox();
                    player.Position = new Vector2(player.Position.X, player.Position.Y + (blockHitBox.Top - playerHitBox.Bottom));
                    player.OnGround = true;
                    IsFalling = false;
                }
            }
            else if (side is BottomCollision)
            {
                if (player.State is IJumpingPlayerState)
                {
                    block.Bump(Player.CurrentPowerUp);
                    player.StopUpwardMovement();
                }
            }
            else if (side is LeftCollision && block is not InvisibleBlock)
            {
                player.Position = new Vector2((int)(blockHitBox.Left - Globals.BlockSize), player.Position.Y + 1);
                if (AbstractPlayerState.Speed > 1)
                    AbstractPlayerState.Speed -= 3;
            }
            else if (side is RightCollision && block is not InvisibleBlock)
            {
                player.Position = new Vector2(blockHitBox.Right, player.Position.Y + 1);
                if (AbstractPlayerState.Speed < -1)
                    AbstractPlayerState.Speed += 3;
            }
        }
        public static void HandleFlagPoleCollision(IPlayer player, IBlock block)
        {
            player.Position = new Vector2(block.Position.X - (int)(16 * Globals.ScreenSizeMulti), player.Position.Y);
            player.GrabPole();

        }
        public static void HandleEnteringPipe(IPlayer player, Pipe pipe)
        {
            player.EnterPipe(pipe);
        }
        public static void HandleEdgeOfMapCollision(IPlayer player)
        {
            player.Position = new Vector2(0, player.Position.Y);
            if (AbstractPlayerState.Speed < -1)
                AbstractPlayerState.Speed += 3;
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
