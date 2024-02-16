﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Collision;
using SuperMarioBros.Collectibles.Collectibles;

namespace SuperMarioBros.Blocks.BlockType
{
    public class QuestionBlock : AbstractBlock
    {
        private Rectangle[] spriteAnimation = { new Rectangle(298, 78, 16, 16), new Rectangle(315, 78, 16, 16), new Rectangle(332, 78, 16, 16) };
        private int animateCounter;
        private int bumpCounter;
        private ICollectibles collectible;
        public QuestionBlock(Vector2 position, ICollectibles collectible) : base(position)
        {
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            sourceRectangle = spriteAnimation[0];
            animateCounter = 0;
            bumpCounter = -6;
            this.collectible = collectible;
        }
        public override void Update() 
        {
            if (animateCounter > 48)
            {
                sourceRectangle = spriteAnimation[0];
                animateCounter = 0;
            }
            else if (animateCounter > 38)
                sourceRectangle = spriteAnimation[1];
            else if (animateCounter > 30)
                sourceRectangle = spriteAnimation[2];
            else if (animateCounter > 20)
                sourceRectangle = spriteAnimation[1];
            animateCounter++;
            if(bumpCounter > -6)
            {
                Position = new Vector2(Position.X, Position.Y - (int)(bumpCounter * (Globals.BlockSize / 32)));
                bumpCounter--;
            }
        }
        public override void Bump()
        {
            Blocks.Remove(this);
            CollisionManager.GameObjectList.Remove(this);
            IBlock usedBlock = new UsedBlock(Position, collectible);
            Blocks.Add(usedBlock);
            CollisionManager.GameObjectList.Add(usedBlock);
            usedBlock.Bump();
            if (collectible is Coin)
            {
                AbstractCollectibles.Collectibles.Add(collectible);
                CollisionManager.GameObjectList.Add(collectible);
            }

        }
    }
}
