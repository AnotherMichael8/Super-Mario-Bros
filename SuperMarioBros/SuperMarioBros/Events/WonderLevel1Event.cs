using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Collision;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Events
{
    public class WonderLevel1Event : AbstractEvent
    {
        private int spawnCounter;
        private List<AsteroidBlock> asteroids;
        public WonderLevel1Event() 
        {
            spawnCounter = 0;
            asteroids = new List<AsteroidBlock>();
        }
        public override void Update()
        {
            if(spawnCounter >= (int)(Globals.BlockSize * 6))
            {
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(7 * Globals.BlockSize + 8 * Globals.ScreenWidth), (int)(-0 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(1,0)));
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(8 * Globals.BlockSize + 11 * Globals.ScreenWidth), (int)(-6 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(-1, 0)));
                spawnCounter = 0;
            }
            spawnCounter++;
            for(int i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i].Position.X > 9 * Globals.BlockSize + 11 * Globals.ScreenWidth || asteroids[i].Position.X < 6 * Globals.BlockSize + 8 * Globals.ScreenWidth - asteroids[i].width * Globals.BlockSize)
                    DestroyAsteroid(asteroids[i]);
            }
        }
        private void SpawnAsteroid(AsteroidBlock asteroid)
        {
            AbstractBlock.Blocks.Add(asteroid);
            CollisionManager.GameObjectList.Add(asteroid);
            asteroids.Add(asteroid);
        }
        private void DestroyAsteroid(AsteroidBlock asteroid)
        {
            AbstractBlock.Blocks.Remove(asteroid);
            CollisionManager.GameObjectList.Remove(asteroid);
            asteroids.Remove(asteroid);
        }
    }
}
