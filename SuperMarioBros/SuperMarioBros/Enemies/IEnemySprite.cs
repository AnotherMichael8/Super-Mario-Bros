using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies
{
    public interface IEnemySprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
