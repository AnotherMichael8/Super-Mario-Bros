using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class WonderOrbPlayerState : AbstractPlayerState
    {
        public WonderOrbPlayerState(Player player, Vector2 flowerPosition) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateWonderOrbSprite();
            double slope = (flowerPosition.Y - player.Position.Y)/(flowerPosition.X - player.Position.X);
            Speed = 0;
            JumpingSpeed = 0;
        }
        public override void UseAbility() { }
        public override void UpdateMovement()
        {

        }

    }
}
