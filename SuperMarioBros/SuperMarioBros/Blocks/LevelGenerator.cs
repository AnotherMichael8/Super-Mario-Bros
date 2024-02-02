using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockType;
using SuperMarioBros.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class LevelGenerator
    {
        private List<IBlock> blocks;
        public LevelGenerator()
        {
            blocks = new List<IBlock>();
        }
        public void CreateFloor()
        {
            IBlock groundBlock = new GroundBlock(new Vector2(0, 416), 25, 2);
            blocks.Add(groundBlock);
            CollisionManager.GameObjectList.Add(groundBlock);
            for (int i = 0; i < 10; i++)
            {
                IBlock block = new DiamondBlock(new Vector2(224, 288 - 32*i));
                blocks.Add(block);
                CollisionManager.GameObjectList.Add(block);
            }
        }
        public void Update()
        {
            foreach (IBlock block in blocks)
            {
                block.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IBlock block in blocks)
            {
                block.Draw(spriteBatch, Color.White);
            }
        }
    }
}
