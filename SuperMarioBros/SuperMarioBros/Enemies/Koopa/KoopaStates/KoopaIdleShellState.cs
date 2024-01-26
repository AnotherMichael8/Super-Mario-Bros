using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies.Koopa.KoopaStates
{
    public class KoopaIdleShellState : IEnemyState
    {
        private Koopa koopa;
        private int deathCounter;
        public KoopaIdleShellState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Sprite = EnemySpriteFactory.Instance.CreateInShellKoopaEnemySprite();
            deathCounter = 0;
        }
        public void Kill()
        {
        }
        public void MoveLeft()
        {
            koopa.State = new KoopaLeftMovingShellState(koopa);
        }

        public void MoveRight()
        {
            koopa.State = new KoopaRightMovingShellState(koopa);
        }

        public void Update()
        {
            if(deathCounter == 500)
            {
                //AbstractEnemy.Enemies.Remove(koopa);
            }
            deathCounter++;

        }
    }
}
