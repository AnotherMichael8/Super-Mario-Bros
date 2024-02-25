using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class RightFlowerPowerUpAnimationState : AbstractPlayerState
    {
        private AbstractPlayerState previousState;
        private IPlayerSprite previousSprite;
        private int frameCnt;
        public RightFlowerPowerUpAnimationState(Player player, AbstractPlayerState state) : base(player)
        {
            previousSprite = player.Sprite;
            player.Sprite = PlayerSpriteFactory.Instance.CreateRightAnimationFlowerSprite();
            //Speed = 0;
            //JumpingSpeed = 0;
            if (JumpingSpeed > 64)
                JumpingSpeed = 64;
            previousState = state;
            frameCnt = 0;
        }
        public override void Update()
        {
            if (frameCnt >= 60)
            {
                player.Sprite = PlayerSpriteFactory.Instance.CreateNewPlayerSprite(previousSprite);
                player.State = previousState;
            }
            else
            {
                player.Position = new Vector2(player.Position.X, player.Position.Y - 1);
            }
            frameCnt++;
        }
    }
}
    