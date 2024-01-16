using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;

namespace SuperMarioBros.PlayerCharacter
{
    public class Player : IPlayer
    {
        private Game1 game;
        private Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }
        public IPlayerSprite Sprite { get; set; }
        public IPlayerState State { get; set; }

        public Player(Game1 game)
        {
            this.game = game;
            this.position = new Vector2(0, 0);
            //State = 
        }

        public void BecomeIdle()
        {
            State.BecomeIdle();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
        }

        public void Sprint()
        {
            State.Sprint();
        }

        public void Jump()
        {
            State.Jump();
        }

        public void Crouch()
        {
            State.Crouch();
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
             
        }
    }
}
