using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.PortableExecutable;
using SuperMarioBros.Collision;

namespace SuperMarioBros.PlayerCharacter.PowerUpAbilites
{
    public class Fireball : IPowerUpAbility
    {
        private double positionX;
        private double positionY;
        private Vector2 position;
        private int verticalMovementFactor;
        private int horizonatalMovementFactor;
        private int horizontalMovementFactor;
        private IPowerAbilitySprite sprite;
        private bool updateHorizontal;
        private const int FallSpeed = 10;
        private int startVerticalMovement = 71;
        public int chunk { get; private set; }

        public Fireball(Player player) 
        { 
            positionX = player.Position.X + Globals.BlockSize;
            positionY = player.Position.Y + 9 * 2 * Globals.ScreenSizeMulti;
            verticalMovementFactor = -48;
            sprite = PlayerSpriteFactory.Instance.CreateFireballSprite();

        }
        public void Bounce()
        {
            verticalMovementFactor = startVerticalMovement;
            startVerticalMovement -= 2;
        }
        public void Explode()
        {
            Player.Abilities.Remove(this);
            CollisionManager.GameObjectList.Remove(this);
        }
        public void Update()
        {
            positionY -= verticalMovementFactor * 2 / 16.0;
            positionX += (896 / ((double)startVerticalMovement / FallSpeed)) / 16.0;
            if(verticalMovementFactor > -48)
                verticalMovementFactor -= 8;
            sprite.Update();
            position.X = (int)positionX;
            position.Y = (int)positionY;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

        public Rectangle GetHitBox()
        {
            return new Rectangle((int)positionX, (int)positionY, (int)(16 * Globals.ScreenSizeMulti), (int)(16 * Globals.ScreenSizeMulti));
        }
    }
}
