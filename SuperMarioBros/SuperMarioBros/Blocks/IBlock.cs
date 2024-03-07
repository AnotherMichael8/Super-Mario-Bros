using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public interface IBlock : IGameObject
    {
        public Vector2 Position { get; set; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Color color);
        public void Bump(PowerUp.PowerUps powerUp);
    }
}
