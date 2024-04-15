using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SuperMarioBros.Enemies
{
    public interface IEnemy : IGameObject
    {
        public Vector2 Position { get; set; }
        public bool IsDead { get; }
        public bool IsFalling { get; set; }
        public IEnemyState State { get; set; }
        public IEnemySprite Sprite { get; set; }
        public void MoveLeft();
        public void MoveRight();
        public void Kill();
        public int GetHeight();
        public int GetWidth();
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
