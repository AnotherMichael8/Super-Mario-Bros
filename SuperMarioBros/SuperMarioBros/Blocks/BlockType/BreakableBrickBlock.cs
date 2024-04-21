using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Camera;
using SuperMarioBros.Collision;

namespace SuperMarioBros.Blocks.BlockType
{
    public class BreakableBrickBlock : AbstractBlock
    {
        protected int bumpCounter;
        protected ICollectibles collectible;
        public BreakableBrickBlock(Vector2 position, ICollectibles collectible) : base(position)
        {
            sourceRectangle = new Rectangle(17, 16, 16, 16);
            sprite = BlockSpriteFactory.Instance.CreateBlockSprite();
            bumpCounter = -6;
            this.collectible = collectible;
        }
        public override void Update()
        {
            if (bumpCounter > -6)
            {
                Position = new Vector2(Position.X, Position.Y - (int)(bumpCounter * (Globals.BlockSize / 32)));
                bumpCounter--;
                Bumped = true;
            }
            else
                Bumped = false;
        }
        public override void Bump(PowerUps powerUp)
        {
            bumpCounter = 5;
            if (collectible == null)
            {
                if (!powerUp.Equals(PowerUps.NONE))
                    BreakBlock();
            }
            else
            {
                SpawnCollectible(collectible);
            }
        }
        private void BreakBlock()
        {
            Blocks.Remove(this);
            CollisionManager.GameObjectList.Remove(this);
            CameraController.UpdateObjectQueue.Add(new Tuple<IGameObject, IGameObject>(this, null));
            Blocks.Add(new BrickDebris(Position));
            SoundFactory.PlaySound(SoundFactory.Instance.breakBlock);
        }

    }
}
