using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class GrabPolePlayerState : AbstractPlayerState
    {
        public GrabPolePlayerState(Player player) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateGrabPoleSprite();
            Speed = 0;
            JumpingSpeed = 0;
        }
    }
}
