using SuperMarioBros.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    public class EnterPipeCommand : ICommand
    {
        private Game1 game;
        public EnterPipeCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (CollisionManager.IsPipeEnterAble(game.MarioPlayer))
            {
                //game.MarioPlayer
            }
        }
    }
}
