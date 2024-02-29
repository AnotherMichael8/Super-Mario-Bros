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
    public class Player : PowerUp, IPlayer
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
        public int chunk { get; private set; }
        public static PowerUps CurrentPowerUp { get; private set; }
        private int playerSizeMulti;

        public Player(Game1 game)
        {
            this.game = game;
            Position = new Vector2(0, Globals.ScreenHeight - (int)(4 * Globals.BlockSize));
            previousY = 384;
            State = new RightIdlePlayerState(this);
            IsFalling = false;
            chunk = (int)(Position.X / Globals.ScreenWidth);
            playerSizeMulti = 1;
            CurrentPowerUp = PowerUps.NONE;
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
            playerSizeMulti = 1;
            CurrentPowerUp = PowerUps.NONE;
        }
        public void StopUpwardMovement()
        {
            State.StopUpwardMovement();
        }
        public void PowerUpMushroom()
        {
            State.PowerUpMushroom();
            playerSizeMulti = 2;
            Position = new Vector2(Position.X, (int)(Position.Y - Globals.BlockSize));
            CurrentPowerUp = PowerUps.MUSHROOM;
        }
        public void PowerUpFlower()
        {
            if (!(CurrentPowerUp.Equals(PowerUps.FIREFLOWER)))
            {
                State.PowerUpFlower();
                playerSizeMulti = 2;
                CurrentPowerUp = PowerUps.FIREFLOWER;
            }
        }
        public void PowerUpStar()
        {
            State.PowerUpStar();
        }
        public void UseAbility()
        {
            State.UseAbility();
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
            Sprite.Update(Math.Abs(Speed));
            chunk = (int)(Position.X / Globals.ScreenWidth);
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
             Sprite.Draw(spriteBatch, Position, color);
        }
        public Rectangle GetHitBox()
        {
            if(!IsDead)
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize * playerSizeMulti);
            else
                return Rectangle.Empty;
        }
    }
}
