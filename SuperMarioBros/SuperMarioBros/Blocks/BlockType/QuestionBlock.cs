using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Collision;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.Camera;

namespace SuperMarioBros.Blocks.BlockType
{
    public class QuestionBlock : AbstractBlock
    {
        private Rectangle[] spriteAnimation = { new Rectangle(298, 78, 16, 16), new Rectangle(315, 78, 16, 16), new Rectangle(332, 78, 16, 16) };
        private static int animateCounter;
        private int bumpCounter;
        private ICollectibles collectible;
       // public IBlock usedBlock { get; private set; }
        private static Rectangle animateSourceRectangle;
        public QuestionBlock(Vector2 position, ICollectibles collectible) : base(position)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            animateSourceRectangle = spriteAnimation[0];
            animateCounter = 0;
            tempAnimateCounter = animateCounter;
            bumpCounter = -6;
            this.collectible = collectible;
            //usedBlock = new UsedBlock(Position, collectible);
        }
        public override void Update() 
        {
            if(tempAnimateCounter == animateCounter)
            {
                animateCounter++;
            }
            if (animateCounter > 48)
            {
                animateSourceRectangle = spriteAnimation[0];
                animateCounter = 0;
            }
            else if (animateCounter > 38)
                animateSourceRectangle = spriteAnimation[1];
            else if (animateCounter > 30)
                animateSourceRectangle = spriteAnimation[2];
            else if (animateCounter > 20)
                animateSourceRectangle = spriteAnimation[1];
            if(bumpCounter > -6)
            {
                Position = new Vector2(Position.X, Position.Y - (int)(bumpCounter * (Globals.BlockSize / 32)));
                bumpCounter--;
            }
        }
        public override void Bump(PowerUps powerUp)
        {
            SpawnCollectible(collectible);
            if(collectible is Coin)
                SoundFactory.PlaySound(SoundFactory.Instance.coin);
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, animateSourceRectangle, Position, color);
        }
        public static void UpdateAnimationCounter()
        {
            tempAnimateCounter = animateCounter;
        }
    }
}
