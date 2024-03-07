using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMarioBros.PlayerCharacter.PlayerStates.AbstractPlayerState;

namespace SuperMarioBros.PlayerCharacter
{
    public interface IPlayer : IGameObject
    {
        public Vector2 Position { get; set; }
        public IPlayerSprite Sprite { get; set; }
        public IPlayerState State { get; set; }
        public int Speed { get; set; }
        public bool OnGround { get; set; }
        public bool IsFalling { get; set; }
        public void BecomeIdle();
        public void MoveLeft();
        public void MoveRight();
        public void Sprint();
        public void StopSprinting();
        public void Jump();
        public void Hop();
        public void Crouch();
        public void StopJumping();
        public void Kill();
        public void StopUpwardMovement();
        public void PowerUpMushroom();
        public void PowerUpFlower();
        public void PowerUpStar();
        public void UseAbility();
        public void SetDecorator(IPlayer player);
        public void RemoveDecorator();
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Color color);
    }
}
