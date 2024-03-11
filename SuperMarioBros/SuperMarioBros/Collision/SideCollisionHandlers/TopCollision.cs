using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collision.SideCollisionHandlers
{
    public class TopCollision : ICollision
    {
        public TopCollision() { }
        public Vector2 UpdateDirectionPosition(int width, int height, Vector2 updatePosition)
        {
            return new Vector2(updatePosition.X, (int)updatePosition.Y - height);
        }
    }
}