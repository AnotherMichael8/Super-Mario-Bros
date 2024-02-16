﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class BlockSpriteFactory
    {
        private static Texture2D blockTexture;
        private static BlockSpriteFactory instance = new BlockSpriteFactory();
        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory() { }
        public void LoadAllTextures(ContentManager content)
        {
            blockTexture = content.Load<Texture2D>("AllBlocks");
        }

        public BlockSprite CreateBlockSprite()
        {
            return new BlockSprite(blockTexture);
        }
        public PipeSprite CreatePipeSprite()
        {
            return new PipeSprite(blockTexture);
        }
    }
}
