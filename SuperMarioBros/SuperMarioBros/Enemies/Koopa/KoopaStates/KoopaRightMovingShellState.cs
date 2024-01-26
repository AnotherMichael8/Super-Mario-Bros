using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Enemies.Koopa.KoopaStates
{
    public class KoopaRightMovingShellState : IEnemyState
    {
        private Koopa koopa;
        private int deathCounter;
        public KoopaRightMovingShellState(Koopa koopa)
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
        }

        public void MoveRight()
        {
        }

        public void Update()
        {
            koopa.Position = new Vector2(koopa.Position.X + 6, koopa.Position.Y);
        }
    }
}
