using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates.WonderStates
{
    public class WonderSeedCollectPlayerState : AbstractPlayerState
    {
        private int counter;
        private IPlayerState previousState;
        public WonderSeedCollectPlayerState(Player player, IPlayerState state) : base(player)
        {
            Speed = 0;
            JumpingSpeed = 16;
            counter = 0;
            previousState = state;
        }
        public override void UseAbility() { }
        public override void TriggerWonderState(Vector2 wonderPosition) { }
        public override void WonderEventEnd(IPlayerState state) { }
        public override void Kill() { }
        public override void Update()
        {
            base.Update();
            if(counter >= 210)
            {
                player.State = previousState;
                WonderTime = false;
            }
            counter++;
        }
    }
}
