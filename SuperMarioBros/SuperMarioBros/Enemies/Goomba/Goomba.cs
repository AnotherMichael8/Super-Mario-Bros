using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collision;
using SuperMarioBros.Enemies.Goomba.GoombaSprites;
using SuperMarioBros.Enemies.Goomba.GoombaStates;

namespace SuperMarioBros.Enemies.Goomba
{
    public class Goomba : IEnemy
    {
        public Vector2 Position { get; set; }
        public IEnemyState GoombaState { get; set; }
        public IEnemySprite GoombaSprite { get; set; }
        public Goomba(Vector2 position)
        {
            Position = position;
            GoombaSprite = EnemySpriteFactory.Instance.CreateMovingGoombaEnemySprite();
            GoombaState = new GoombaMovingLeftState(this);
            CollisionManager.GameObjectList.Add(this);
        }
        public void MoveRight()
        {
            GoombaState.MoveRight();
        }
        public void MoveLeft()
        {
            GoombaState.MoveLeft();
        }
        public void Kill()
        {
            GoombaState.Kill();
        }
        public void Update()
        {
            GoombaState.Update();
            GoombaSprite.Update();
            Position = new Vector2(Position.X, Position.Y + 10);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            GoombaSprite.Draw(spriteBatch, Position);
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }
    }
}
