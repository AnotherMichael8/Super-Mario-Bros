using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collision.SideCollisionHandlers
{
    public class RightCollision : ICollision
    {
        public RightCollision() { }
        public Vector2 UpdateDirectionPosition(int width, int height, Vector2 updatePosition)
        {
            return new Vector2(updatePosition.X - width + (int)Globals.BlockSize, updatePosition.Y);
        }
    }
}
