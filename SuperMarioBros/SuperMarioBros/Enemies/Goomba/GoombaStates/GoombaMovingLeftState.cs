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
            goomba.State = new GoombaDeathState(goomba);
        }
        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            goomba.State = new GoombaMovingRightState(goomba);
        }

        public void Update()
        {
            goomba.truePositionX -= 16 / 16.0;
            goomba.Position = new Vector2((int)goomba.truePositionX, goomba.Position.Y);
        }
    }
}
