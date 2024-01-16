using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    public class BecomeIdleCommand : ICommand
    {
        private Game1 game;
        public BecomeIdleCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MarioPlayer.BecomeIdle();
        }
    }
}
