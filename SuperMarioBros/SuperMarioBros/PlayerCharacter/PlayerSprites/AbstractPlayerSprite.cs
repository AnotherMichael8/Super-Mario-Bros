using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using SuperMarioBros.Collectibles;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerStates; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter.PlayerSprites
{
    public abstract class AbstractPlayerSprite : PowerUp, IPlayerSprite
    {
        //private readonly Rectangle sourceRectangle = new Rectangle(0, 8, 16, 16);
        protected Texture2D texture;
        protected int frameCounter;
        protected int updatePowerUpSprite;
        protected int heightMultiplier;
        protected Rectangle destinationRectangle;
        public AbstractPlayerSprite(Texture2D texture, PowerUps powerUp = PowerUps.NONE)
        {
            this.texture = texture;
            frameCounter = 0;
            switch(powerUp)
            {
                case (PowerUps.MUSHROOM):
                    //Distance in pixels from small mario to big mario in spritesheet
                    updatePowerUpSprite = 24;
                    heightMultiplier = 2;
                    break;
                case (PowerUps.FIREFLOWER):
                    // Distance in pixels from small mario to flower mario in spritesheet
                    updatePowerUpSprite = 132;
                    heightMultiplier = 2;
                    break;
                default:
                    updatePowerUpSprite = 0;
                    heightMultiplier = 1;
                    break;
            }
        }

        public virtual void Update(int currentSpeed) { }

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, Color color);
    }
}
