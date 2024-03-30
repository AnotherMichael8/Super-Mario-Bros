using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Camera;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics.Metrics;

namespace SuperMarioBros.Collectibles.CollectiblesSprites
{
    public class WonderFlowerCollectionAnimationSprite : ICollectiblesSprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle = new Rectangle(5, 488, 36, 34);
        private int counter;
        public WonderFlowerCollectionAnimationSprite(Texture2D texture)
        {
            this.texture = texture;
            counter = 0;
        }
        public void Update()
        {
            counter++;
            if (counter >= 30)
                counter += 2;
            else if(counter >= 40)
                counter += 3;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition - 5 * counter, (int)position.Y - 5 * counter, (int)Globals.BlockSize + 10 * counter, (int)Globals.BlockSize + 10 * counter);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.3f);
        }
    }
}
