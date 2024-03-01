using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.Interfaces
{
    public interface IPowerUpAbility : IGameObject
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
