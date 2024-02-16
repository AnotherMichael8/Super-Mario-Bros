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
        private Vector2 Position;
        protected int horizMovementFactor;
        protected int verticalMovementFactor;
        private double trueXPosition;
        protected double trueYPosition;
        protected bool spawnCollectible;
        public abstract int SpawnDist { get; }
        private Vector2 originalPosition;
        public bool IsFalling { get; set; }
        public AbstractCollectibles(Vector2 position)
        {
            Position = position;
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
                if (IsFalling)
                {
                    verticalMovementFactor += (int)(3 * Globals.ScreenSizeMulti);
                }
                else
                    verticalMovementFactor = (int)(16 * Globals.ScreenSizeMulti);
                trueYPosition += verticalMovementFactor/16.0;
            }
            else if(spawnCollectible)
            {
                SpawnCollectible(originalPosition);
            }
            Position = new Vector2((int)trueXPosition, (int)trueYPosition);
            sprite.Update();
        }
        public virtual void MoveLeft() { }
        public virtual void MoveRight() { }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, Position, color);
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
            for(int i = 0; i < Collectibles.Count; i++)
            {
                ICollectibles collectible = Collectibles[i];
                collectible.Update();
            }
        }
        public virtual Rectangle GetHitBox()
        {
            if (!spawnCollectible)
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
            else
                return Rectangle.Empty;
        }
        public Vector2 GetPosition()
        {
            return Position;
        }
        public void SetPosition(float x, float y)
        {
            Position.X = (int)x;
            Position.Y = (int)y;
            trueXPosition = (int)x;
            trueYPosition = (int)y;
        }
    }
}
