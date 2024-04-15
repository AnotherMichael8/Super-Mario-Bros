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
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(2 + 9 * Globals.ScreenWidth), (int)(-0 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(1,0)));
                SpawnAsteroid(new AsteroidBlock(new Vector2((int)(2 + 10 * Globals.ScreenWidth), (int)(-6 * Globals.BlockSize - 12 * Globals.ScreenHeight)), new Vector2(-1, 0)));
                spawnCounter = 0;
            }
            spawnCounter++;
        }
        private void SpawnAsteroid(AsteroidBlock asteroid)
        {
            AbstractBlock.Blocks.Add(asteroid);
            CollisionManager.GameObjectList.Add(asteroid);
            asteroids.Add(asteroid);
        }
    }
}
