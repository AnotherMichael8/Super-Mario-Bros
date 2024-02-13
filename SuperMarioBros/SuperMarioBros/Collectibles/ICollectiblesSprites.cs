using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles
{
    public interface ICollectiblesSprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color);
    }
}
