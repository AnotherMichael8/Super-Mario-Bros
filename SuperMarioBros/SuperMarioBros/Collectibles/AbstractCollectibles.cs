using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks;
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
        protected int movementFactor;
        private double trueXPosition;
        public AbstractCollectibles(Vector2 position)
        {
            this.position = position;
            trueXPosition = position.X;
        }
        public void Collect()
        {
            Collectibles.Remove(this);
        }
        public virtual void Update()
        {
            sprite.Update();
            trueXPosition += movementFactor / 16.0;
            position.X = (int)trueXPosition;
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
