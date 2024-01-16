using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    public class CrouchCommand : ICommand
    {
        private Game1 game;
        public CrouchCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.MarioPlayer.Crouch();
        }
    }
}
