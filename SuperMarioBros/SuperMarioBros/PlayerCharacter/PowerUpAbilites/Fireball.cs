using SuperMarioBros.PlayerCharacter.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collision;
using SuperMarioBros.Camera;

namespace SuperMarioBros.PlayerCharacter.PowerUpAbilites
{
    public class Fireball : IPowerUpAbility
    {
        private double positionX;
        private double positionY;
        private Vector2 position;
        private int verticalMovementFactor;
        private IPowerAbilitySprite sprite;
        private bool updateHorizontal;
        private const int FallSpeed = 10;
        private int startVerticalMovement = 71;
        private int direction;
        public int chunk { get; private set; }
        private static int numFireballs = 0;

        public Fireball(Player player, int direction) 
        {
            if (numFireballs < 2)
            {
                if (direction == -1)
                    positionX = player.Position.X - Globals.BlockSize / 2;
                else
                    positionX = player.Position.X + Globals.BlockSize;
                positionY = player.Position.Y + 9 * 2 * Globals.ScreenSizeMulti;
                verticalMovementFactor = -54;
                sprite = PlayerSpriteFactory.Instance.CreateFireballSprite();
                this.direction = direction;
                Player.Abilities.Add(this);
                CollisionManager.GameObjectList.Add(this);
                numFireballs++;
            }
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
            numFireballs--;
        }
        public void Update()
        {
            positionY -= verticalMovementFactor * 2 / 16.0;
            positionX += (direction * (896 / ((double)startVerticalMovement / FallSpeed)) / 16.0);
            if(verticalMovementFactor > -54)
                verticalMovementFactor -= 8;
            sprite.Update();
            position.X = (int)positionX;
            position.Y = (int)positionY;
            if (!CameraController.CheckInFrame(GetHitBox()))
                Explode();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)positionX, (int)positionY, (int)(16 * Globals.ScreenSizeMulti), (int)(16 * Globals.ScreenSizeMulti));
        }
        public Rectangle GetBlockHitBox()
        {
            return GetHitBox();
        }
    }
}
