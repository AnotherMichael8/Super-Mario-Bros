using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace SuperMarioBros.Enemies.Koopa.KoopaStates
{
    public class KoopaMovingLeftState : IEnemyState
    {
        private Koopa koopa;
        public KoopaMovingLeftState(Koopa koopa)
        {
            this.koopa = koopa;
        }
        public void Kill()
        {
            koopa.State = new KoopaIdleShellState(koopa);
        }
        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
            koopa.State = new KoopaMovingRightState(koopa);
        }

        public void Update()
        {
            koopa.Position = new Vector2(koopa.Position.X - 1, koopa.Position.Y);
        }
    }
}
