using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Camera
{
    public class CameraController
    {
        private Game1 game;
        public static int CameraPosition { get; private set; } = 0;
        public CameraController(Game1 game)
        {
            this.game = game;
        }
        public void Update()
        {
            if(game.MarioPlayer.Position.X - CameraPosition > 256)
            {
                CameraPosition += (int)(game.MarioPlayer.Position.X - CameraPosition - 256);
            }
        }

    }
}
