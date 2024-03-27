using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.Interfaces
{
    public interface IPlayerSprite
    {
        public Rectangle sourceRectangle { get; }
        public void Update(int currentSpeed);
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color);
    }
}
