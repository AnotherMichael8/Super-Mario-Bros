using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    public class StopJumpingCommand : ICommand
    {
        private Game1 game;
        public StopJumpingCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MarioPlayer.StopJumping();
        }
    }
}
