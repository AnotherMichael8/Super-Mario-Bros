using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter
{
    public interface IPlayer : IGameObject
    {
        public Vector2 Position { get; set; }
        public bool OnGround { get; set; }
        public void BecomeIdle();
        public void MoveLeft();
        public void MoveRight();
        public void Sprint();
        public void StopSprinting();
        public void Jump();
        public void Crouch();
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Color color);
    }
}
