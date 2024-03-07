using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Collectibles.CollectiblesSprites
{
    public class OneUpSprite : ICollectiblesSprite
    {
        private Texture2D texture;
        private readonly Rectangle sourceRectangle = new Rectangle(0, 26, 16, 16);
        public OneUpSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, (int)Globals.BlockSize, (int)Globals.BlockSize);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0), SpriteEffects.None, 0.3f);
        }
    }
}
