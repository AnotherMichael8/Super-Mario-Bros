using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Enemies.Goomba.GoombaStates
{
    public class GoombaMovingLeftState : IEnemyState
    {
        private Goomba goomba;
        public GoombaMovingLeftState(Goomba goomba)
        {
            this.goomba = goomba;
        }
        public void Kill()
        {
            goomba.Position = new Vector2(goomba.Position.X + 200, goomba.Position.Y);
        }
        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            goomba.GoombaState = new GoombaMovingRightState(goomba);
        }

        public void Update()
        {
            goomba.Position = new Vector2(goomba.Position.X - 1, goomba.Position.Y);
        }
    }
}
