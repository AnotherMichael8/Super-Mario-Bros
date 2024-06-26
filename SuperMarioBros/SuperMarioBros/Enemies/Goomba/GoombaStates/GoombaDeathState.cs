﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Collision;
using SuperMarioBros.Camera;

namespace SuperMarioBros.Enemies.Goomba.GoombaStates
{
    public class GoombaDeathState : IEnemyState
    {
        private Goomba goomba;
        private int deathCounter;
        public GoombaDeathState(Goomba goomba)
        {
            this.goomba = goomba;
            goomba.Sprite = EnemySpriteFactory.Instance.CreateDeathGoombaEnemySprite();
            deathCounter = 0;
        }
        public void FallingKill()
        {
        }
        public void Kill()
        {
        }
        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }
        
        public void Update()
        {
            if(deathCounter == 30)
            {
                AbstractEnemy.Enemies.Remove(goomba);
                CollisionManager.GameObjectList.Remove(goomba);
                CameraController.UpdateObjectQueue.Add(new Tuple<IGameObject, IGameObject>(goomba, null));
            }
            deathCounter++;

        }
    }
}
