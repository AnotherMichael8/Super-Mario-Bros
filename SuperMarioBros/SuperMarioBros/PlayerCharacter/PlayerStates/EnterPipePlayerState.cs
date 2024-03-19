using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Collision;
using SuperMarioBros.Collision.SideCollisionHandlers;
using SuperMarioBros.PlayerCharacter.Interfaces;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class EnterPipePlayerState : AbstractPlayerState
    {
        private int frameCounter;
        private Vector2 teleportPosition;
        private ICollision enterSide;
        private ICollision exitSide;
        private Rectangle pipeHitBox;
        public EnterPipePlayerState(Player player, Pipe pipe) : base(player)
        {
            frameCounter = 0;
            Rectangle playerHitBox = player.GetBlockHitBox();
            pipeHitBox = pipe.GetHitBox();
            teleportPosition = pipe.connectedPipe.enterableSide.UpdateDirectionPosition(playerHitBox.Width, playerHitBox.Height, pipe.connectedPipe.EnterExitPosition);
            player.HitBoxOff = true;
            enterSide = pipe.enterableSide;
            exitSide = pipe.connectedPipe.enterableSide;
            if (enterSide is TopCollision)
            {
                Speed = 0;
                JumpingSpeed = -16;
            }
            else if (enterSide is RightCollision)
            {
                Speed = -32;
                JumpingSpeed = 16;
                player.Position = new Vector2(player.Position.X, player.Position.Y - (int)(3 * Globals.ScreenSizeMulti));
            }
            else if (enterSide is LeftCollision)
            {
                Speed = 32;
                JumpingSpeed = 16;
                player.Position = new Vector2(player.Position.X, player.Position.Y - (int)(3 * Globals.ScreenSizeMulti));
            }
            else
            {
                Speed = 0;
                JumpingSpeed = 48;
            }
        }
        public override void UpdateMovement()
        {
            frameCounter++;
            Rectangle playerRectPosition = player.GetRectanglePosition();
            if (frameCounter == 120)
            {
                if (exitSide is TopCollision)
                {
                    player.Position = new Vector2(teleportPosition.X, teleportPosition.Y + 120);
                    player.Sprite = PlayerSpriteFactory.Instance.CreateRightIdlePlayerSprite();
                    Speed = 0;
                    JumpingSpeed = 48;
                }
                else if (exitSide is RightCollision)
                {
                    player.Position = new Vector2(teleportPosition.X - 120, teleportPosition.Y);
                    player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
                    Speed = 32;
                    JumpingSpeed = 16;
                }
                else if (exitSide is LeftCollision)
                {
                    player.Position = new Vector2(teleportPosition.X + 120, teleportPosition.Y);
                    player.Sprite = PlayerSpriteFactory.Instance.CreateLeftMovingPlayerSprite();
                    Speed = -32;
                    JumpingSpeed = 16;
                }
                else
                {
                    player.Position = new Vector2(teleportPosition.X, teleportPosition.Y - 120);
                    player.Sprite = PlayerSpriteFactory.Instance.CreateRightIdlePlayerSprite();
                    Speed = 0;
                    JumpingSpeed = 6;
                }
            }
            else if (frameCounter > 120)
            {
                if (Speed == 0 && JumpingSpeed > 16 && player.Position.Y <= teleportPosition.Y)
                {
                    player.State = new RightIdlePlayerState(player);
                    player.HitBoxOff = false;
                }
                else if (Speed == 0 && JumpingSpeed < 0 && player.Position.Y >= teleportPosition.Y)
                {
                    player.State = new RightIdlePlayerState(player);
                    player.HitBoxOff = false;
                }
                else if (Speed == 32 && player.Position.X >= teleportPosition.X)
                {
                    player.State = new RightIdlePlayerState(player);
                    player.HitBoxOff = false;
                }
                else if (Speed == -32 && player.Position.X <= teleportPosition.X)
                {
                    player.State = new LeftIdlePlayerState(player);
                    player.HitBoxOff = false;
                }
            }
            else
            {
                if (enterSide is TopCollision && playerRectPosition.Bottom >= pipeHitBox.Bottom)
                {
                    JumpingSpeed = 16;
                    player.Position = new Vector2(player.Position.X, player.Position.Y - (playerRectPosition.Bottom - pipeHitBox.Bottom));
                }
                else if (enterSide is LeftCollision && playerRectPosition.Right >= pipeHitBox.Right)
                {
                    Speed = 0;
                    player.Position = new Vector2(player.Position.X - (playerRectPosition.Right - pipeHitBox.Right), player.Position.Y);
                }
                else if (enterSide is RightCollision && playerRectPosition.Left <= pipeHitBox.Left)
                {
                    Speed = 0;
                    player.Position = new Vector2(player.Position.X - (playerRectPosition.Left - pipeHitBox.Left), player.Position.Y);
                }
            }
        }
    }
}
