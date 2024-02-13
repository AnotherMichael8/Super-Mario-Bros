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
            IBlock block;
            if (blockDetails[1].Equals("QuestionBlock"))
            {
                block = new QuestionBlock(position);
            }
            else if (blockDetails[1].Equals("BreakableBrickBlock"))
            {
                block = new BreakableBrickBlock(position);
            }
            else
            {
                block = new UsedBlock(position);
            }
            AbstractBlock.Blocks.Add(block);
            CollisionManager.GameObjectList.Add(block);

        }
        public void CreateFloor()
        {
            IBlock groundBlock = new GroundBlock(new Vector2(0, (int)(480 * (Globals.BlockSize/32) - 64 * (Globals.BlockSize/32))), 16, 2);
            ICollectibles mushroom = new Flower(new Vector2(0, Globals.ScreenHeight - (int)(3 * Globals.BlockSize)));
            AbstractBlock.Blocks.Add(groundBlock);
            AbstractCollectibles.Collectibles.Add(mushroom);
            CollisionManager.GameObjectList.Add(mushroom);
            CollisionManager.GameObjectList.Add(groundBlock);
            /*
            for (int i = 0; i < 1; i++)
            {
                IBlock block2 = new DiamondBlock(new Vector2(192, 288 - Globals.BlockSize * i));
                IBlock block3 = new QuestionBlock(new Vector2(256, 288 - Globals.BlockSize * i));
                IBlock block = new QuestionBlock(new Vector2(224, 288 - Globals.BlockSize*i));
                AbstractBlock.Blocks.Add(block);
                AbstractBlock.Blocks.Add(block2);
                AbstractBlock.Blocks.Add(block3);
                CollisionManager.GameObjectList.Add(block);
                CollisionManager.GameObjectList.Add(block2);
                CollisionManager.GameObjectList.Add(block3);
            }
            */
        }
    }
}
