using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Commands;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerStates;

namespace SuperMarioBros.PlayerCharacter
{
    public class Player : PowerUp, IPlayer
    {
        private Game1 game;
        public static List<IPowerUpAbility> Abilities;
        public Vector2 Position { get; 
            set; }
        public IPlayerSprite Sprite { get; set; }
        public IPlayerState State { get; set; }
        public int Speed { get; set; }
        public bool OnGround { get; set; }
        public bool HitBoxOff { get; set; }
        public bool Invincible { get; set; }
        public bool IsFalling { get; set; }
        public int chunk { get; private set; }
        public static PowerUps CurrentPowerUp { get; private set; }
        private int playerSizeMulti;

        public Player(Game1 game)
        {
            this.game = game;
            Position = new Vector2(0, Globals.ScreenHeight - (int)(4 * Globals.BlockSize));
            State = new RightIdlePlayerState(this);
            IsFalling = false;
            chunk = (int)(Position.X / Globals.ScreenWidth);
            playerSizeMulti = 1;
            CurrentPowerUp = PowerUps.NONE;
            Abilities = new List<IPowerUpAbility>();
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
        public void Hop()
        {
            State.Hop();
        }
        public void Crouch()
        {
            State.Crouch();
        }
        public void StopJumping()
        {
            State.StopJumping();
        }
        public void GrabPole()
        {
            State.GrabPole();
        }
        public void EnterPipe(Pipe pipe)
        {
            State.EnterPipe(pipe);
        }
        public void Kill()
        {
            State.Kill();
            playerSizeMulti = 1;
            CurrentPowerUp = PowerUps.NONE;
            PlayerSpriteFactory.Instance.UpdatePowerUp(CurrentPowerUp);
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
            PlayerSpriteFactory.Instance.UpdatePowerUp(CurrentPowerUp);
        }
        public void PowerUpFlower()
        {
            if (!(CurrentPowerUp.Equals(PowerUps.FIREFLOWER)))
            {
                State.PowerUpFlower();
                playerSizeMulti = 2;
                CurrentPowerUp = PowerUps.FIREFLOWER;
                PlayerSpriteFactory.Instance.UpdatePowerUp(CurrentPowerUp);
            }
        }
        public void PowerUpStar()
        {
            new CollectStar(game).Execute();
        }
        public void TriggerWonderState(Vector2 wonderPosition)
        {
            State.TriggerWonderState(wonderPosition);
        }
        public void WonderEventEnd()
        {
            State.WonderEventEnd(State);
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
            for (int i = 0; i < Abilities.Count; i++)
                Abilities[i].Update();
            if (Position.Y > Globals.ScreenHeight + Globals.BlockSize)
            {
                Kill();
                Position = new Vector2(Position.X, (int)(Globals.ScreenHeight + Globals.BlockSize / 2));
            }

        }
        public void Draw(SpriteBatch spriteBatch, Color[] color)
        {
            Sprite.Draw(spriteBatch, Position, color);
            foreach (IPowerUpAbility ability in Abilities)
                ability.Draw(spriteBatch);
        }
        public Rectangle GetHitBox()
        {
            if(!HitBoxOff)
                return new Rectangle((int)Position.X + 4, (int)Position.Y, (int)Globals.BlockSize - 8, (int)(Globals.BlockSize * playerSizeMulti));
            else
                return Rectangle.Empty;
        }
        public Rectangle GetBlockHitBox()
        {
            if (!HitBoxOff)
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)(Globals.BlockSize * playerSizeMulti));
            else
                return Rectangle.Empty;
        }
        public Rectangle GetRectanglePosition()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)(Globals.BlockSize * playerSizeMulti));
        }
    }
}
