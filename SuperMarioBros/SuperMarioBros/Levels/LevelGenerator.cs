using Microsoft.Xna.Framework;
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
using SuperMarioBros.Collision.SideCollisionHandlers;
using System.Linq;
using System.ComponentModel;

namespace SuperMarioBros.Levels
{
    public class LevelGenerator
    {
        private List<List<IGameObject>> ChunkObjects;
        private List<IGameObject> WonderBlocks;
        public LevelGenerator()
        {
            ChunkObjects = new List<List<IGameObject>>();
        }
        public void CreateAllFiles(int numBlocks)
        {
            for(int i = 0;  i < numBlocks; i++)
            {
                ChunkObjects.Add(new List<IGameObject>());
            }
            for (int i = 0; i < numBlocks; i++)
            {
                string fileName = Directory.GetCurrentDirectory();
                fileName = fileName.Substring(0, fileName.Length - 16) + "Levels/LevelCSV/1-1." + i + ".csv";
                string[] CSVLine = File.ReadAllLines(fileName);
                for(int c = 0; c < CSVLine.Length; c++)
                {
                    string gameObject = CSVLine[c];
                    string[] objDetails = gameObject.Split(",");
                    if (objDetails[0].Equals("Block"))
                    {
                        ChunkObjects[i].Add(CreateBlockObject(objDetails, i));
                    }
                    else if (objDetails[0].Equals("Enemy"))
                    {
                        ChunkObjects[i].Add(CreateEnemyObjects(objDetails, i));
                    }
                    else if (objDetails[0].Equals("Collectible"))
                    {
                        ChunkObjects[i].Add(CreateCollectibleObject(objDetails, i));
                    }
                }
            }
        }
        public void CreateWonderEventFile()
        {
            WonderBlocks = new List<IGameObject>();
            string fileName = Directory.GetCurrentDirectory();
            fileName = fileName.Substring(0, fileName.Length - 16) + "Levels/SpecialChunksCSV/1-1.Wonder.csv";
            string[] CSVLine = File.ReadAllLines(fileName);
            for (int c = 0; c < CSVLine.Length; c++)
            {
                string gameObject = CSVLine[c];
                string[] objDetails = gameObject.Split(",");
                if (objDetails[0].Equals("Block"))
                {
                    WonderBlocks.Add(CreateBlockObject(objDetails, int.Parse(objDetails[objDetails.Length - 2]), int.Parse(objDetails[objDetails.Length - 1])));
                }
                else if (objDetails[0].Equals("Enemy"))
                {
                    WonderBlocks.Add(CreateEnemyObjects(objDetails, int.Parse(objDetails[objDetails.Length - 2]), int.Parse(objDetails[objDetails.Length - 1])));
                }
                else if (objDetails[0].Equals("Collectible"))
                {
                    WonderBlocks.Add(CreateCollectibleObject(objDetails, int.Parse(objDetails[objDetails.Length - 2]), int.Parse(objDetails[objDetails.Length - 1])));
                }
            }
            LoadFile(WonderBlocks);
        }
        private void LoadFile(List<IGameObject> file)
        {
            foreach (IGameObject gameObject in file)
            {
                if (gameObject is IBlock block && gameObject is not GroundBlock)
                {
                    AbstractBlock.Blocks.Add(block);
                }
                if (gameObject is IEnemy enemy)
                {
                    AbstractEnemy.Enemies.Add(enemy);
                }
                if (gameObject != null && gameObject is not GroundBlock)
                    CollisionManager.GameObjectList.Add(gameObject);
            }
        }
        private void UnloadFile(List<IGameObject> file)
        {
            foreach (IGameObject gameObject in file)
            {
                if (gameObject is IBlock block)
                {
                    if (block is not GroundBlock)
                        AbstractBlock.Blocks.Remove(block);
                }
                if (gameObject != null && gameObject is not GroundBlock)
                    CollisionManager.GameObjectList.Remove(gameObject);
            }
        }
        public void LoadFileFromChunk(int levelChunk)
        {
            LoadFile(ChunkObjects[levelChunk]);
        }
        public void UnloadFileFromChunk(int levelChunk)
        {
            UnloadFile(ChunkObjects[levelChunk]);
        }
        private IBlock CreateBlockObject(string[] blockDetails, int levelChunk, int height = 0)
        {
            Vector2 position = new Vector2((int)(int.Parse(blockDetails[2]) * Globals.BlockSize + Globals.ScreenWidth * levelChunk),  (int)(int.Parse(blockDetails[3]) * Globals.BlockSize + height * Globals.ScreenHeight));
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
                ICollision enterableSide = new BottomCollision();
                if (blockDetails[5].Equals("TOP"))
                    enterableSide = new TopCollision();
                else if (blockDetails[5].Equals("LEFT"))
                    enterableSide = new LeftCollision();
                else if (blockDetails[5].Equals("RIGHT"))
                    enterableSide = new RightCollision();
                if(blockDetails.Length > 6)
                {
                    string[] temp = new string[6];
                    for(int i = 0; i < temp.Length; i++)
                        temp[i] = blockDetails[6 + i];
                    Pipe connectedPipe = (Pipe)CreateBlockObject(temp, int.Parse(temp[0]));
                    ChunkObjects[int.Parse(temp[0])].Add(connectedPipe);
                    block = new Pipe(position, int.Parse(blockDetails[4]), enterableSide, connectedPipe);
                }
                else
                    block = new Pipe(position, int.Parse(blockDetails[4]), enterableSide);
            }
            else if (blockDetails[1].Equals("GroundBlock"))
            {
                block = new GroundBlock(position, int.Parse(blockDetails[4]), int.Parse(blockDetails[5]));
                AbstractBlock.Blocks.Add(block);
                CollisionManager.GameObjectList.Add(block);
            }
            else if (blockDetails[1].Equals("DiamondBlock"))
            {
                block = new DiamondBlock(position, int.Parse(blockDetails[4]));
            }
            else if (blockDetails[1].Equals("FlagPole"))
            {
                block = new FlagPole(position);
            }
            else if (blockDetails[1].Equals("InvisibleBlock"))
            {
                block = new InvisibleBlock(position, CreateCollectibleObject(blockDetails[4], position));
            }
            else if (blockDetails[1].Equals("CoinBox"))
            {
                block = new CoinBox(position);
            }
            return block;
        }
        private ICollectibles CreateCollectibleObject(string[] blockDetails, int levelChunk, int height = 0)
        {
            Vector2 position = new Vector2((int)(double.Parse(blockDetails[2]) * Globals.BlockSize + Globals.ScreenWidth * levelChunk), (int)(double.Parse(blockDetails[3]) * Globals.BlockSize + height * Globals.ScreenHeight));
            ICollectibles collectible = null;
            if (blockDetails[1].Equals("WonderFlower"))
            {
                collectible = new WonderFlower(position);
            }
            return collectible;
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
                return new OneUp(position);
            }
            else if(collectible.Equals("STAR"))
            {
                return new Star(position);
            }
            else
            {
                return null;
            }
        }
        private IEnemy CreateEnemyObjects(string[] blockDetails, int levelChunk, int height = 0)
        {
            Vector2 position = new Vector2((int)(int.Parse(blockDetails[2]) * Globals.BlockSize + Globals.ScreenWidth * levelChunk), (int)(int.Parse(blockDetails[3]) * Globals.BlockSize + height * Globals.ScreenHeight));
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
                    for (int c = 0; c < ChunkObjects[i].Count; c++)
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
