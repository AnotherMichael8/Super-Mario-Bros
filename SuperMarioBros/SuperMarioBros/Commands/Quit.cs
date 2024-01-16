using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    public class Quit : ICommand
    {
        private Game1 game1;
        public Quit(Game1 game)
        {
            this.game1 = game;

        }
        public void Execute()
        {
            game1.Exit();
        }
    }
}
