using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace SuperMarioBros.PlayerCharacter.PlayerStates
{
    public class WonderOrbPlayerState : AbstractPlayerState
    {
        private int counter;
        private Vector2 flowerPosition;
        private double trueXPosition;
        private double trueYPosition;
        private double xIncrementer;
        private double yIncrementer;
        private const double NUM_FRAMES = 100.0;
        public WonderOrbPlayerState(Player player, Vector2 flowerPosition) : base(player)
        {
            player.Sprite = PlayerSpriteFactory.Instance.CreateWonderOrbSprite();
            flowerPosition.Y -= (int)(8 * Globals.ScreenSizeMulti);
            this.flowerPosition = flowerPosition;        
            Speed = 0;
            JumpingSpeed = 16;
            counter = 0;
            trueXPosition = player.Position.X;
            trueYPosition = player.Position.Y;
            xIncrementer = ((flowerPosition.X + (int)(Globals.BlockSize/2 + 2)) - (player.Position.X + (int)(Globals.BlockSize / 2))) / NUM_FRAMES;
            yIncrementer = ((flowerPosition.Y + (int)(Globals.BlockSize / 2 + 2)) - (player.Position.Y + (int)(Globals.BlockSize / 2))) / NUM_FRAMES;
        }
        public override void UseAbility() { }
        public override void TriggerWonderState(Vector2 wonderPosition) { }
        public override void Kill() { }
        public override void Update()
        {
            trueXPosition += xIncrementer;
            trueYPosition += yIncrementer;
            if (counter == (int)NUM_FRAMES /*player.Position.X == flowerPosition.X*/)
            {
                xIncrementer = 0;
                yIncrementer = 0;
                trueXPosition = flowerPosition.X;
                trueYPosition = flowerPosition.Y;
            }
            else if(counter == 180)
            {
                player.State = new WonderRightIdlePlayerState(player);
            }
            player.Position = new Vector2((int)trueXPosition, (int)(trueYPosition + 16));
            counter++;
        }
    }
}
