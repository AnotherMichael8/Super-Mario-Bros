using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies.Goomba.GoombaStates
{
    public class GoombaMovingRightState : IEnemyState
    {
        private Goomba goomba;
        public GoombaMovingRightState(Goomba goomba)
        {
            this.goomba = goomba;
        }
        public void Kill()
        {

        }
        public void MoveLeft()
        {
            goomba.GoombaState = new GoombaMovingLeftState(goomba);
        }

        public void MoveRight()
        {
        }

        public void Update()
        {
            goomba.Position = new Vector2(goomba.Position.X - 1, goomba.Position.Y);
        }
    }
}
