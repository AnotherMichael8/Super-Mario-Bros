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
        private int spawnCounter1;
        private int spawnCounter2;
        private int spawnCounter3;
        private int spawnCounter4;
        private List<AsteroidBlock> asteroids;
        public WonderLevel1Event() 
        {
            spawnCounter1 = 0;
            spawnCounter2 = 0;
            spawnCounter3 = 0;
            spawnCounter4 = 0;
            asteroids = new List<AsteroidBlock>();
        }
        public override void Update()
        {
            if(spawnCounter1 >= (int)(Globals.BlockSize * 6))
            {
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(4 * Globals.BlockSize + 8 * Globals.ScreenWidth), (int)(-0 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(1,0)));
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(9 * Globals.BlockSize + 11 * Globals.ScreenWidth), (int)(-6 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(-1, 0)));
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(4 * Globals.BlockSize + 8 * Globals.ScreenWidth), (int)(-21 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(1, 0)));
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(9 * Globals.BlockSize + 11 * Globals.ScreenWidth), (int)(-11 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(-3, 0)));
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(9 * Globals.BlockSize + 11 * Globals.ScreenWidth), (int)(-40 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(-3, 0)));
                //SpawnAsteroid(new AsteroidBlock(new Vector2((int)(9 * Globals.BlockSize + 11 * Globals.ScreenWidth), (int)(-15 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(-2, 0)));
                spawnCounter1 = 0;
            }
            if (spawnCounter2 >= (int)(Globals.BlockSize * 3))
            {
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(9 * Globals.BlockSize + 11 * Globals.ScreenWidth), (int)(-15 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(-2, 0)));
                //SpawnAsteroid(new AsteroidBlock(new Vector2((int)(4 * Globals.BlockSize + 8 * Globals.ScreenWidth), (int)(-27 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(3, 0)));
                spawnCounter2 = 0;
            }
            if(spawnCounter3 >= (int)(Globals.BlockSize * 1.5))
            {
                //SpawnAsteroid(new AsteroidBlock(new Vector2((int)(4 * Globals.BlockSize + 8 * Globals.ScreenWidth), (int)(-27 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(3, 0)));
                spawnCounter3 = 0;
            }
            if(spawnCounter4 >= (int)(Globals.BlockSize * (6/4.0)))
            {
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(4 * Globals.BlockSize + 8 * Globals.ScreenWidth), (int)(-27 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(4, 0)));
                spawnCounter4 = 0;
            }
            spawnCounter1++;
            spawnCounter2++;
            spawnCounter3++;
            spawnCounter4++;
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
