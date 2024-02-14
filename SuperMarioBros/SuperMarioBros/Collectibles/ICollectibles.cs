using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles
{
    public interface ICollectibles : IGameObject
    {
        public int SpawnDist { get; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Color color);
        public void MoveLeft();
        public void MoveRight();
        public void Collect();
    }
}
