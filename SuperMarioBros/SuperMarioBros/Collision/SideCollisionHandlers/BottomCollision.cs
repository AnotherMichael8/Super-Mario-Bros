﻿using Microsoft.Xna.Framework;

namespace SuperMarioBros.Collision.SideCollisionHandlers
{
    public class BottomCollision : ICollision
    {
        public BottomCollision() { }

        public Vector2 UpdateDirectionPosition(int width, int height, Vector2 updatePosition)
        {
            return new Vector2(updatePosition.X, updatePosition.Y + height);
        }
    }
}
