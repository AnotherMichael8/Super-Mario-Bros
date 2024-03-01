using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.Interfaces
{
    public interface IPowerAbilitySprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
