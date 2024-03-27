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
        protected Texture2D texture;
        protected static int updatePowerUpSprite;
        protected static int heightMultiplier;
        protected Rectangle destinationRectangle;
        protected PowerUps powerUp;
        protected int animationCounter;
        public Rectangle sourceRectangle { get; protected set; }
        protected readonly Color[] MarioColors = { new Color(181, 49, 32), new Color(234, 158, 34), new Color(107, 109, 0)};
        protected readonly Color[] FlowerColors = { new Color(247, 216, 165), new Color(234, 158, 34), new Color(181, 49, 32) };
        protected readonly Color[][] FlowerAnimColors = 
        {
            new Color[] { new Color(12, 147, 0), new Color(255, 254, 255), new Color(234, 158, 34) },
            new Color[] { new Color(181, 49, 32), new Color(255, 254, 255), new Color(234, 158, 34) },
            new Color[] { Color.Black, new Color(254, 204, 197), new Color(153, 78, 0) }
        };
        private static Dictionary<Color[], Color[]> savedColorChangeData = new Dictionary<Color[], Color[]>();
        public AbstractPlayerSprite(Texture2D texture, PowerUps powerUp = PowerUps.NONE)
        {
            this.texture = texture;
            animationCounter = 0;
            this.powerUp = powerUp;
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

        public virtual void Update(int currentSpeed)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color[] color)
        {
            if(color != null)
            {
                UpdatePlayersColor(color);
            }
        }
        protected void UpdatePlayersColor(Color[] newColors)
        {
            PlayerSpriteFactory.Instance.RevertTextureData();
            Color[] data = new Color[texture.Width * texture.Height];
            /*
            if (savedColorChangeData.ContainsKey(newColors))
            {
                data = savedColorChangeData[newColors];
            }
            else
            {
             */
                texture.GetData(data);
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Equals(MarioColors[0]) || data[i].Equals(FlowerColors[0]))
                    {
                        data[i] = newColors[0];
                    }
                    else if (data[i].Equals(MarioColors[1]) || data[i].Equals(FlowerColors[1]))
                    {
                        data[i] = newColors[1];
                    }
                    else if (data[i].Equals(MarioColors[2]) || data[i].Equals(FlowerColors[2]))
                    {
                        data[i] = newColors[2];
                    }
                }
                /*
                savedColorChangeData.Add(newColors, data);
            }
                */
            texture.SetData(data);
        }
    }
}
