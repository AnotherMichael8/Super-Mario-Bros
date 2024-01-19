using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class LevelGenerator
    {
        private List<GroundBlock> blocks;
        public LevelGenerator()
        {
            blocks = new List<GroundBlock>();
        }
        public void CreateFloor()
        {
            for (int x = 0; x < 800; x += 32)
            {
                blocks.Add(new GroundBlock(new Vector2(x, 448)));
                blocks.Add(new GroundBlock(new Vector2(x, 416)));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GroundBlock block in blocks)
            {
                block.Draw(spriteBatch, Color.White);
            }
        }
    }
}
