﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collision;
using SuperMarioBros.Enemies.Goomba.GoombaSprites;
using SuperMarioBros.Enemies.Goomba.GoombaStates;

namespace SuperMarioBros.Enemies.Goomba
{
    public class Goomba : AbstractEnemy
    {
        private int Height = (int)Globals.BlockSize;
        private int Width = (int)Globals.BlockSize;
        public Goomba(Vector2 position) : base(position)
        {
            Sprite = EnemySpriteFactory.Instance.CreateMovingGoombaEnemySprite();
            State = new GoombaMovingLeftState(this);
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
            IsDead = true;
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
            return new Rectangle((int)Position.X + 4, (int)Position.Y + 10, 24, (int)(Globals.BlockSize - 20));
        }
        public override Rectangle GetBlockHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
        }
    }
}
