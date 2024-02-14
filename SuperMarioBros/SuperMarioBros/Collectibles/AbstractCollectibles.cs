using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks;
using SuperMarioBros.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles
{
    public abstract class AbstractCollectibles : ICollectibles
    {
        public static List<ICollectibles> Collectibles = new List<ICollectibles>();
        protected ICollectiblesSprite sprite;
        protected Vector2 position;
        protected int horizMovementFactor;
        protected int verticalMovementFactor;
        private double trueXPosition;
        protected double trueYPosition;
        protected bool spawnCollectible;
        public abstract int SpawnDist { get; }
        private Vector2 originalPosition;
        public AbstractCollectibles(Vector2 position)
        {
            this.position = position;
            originalPosition = position;
            trueXPosition = position.X;
            trueYPosition = position.Y;
            spawnCollectible = true;
        }
        public void Collect()
        {
            Collectibles.Remove(this);
            CollisionManager.GameObjectList.Remove(this);
        }
        public abstract void SpawnCollectible(Vector2 originalPosition);
        public virtual void Update()
        {
            if (!spawnCollectible) 
            {
                trueXPosition += horizMovementFactor / 16.0;
            }
            else if(spawnCollectible)
            {
                SpawnCollectible(originalPosition);
            }
            position.X = (int)trueXPosition;
            position.Y = (int)trueYPosition;
            sprite.Update();
        }
        public virtual void MoveLeft() { }
        public virtual void MoveRight() { }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, position, color);
        }
        public static void DrawAllSprites(SpriteBatch spriteBatch, Color color)
        {
            foreach(ICollectibles collectibles in Collectibles)
            {
                collectibles.Draw(spriteBatch, color);
            }
        }
        public static void UpdateAllSprites()
        {
            foreach (ICollectibles collectibles in Collectibles)
            {
                collectibles.Update();
            }
        }
        public virtual Rectangle GetHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
        }
    }
}
