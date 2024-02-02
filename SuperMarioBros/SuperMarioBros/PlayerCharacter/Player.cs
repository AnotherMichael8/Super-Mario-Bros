using System;
using System.Collections;
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
        public static int previousY;
        public IPlayerSprite Sprite { get; set; }
        public IPlayerState State { get; set; }
        public int Speed { get; set; }
        public int JumpingSpeed { get; set; }
        public bool OnGround { get; set; }
        public bool IsDead { get; set; }
        public bool IsFalling { get; set; }

        public Player(Game1 game)
        {
            this.game = game;
            Position = new Vector2(0,384);
            previousY = 384;
            State = new RightIdlePlayerState(this);
            IsFalling = false;
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
        public void Fall()
        {
            State.Fall();
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
        public void Kill()
        {
            State.Kill();
        }
        public void StopUpwardMovement()
        {
            State.StopUpwardMovement();
        }
        public void SetDecorator(IPlayer decoLink)
        {
            game.MarioPlayer = decoLink;
        }
        public void RemoveDecorator()
        {
            game.MarioPlayer = this;
        }
        public void Update()
        {
            if (IsFalling)
                Fall();
            State.Update();
            Position = new Vector2(Position.X, Position.Y + 1);
            Sprite.Update(Math.Abs(Speed)/16);          
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
             Sprite.Draw(spriteBatch, Position, color);
        }
        public Rectangle GetHitBox()
        {
            if(!IsDead)
                return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
            else
                return Rectangle.Empty;
        }
    }
}
