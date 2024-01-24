using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using SuperMarioBros.PlayerCharacter.PlayerStates;

namespace SuperMarioBros.PlayerCharacter
{
    public class Player : IPlayer
    {
        private Game1 game;
        public Vector2 Position { get; set; }
        public IPlayerSprite Sprite { get; set; }
        public IPlayerState State { get; set; }
        public int Speed { get; set; }
        public int JumpingSpeed { get; set; }
        public bool OnGround { get; set; }

        public Player(Game1 game)
        {
            this.game = game;
            Position = new Vector2(0,384);
            State = new RightIdlePlayerState(this);
            Speed = 100;
        }

        public void BecomeIdle()
        {
            State.BecomeIdle();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
        }

        public void Sprint()
        {
            State.Sprint();
        }
        public void StopSprinting()
        {
            State.StopSprinting();
        }

        public void Jump()
        {
            State.Jump();
        }

        public void Crouch()
        {
            State.Crouch();
        }
        public void StopJumping()
        {
            State.StopJumping();
        }
        public void Update()
        {
            State.Update();
            Sprite.Update(Speed);
            Position = new Vector2(Position.X, Position.Y + 10);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
             Sprite.Draw(spriteBatch, Position, color);
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }
    }
}
