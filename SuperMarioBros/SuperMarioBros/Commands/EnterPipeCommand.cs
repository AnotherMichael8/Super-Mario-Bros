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
        private ICollision side;
        public EnterPipeCommand(Game1 game, ICollision side)
        {
            this.game = game;
            this.side = side;
        }

        public void Execute()
        {
            if (CollisionManager.IsPipeEnterAble(game.MarioPlayer, side))
            {
                //game.MarioPlayer
            }
        }
    }
}
