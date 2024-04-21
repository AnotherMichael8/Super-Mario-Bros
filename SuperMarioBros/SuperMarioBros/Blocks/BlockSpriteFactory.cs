using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockSprites;
using SuperMarioBros.Blocks.BlockType;
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
        private static Texture2D debrisTexture;
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
            debrisTexture = content.Load<Texture2D>("blocks");
        }

        public BlockSprite CreateBlockSprite()
        {
            return new BlockSprite(blockTexture);
        }
        public IPipeSprite CreateVerticalPipeSprite()
        {
            return new VerticalPipeSprite(blockTexture);
        }
        public IPipeSprite CreateHorizontalPipeSprite()
        {
            return new HorizontalPipeSprite(blockTexture);
        }
        public DebrisSprite CreateDebrisSprite(SpriteEffects spriteEffect)
        {
            return new DebrisSprite(debrisTexture, spriteEffect);
        }
        public FlagPoleSprite CreateFlagPoleSprite()
        {
            return new FlagPoleSprite(blockTexture);
        }
        public GroundBlockSprite CreateGroundBlockSprite()
        {
            return new GroundBlockSprite(blockTexture);
        }
        public AsteroidBlockSprite CreateAsteroidSprite()
        {
            return new AsteroidBlockSprite(blockTexture);
        }
        public PassThroughFloorBlockSprite CreatePassThroughFloorBlockSprite()
        {
            return new PassThroughFloorBlockSprite(blockTexture);
        }
        public SpacePipeSprite CreateSpacePipeSprite()
        {
            return new SpacePipeSprite(blockTexture);
        }
    }
}
