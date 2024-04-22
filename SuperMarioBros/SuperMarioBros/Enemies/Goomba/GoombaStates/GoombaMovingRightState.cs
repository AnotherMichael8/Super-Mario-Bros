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
        public void FallingKill()
        {
            goomba.State = new FallingGoombaDeathState(goomba);
        }
        public void Kill()
        {
            goomba.State = new GoombaDeathState(goomba);
        }
        public void MoveLeft()
        {
            goomba.State = new GoombaMovingLeftState(goomba);
        }

        public void MoveRight()
        {
        }

        public void Update()
        {
            goomba.truePositionX += 16 / 16.0;
            goomba.Position = new Vector2((int)goomba.truePositionX, goomba.Position.Y);
        }
    }
}
