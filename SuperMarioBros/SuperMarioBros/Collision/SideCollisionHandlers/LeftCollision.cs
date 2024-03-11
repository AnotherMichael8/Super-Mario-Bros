using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collision.SideCollisionHandlers
{
    public class LeftCollision : ICollision
    {
        public LeftCollision() { }
        public Vector2 UpdateDirectionPosition(int width, int height, Vector2 updatePosition)
        {
            return new Vector2(updatePosition.X - width, updatePosition.Y);
        }
    }
}
