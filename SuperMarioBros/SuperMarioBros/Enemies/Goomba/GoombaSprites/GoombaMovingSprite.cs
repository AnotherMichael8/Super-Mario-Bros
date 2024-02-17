using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Camera;

namespace SuperMarioBros.Enemies.Goomba.GoombaSprites
{
    public class GoombaMovingSprite : IEnemySprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private readonly Rectangle[] spriteAnimation = { new Rectangle(0, 16, 16, 16), new Rectangle(18, 16, 16, 16)};
        private int frameCounter;
        public GoombaMovingSprite(Texture2D texture)
        {
            this.texture = texture;
            frameCounter = 0;
            sourceRectangle = spriteAnimation[0];
        }

        public void Update()
        {
            if(frameCounter == 10)
            {
                sourceRectangle = spriteAnimation[1];
            }
            else if(frameCounter == 20) 
            {
                sourceRectangle = spriteAnimation[0];
                frameCounter = 0;
            }
            frameCounter++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X - CameraController.CameraPosition, (int)position.Y, sourceRectangle.Width * 2, sourceRectangle.Height * 2);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0), SpriteEffects.None, 0.1f);
        }
    }
}
