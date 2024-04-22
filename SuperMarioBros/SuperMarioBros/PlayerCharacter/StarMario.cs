using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerStates;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMarioBros.PlayerCharacter.Interfaces.PowerUp;

namespace SuperMarioBros.PlayerCharacter
{
    public class StarMario : IPlayer
    {
        public static List<IPowerUpAbility> Abilities;
        public Vector2 Position { get => decoratedPlayer.Position; set => decoratedPlayer.Position = value; }
        public IPlayerSprite Sprite { get => decoratedPlayer.Sprite; set => decoratedPlayer.Sprite = value; }
        public IPlayerState State { get => decoratedPlayer.State; set => decoratedPlayer.State = value; }
        public int Speed { get; set; }
        public bool OnGround { get => decoratedPlayer.OnGround; set => decoratedPlayer.OnGround = value; }
        public bool HitBoxOff { get; set; }
        public bool Invincible { get; set; }
        public bool IsFalling { get => decoratedPlayer.IsFalling; set => decoratedPlayer.IsFalling = value; }
        public int chunk { get => decoratedPlayer.chunk; }
        public static PowerUps CurrentPowerUp { get; private set; }
        private IPlayer decoratedPlayer;
        private int starCounter;
        private int timer;

        protected readonly Color[][] StarColors =
        {
            new Color[] { new Color(12, 147, 0), new Color(255, 254, 255), new Color(234, 158, 34) },
            new Color[] { new Color(181, 49, 32), new Color(255, 254, 255), new Color(234, 158, 34) },
            new Color[] { Color.Black, new Color(254, 204, 197), new Color(153, 78, 0) }
        };
        public StarMario(IPlayer decoratedPlayer)
        {
            this.decoratedPlayer = decoratedPlayer;
            Position = decoratedPlayer.Position;
            starCounter = 0;
            timer = 0;
            SetDecorator(this);
        }
        public void BecomeIdle()
        {
            decoratedPlayer.BecomeIdle();
        }
        public void MoveLeft()
        {
            decoratedPlayer.MoveLeft();
        }
        public void MoveRight()
        {
            decoratedPlayer.MoveRight();
        }
        public void Sprint()
        {
            decoratedPlayer.Sprint();
        }
        public void StopSprinting()
        {
            decoratedPlayer.StopSprinting();
        }
        public void Fall()
        {
            decoratedPlayer.Fall();
        }
        public void Jump()
        {
            decoratedPlayer.Jump();
        }
        public void Hop()
        {
            decoratedPlayer.Hop();
        }
        public void Crouch()
        {
            decoratedPlayer.Crouch();
        }
        public void StopJumping()
        {
            decoratedPlayer.StopJumping();
        }
        public void GrabPole()
        {
            decoratedPlayer.GrabPole();
        }
        public void EnterPipe(Pipe pipe)
        {
            decoratedPlayer.EnterPipe(pipe);
        }
        public void Kill()
        {
        }
        public void StopUpwardMovement()
        {
            decoratedPlayer.StopUpwardMovement();
        }
        public void PowerUpMushroom()
        {
            decoratedPlayer.PowerUpMushroom();
        }
        public void PowerUpFlower()
        {
            decoratedPlayer.PowerUpFlower();
        }
        public void WonderEventEnd()
        {
            decoratedPlayer.WonderEventEnd();
        }
        public void PowerUpStar()
        {
            decoratedPlayer.PowerUpStar();
        }
        public void UseAbility()
        {
            decoratedPlayer.UseAbility();
        }
        public void TriggerWonderState(Vector2 wonderPosition)
        {
            decoratedPlayer.TriggerWonderState(wonderPosition);
        }
        public void SetDecorator(IPlayer decoLink)
        {
            decoratedPlayer.SetDecorator(decoLink);
        }
        public void RemoveDecorator()
        {
            decoratedPlayer.RemoveDecorator();
        }
        public void Update()
        {
            if(timer >= 720)
            {
                PlayerSpriteFactory.Instance.RevertTextureData();
                RemoveDecorator();
            }
            starCounter++;
            timer++;
            decoratedPlayer.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Color[] color)
        {
            if (timer / 60 < 10)
            {
                if (starCounter == 0)
                {
                    color = StarColors[0];
                }
                else if (starCounter == 5)
                {
                    color = StarColors[1];
                }
                else if (starCounter == 10)
                {
                    color = StarColors[2];
                    starCounter = 0;
                }
            }
            else
            {
                if (starCounter == 0)
                {
                    color = StarColors[0];
                }
                else if (starCounter == 7)
                {
                    color = StarColors[1];
                }
                else if (starCounter == 14)
                {
                    color = StarColors[2];
                    starCounter = 0;
                }
            }
            decoratedPlayer.Draw(spriteBatch, color);
        }
        public Rectangle GetHitBox()
        {
            return decoratedPlayer.GetHitBox();
        }
        public Rectangle GetBlockHitBox()
        {
            return decoratedPlayer.GetBlockHitBox();
        }
        public Rectangle GetRectanglePosition()
        {
            return decoratedPlayer.GetRectanglePosition();
        }
    }
}
