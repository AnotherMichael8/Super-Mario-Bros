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
        private ICollision exitSide;
        public EnterPipePlayerState(Player player, Pipe pipe) : base(player)
        {
            frameCounter = 0;
            Rectangle hitBox = player.GetBlockHitBox();
            teleportPosition = pipe.enterableSide.UpdateDirectionPosition(hitBox.Width, hitBox.Height, pipe.connectedPipe.EnterExitPosition);
            player.HitBoxOff = true;
            ICollision enterSide = pipe.enterableSide;
            exitSide = pipe.connectedPipe.enterableSide;
            if (enterSide is TopCollision)
            {
                Speed = 0;
                JumpingSpeed = -16;
            }
            else if (enterSide is RightCollision)
            {
                Speed = -32;
                JumpingSpeed = 0;
            }
            else if (enterSide is LeftCollision)
            {
                Speed = 32;
                JumpingSpeed = 0;
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
            if(frameCounter == 120)
            {
                player.Position = new Vector2(teleportPosition.X, teleportPosition.Y + 120);
                if (exitSide is TopCollision)
                {
                    player.Sprite = PlayerSpriteFactory.Instance.CreateRightIdlePlayerSprite();
                    Speed = 0;
                    JumpingSpeed = 48;
                }
                else if(exitSide is RightCollision)
                {
                    player.Sprite = PlayerSpriteFactory.Instance.CreateRightMovingPlayerSprite();
                    Speed = 32;
                    JumpingSpeed = 0;
                }
                else if (exitSide is LeftCollision)
                {
                    player.Sprite = PlayerSpriteFactory.Instance.CreateLeftMovingPlayerSprite();
                    Speed = -32;
                    JumpingSpeed = 0;
                }
                else
                {
                    player.Sprite = PlayerSpriteFactory.Instance.CreateRightIdlePlayerSprite();
                    Speed = 0;
                    JumpingSpeed = -16;
                }
            }
            else if(player.Position.Y <= teleportPosition.Y)
            {
                player.State = new RightIdlePlayerState(player);
                player.HitBoxOff = false;
            }
        }
    }
}
