using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Collision;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Blocks;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Collectibles.Collectibles;

namespace SuperMarioBros.Levels
{
    public class LevelGenerator
    {
        private List<string[]> CSVLines = new List<string[]>();
        public LevelGenerator()
        {
            //blocks = new List<IBlock>();
        }
        public void CreateAllFiles(int numBlocks)
        {
            for (int i = 0; i < numBlocks; i++)
            {
                string fileName = Directory.GetCurrentDirectory();
                fileName = fileName.Substring(0, fileName.Length - 16) + "Levels/LevelCSV/1-1." + (i + 1) + ".csv";
                CSVLines.Add(File.ReadAllLines(fileName));
            }
        }
        public void LoadFile(int levelChunk)
        {
            foreach (string gameObject in CSVLines[levelChunk - 1])
            {
                string[] objDetails = gameObject.Split(",");
                if (objDetails[0].Equals("Block"))
                {
                    CreateBlockObject(objDetails);
                }
            }
        }
        public void CreateBlockObject(string[] blockDetails)
        {
            Vector2 position = new Vector2((int)(int.Parse(blockDetails[2]) * Globals.BlockSize),  (int)(int.Parse(blockDetails[3]) * Globals.BlockSize));
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
            AbstractBlock.Blocks.Add(block);
            CollisionManager.GameObjectList.Add(block);

        }
        public ICollectibles CreateCollectibleObject(string collectible, Vector2 position)
        {
            if(collectible.Equals("POWERUP"))
            {
                return new Mushroom(position);
            }
            else if(collectible.Equals("COIN"))
            {
                return new Coin(new Vector2(position.X + (int)(4 * Globals.ScreenSizeMulti), (int)(position.Y - Globals.BlockSize)));
            }
            else
            {
                return null;
            }
        }
        public void CreateFloor()
        {
            IBlock groundBlock = new GroundBlock(new Vector2(0, (int)(480 * (Globals.BlockSize/32) - 64 * (Globals.BlockSize/32))), 16, 2);
            ICollectibles mushroom = new Coin(new Vector2(64, Globals.ScreenHeight - (int)(3 * Globals.BlockSize)));
            AbstractBlock.Blocks.Add(groundBlock);
            AbstractCollectibles.Collectibles.Add(mushroom);
            CollisionManager.GameObjectList.Add(mushroom);
            CollisionManager.GameObjectList.Add(groundBlock);
        }
    }
}
