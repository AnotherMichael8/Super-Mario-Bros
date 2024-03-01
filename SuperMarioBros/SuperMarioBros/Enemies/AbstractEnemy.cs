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
        public static List<IEnemy> Enemies = new List<IEnemy>();
        public Vector2 Position { get; set; }
        public IEnemyState State { get; set; }
        public IEnemySprite Sprite { get; set; }
        public bool IsDead { get; protected set; }
        public int chunk { get; private set; }

        public AbstractEnemy(Vector2 position)
        {
            Position = position;
            IsDead = false;
            Enemies.Add(this);
            CollisionManager.GameObjectList.Add(this);
            chunk = (int)(Position.X / Globals.ScreenWidth);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }
        public void Update()
        {
            Position = new Vector2(Position.X, Position.Y + 1);
            chunk = (int)(Position.X / Globals.ScreenWidth);
            Sprite.Update();
            State.Update();
        }
        public static void UpdateAllEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Update();
            }
        }
        public static void DrawAllEnemies(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Draw(spriteBatch);
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
