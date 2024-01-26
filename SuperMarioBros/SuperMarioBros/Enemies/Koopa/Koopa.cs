using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collision;
using SuperMarioBros.Enemies.Koopa.KoopaSprites;
using SuperMarioBros.Enemies.Koopa.KoopaStates;

namespace SuperMarioBros.Enemies.Koopa
{
    public class Koopa : AbstractEnemy
    {
        private const int Height = 48;
        private const int Width = 32;
        public bool InShell { get; private set; }
        public Koopa(Vector2 position) : base(position)
        {
            Sprite = EnemySpriteFactory.Instance.CreateMovingKoopaEnemySprite();
            State = new KoopaMovingLeftState(this);
            InShell = false;
        }
        public override void MoveRight()
        {
            State.MoveRight();
        }
        public override void MoveLeft()
        {
            State.MoveLeft();
        }
        public override void Kill()
        {
            State.Kill();
            InShell = true;
        }
        public override int GetHeight()
        {
            return Height;
        }
        public override int GetWidth()
        {
            return Width;
        }
        public override Rectangle GetHitBox()
        {
            return new Rectangle((int)Position.X - 2, (int)Position.Y - 9, 30, 48);
        }
    }
}
