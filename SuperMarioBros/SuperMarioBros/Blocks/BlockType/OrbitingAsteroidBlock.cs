using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Blocks.BlockType
{
    public class OrbitingAsteroidBlock : AsteroidBlock
    {
        private const double RADIUS = 2 * 32;
        private Vector2 centerPoint;
        private double radiusAdj;
        public OrbitingAsteroidBlock(Vector2 position, Vector2 directionVector, Vector2 centerPoint, int width = 3, int height = 3) : base(position, directionVector, width, height)
        {
            this.centerPoint = centerPoint;
            radiusAdj = centerPoint.X * centerPoint.X + centerPoint.Y * centerPoint.Y - RADIUS * RADIUS;
        }
        public override void Update()
        {
            double b;
            double c;
            if(Math.Abs(Position.X - centerPoint.X) > Math.Abs(Position.Y - centerPoint.Y))
            {
                b = centerPoint.Y;
                double newXPosition;
                if(Position.Y <= centerPoint.Y)
                {
                    HorzSpeed = directionVector.X;
                    newXPosition = Position.X + HorzSpeed;
                    c = newXPosition * newXPosition + centerPoint.X * newXPosition - radiusAdj;
                    VertSpeed = Position.Y - ((Math.Sqrt(Math.Pow(b, 2) - 4 * c) - b) / 2);
                    VertSpeed /= Globals.BlockSize;
                }
                else
                {
                    HorzSpeed = directionVector.X * -1;
                    newXPosition = Position.X + HorzSpeed;
                    c = newXPosition * newXPosition + centerPoint.X * newXPosition - radiusAdj;
                    VertSpeed = Position.Y - ((Math.Sqrt(Math.Pow(b, 2) - 4 * c) + b) / 2);
                    VertSpeed /= Globals.BlockSize;
                }
            }
            else
            {
                b = centerPoint.X;
                double newYPosition;
                if (Position.X <= centerPoint.X)
                {
                    VertSpeed = directionVector.Y;
                    newYPosition = Position.Y + VertSpeed;
                    c = newYPosition * newYPosition + centerPoint.Y * newYPosition - radiusAdj;
                    HorzSpeed = Position.X - ((Math.Sqrt(Math.Pow(b, 2) - 4 * c) - b) / 2);
                    HorzSpeed /= Globals.BlockSize;
                }
                else
                {
                    VertSpeed = directionVector.Y * -1;
                    newYPosition = Position.Y + VertSpeed;
                    c = newYPosition * newYPosition + centerPoint.Y * newYPosition - radiusAdj;
                    HorzSpeed = Position.X - ((Math.Sqrt(Math.Pow(b, 2) - 4 * c) + b) / 2);
                    HorzSpeed /= Globals.BlockSize;
                }
            }
            
            base.Update();
        }
    }
}
