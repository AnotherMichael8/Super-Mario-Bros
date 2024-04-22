using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class DeathPlayerState : AbstractPlayerState
    {
        private int moveTimer;
        private int moveSpeed;
        private Rectangle hitBox;
        public DeathPlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateDeathPlayerSprite();
            Speed = 0;
            hitBox = player.GetBlockHitBox();
            if (hitBox.Y <= Globals.ScreenHeight)
                JumpingSpeed = 155;
            else
                JumpingSpeed = 16;
            player.HitBoxOff = true;
            moveTimer = 5;
            moveSpeed = 17;
            SoundFactory.Instance.PauseMusic();
            SoundFactory.PlaySound(SoundFactory.Instance.marioDeath);
        }
        public override void UseAbility() { }
        public override void TriggerWonderState(Vector2 wonderPosition) { }
        public override void UpdateMovement()
        {
            if(player.Position.Y > Globals.ScreenHeight) 
            {
                JumpingSpeed = 16;
            }
            else if(hitBox.Y <= Globals.ScreenHeight)
                JumpingSpeed -= 5;
        }
    }
}
