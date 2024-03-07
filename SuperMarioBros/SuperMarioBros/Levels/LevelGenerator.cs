﻿using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Collision;
using System.IO;
using System.Collections.Generic;
using SuperMarioBros.Blocks;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.Enemies;
using SuperMarioBros.Enemies.Goomba;
using SuperMarioBros.Enemies.Koopa;

namespace SuperMarioBros.Levels
{
    public class LevelGenerator
    {
        private List<IGameObject[]> ChunkObjects;
        public LevelGenerator()
        {
            ChunkObjects = new List<IGameObject[]>();
        }
        public void CreateAllFiles(int numBlocks)
        {
            for (int i = 0; i < numBlocks; i++)
            {
                string fileName = Directory.GetCurrentDirectory();
                fileName = fileName.Substring(0, fileName.Length - 16) + "Levels/LevelCSV/1-1." + i + ".csv";
                string[] CSVLine = File.ReadAllLines(fileName);

                IGameObject[] gameObjects = new IGameObject[CSVLine.Length];
                for(int c = 0; c < CSVLine.Length; c++)
                {
                    string gameObject = CSVLine[c];
                    string[] objDetails = gameObject.Split(",");
                    if (objDetails[0].Equals("Block"))
                    {
                        gameObjects[c] = CreateBlockObject(objDetails, i);
                    }
                    if (objDetails[0].Equals("Enemy"))
                    {
                        gameObjects[c] = CreateEnemyObjects(objDetails, i);
                    }
                }
                ChunkObjects.Add(gameObjects);
            }
        }
        public void LoadFile(int levelChunk)
        {
            foreach (IGameObject gameObject in ChunkObjects[levelChunk])
            {
                if(gameObject is IBlock block)
                {
                    AbstractBlock.Blocks.Add(block);
                }
                if(gameObject is IEnemy enemy)
                {
                    AbstractEnemy.Enemies.Add(enemy);
                }
                if(gameObject != null)
                    CollisionManager.GameObjectList.Add(gameObject);
            }
        }
        public void UnloadFile(int levelChunk)
        {
            foreach (IGameObject gameObject in ChunkObjects[levelChunk])
            {
                if (gameObject is IBlock block)
                {
                    if(block is not GroundBlock)
                        AbstractBlock.Blocks.Remove(block);
                }
                if(gameObject != null && gameObject is not GroundBlock)
                    CollisionManager.GameObjectList.Remove(gameObject);
            }
        }
        private IBlock CreateBlockObject(string[] blockDetails, int levelChunk)
        {
            Vector2 position = new Vector2((int)(int.Parse(blockDetails[2]) * Globals.BlockSize + Globals.ScreenWidth * levelChunk),  (int)(int.Parse(blockDetails[3]) * Globals.BlockSize));
            IBlock block = null;
            if (blockDetails[1].Equals("QuestionBlock"))
            {
                block = new QuestionBlock(position, CreateCollectibleObject(blockDetails[4], position));
            }
            else if (blockDetails[1].Equals("BreakableBrickBlock"))
            {
                block = new BreakableBrickBlock(position, CreateCollectibleObject(blockDetails[4], position));
            }
            else if (blockDetails[1].Equals("Pipe"))
            {
                block = new Pipe(position, int.Parse(blockDetails[4]));
            }
            else if (blockDetails[1].Equals("GroundBlock"))
            {
                block = new GroundBlock(position, int.Parse(blockDetails[4]), int.Parse(blockDetails[5]));
            }
            else if (blockDetails[1].Equals("DiamondBlock"))
            {
                block = new DiamondBlock(position, int.Parse(blockDetails[4]));
            }
            else if (blockDetails[1].Equals("InvisibleBlock"))
            {
                block = new InvisibleBlock(position, CreateCollectibleObject(blockDetails[4], position));
            }
            return block;
        }
        private ICollectibles CreateCollectibleObject(string collectible, Vector2 position)
        {
            if(collectible.Equals("POWERUP"))
            {
                return new Flower(position);
            }
            else if(collectible.Equals("COIN"))
            {
                return new Coin(new Vector2(position.X + (int)(4 * Globals.ScreenSizeMulti), (int)(position.Y - Globals.BlockSize)));
            }
            else if(collectible.Equals("1UP"))
            {
                return new Flower(position);
            }
            else
            {
                return null;
            }
        }
        private IEnemy CreateEnemyObjects(string[] blockDetails, int levelChunk)
        {
            Vector2 position = new Vector2((int)(int.Parse(blockDetails[2]) * Globals.BlockSize + Globals.ScreenWidth * levelChunk), (int)(int.Parse(blockDetails[3]) * Globals.BlockSize));
            IEnemy enemy = null;
            if (blockDetails[1].Equals("Goomba"))
            {
                enemy = new Goomba(position);
            }
            else if (blockDetails[1].Equals("Koopa"))
            {
                enemy = new Koopa(position);
            }
            return enemy;
        }
        public void ReplaceObject(IGameObject orginalObj, IGameObject newObj)
        {
            for (int i = 0;  i < ChunkObjects.Count; i++) 
            {
                if (i == orginalObj.chunk)
                {
                    for (int c = 0; c < ChunkObjects[i].Length; c++)
                    {
                        if(ChunkObjects[i][c] != null && ChunkObjects[i][c].Equals(orginalObj))
                        {
                            ChunkObjects[i][c] = newObj;
                        }
                    }
                }
            }
        }
    }
}
