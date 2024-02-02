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
            for (int x = 0; x < 800; x += 32)
            {
                blocks.Add(new UsedBlock(new Vector2(x, 448)));
                blocks.Add(new GroundBlock(new Vector2(x, 416)));
                CollisionManager.GameObjectList.Add(new GroundBlock(new Vector2(x, 448)));
                CollisionManager.GameObjectList.Add(new GroundBlock(new Vector2(x, 416)));
            }
            IBlock block = new QuestionBlock(new Vector2(224, 288));
            blocks.Add(block);
            CollisionManager.GameObjectList.Add(block);
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
