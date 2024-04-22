using SuperMarioBros.Camera;
using SuperMarioBros.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies.Goomba.GoombaStates
{
    public class FallingGoombaDeathState: IEnemyState
    {
        private Goomba goomba;
        private int deathCounter;
        private int movementX;
        private int movementY;

        public FallingGoombaDeathState(Goomba goomba)
        {
            this.goomba = goomba;
            goomba.Sprite = EnemySpriteFactory.Instance.CreateFallingDeathGoombaEnemySprite();
            deathCounter = 0;
            movementX = 1;
            movementY = -150;
        }
        public void FallingKill() { }
        public void Kill()
        {
        }
        public void MoveLeft()
        {
            movementX = -1;
        }

        public void MoveRight()
        {
            movementX = 1;
        }

        public void Update()
        {
            goomba.truePositionX += movementX;
            movementY += 5;
            goomba.truePositionY += movementY / 16.0;
            goomba.Position = new Vector2((int)goomba.truePositionX, (int)goomba.truePositionY);
            if (goomba.Position.Y >= Globals.ScreenHeight + Globals.BlockSize || deathCounter >= 60)
            {
                AbstractEnemy.Enemies.Remove(goomba);
                CollisionManager.GameObjectList.Remove(goomba);
                CameraController.UpdateObjectQueue.Add(new Tuple<IGameObject, IGameObject>(goomba, null));
            }
            deathCounter++;

        }
    }
}
