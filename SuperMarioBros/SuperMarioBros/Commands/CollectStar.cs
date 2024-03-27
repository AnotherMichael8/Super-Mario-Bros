using SuperMarioBros.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    internal class CollectStar : ICommand
    {
        private Game1 game;
        public CollectStar(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            IPlayer starMario = new StarMario(game.MarioPlayer);
        }
    }
}
