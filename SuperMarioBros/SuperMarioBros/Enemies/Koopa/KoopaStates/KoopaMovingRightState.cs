using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies.Koopa.KoopaStates
{
    public class KoopaMovingRightState : IEnemyState
    {
        private Koopa koopa;
        public KoopaMovingRightState(Koopa koopa)
        {
            this.koopa = koopa;
        }
        public void FallingKill() { }
        public void Kill()
        {

        }
        public void MoveLeft()
        {
            koopa.State = new KoopaMovingLeftState(koopa);
        }

        public void MoveRight()
        {
        }

        public void Update()
        {
            koopa.Position = new Vector2(koopa.Position.X + 1, koopa.Position.Y);
        }
    }
}
