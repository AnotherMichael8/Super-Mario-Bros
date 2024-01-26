using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public static List<AbstractEnemy> Enemies = new List<AbstractEnemy>();
        public Vector2 Position { get; set; }
        public IEnemyState State { get; set; }
        public IEnemySprite Sprite { get; set; }
        public bool IsDead { get; protected set; }
        public AbstractEnemy(Vector2 position)
        {
            Position = position;
            IsDead = false;
            Enemies.Add(this);
            CollisionManager.GameObjectList.Add(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Sprite.Draw(spriteBatch, Position);
            }
        }
        public void Update()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Position = new Vector2(Position.X, Position.Y + 10);
                Enemies[i].Sprite.Update();
                Enemies[i].State.Update();
            }
        }
        public abstract Rectangle GetHitBox();
        public abstract void Kill();
        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract int GetHeight();
        public abstract int GetWidth();
        //public abstract void Update();
    }
}
