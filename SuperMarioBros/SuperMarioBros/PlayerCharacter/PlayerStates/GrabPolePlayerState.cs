using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Runtime.CompilerServices;
using System.Diagnostics.Metrics;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class GrabPolePlayerState : AbstractPlayerState
    {
        private bool alreadyTurned;
        private int counter;
        public GrabPolePlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateGrabPoleSprite();
            Speed = 0;
            JumpingSpeed = -16;
            SoundFactory.Instance.PauseMusic();
            SoundFactory.PlaySound(SoundFactory.Instance.flagpole);
            alreadyTurned = false;
            counter = 0;
        }
        public override void GrabPole() { }
        public override void UseAbility() { }
        public override void UpdateMovement()
        {
            if (!alreadyTurned && !player.IsFalling)
            {
                if (counter >= 30)
                {
                    player.Sprite = PlayerSpriteFactory.Instance.CreateGrabPoleSprite(SpriteEffects.FlipHorizontally);
                    Speed = (Globals.BlockSize) * 16;
                    alreadyTurned = true;
                    SoundFactory.PlaySound(SoundFactory.Instance.stageClear);
                }
                counter++;
            }
            else if (alreadyTurned)
            {
                Speed = 0;
                if (counter >= 75)
                {
                    player.State = new RightAutoMovingPlayerState(player);
                }
                counter++;
            }
        }
    }
}
