using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collectibles.CollectiblesSprites;
using SuperMarioBros.PlayerCharacter.Interfaces;
using SuperMarioBros.PlayerCharacter.PlayerSprites;
using SuperMarioBros.PlayerCharacter.PlayerStates;
using SuperMarioBros.PlayerCharacter.PowerUpAbilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter
{
    public class PlayerSpriteFactory : PowerUp
    {
        private static Texture2D playerTexture;
        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();
        private PowerUps powerUp = PowerUps.NONE;
        private Color[] textureData;
        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerSpriteFactory() { }
        public void LoadAllTextures(ContentManager content)
        {
            playerTexture = content.Load<Texture2D>("TrueMarioCharacters");
            textureData = new Color[playerTexture.Width * playerTexture.Height];
            playerTexture.GetData(textureData);
        }
        public void UpdatePowerUp(PowerUps powerUp)
        {
            this.powerUp = powerUp;
        }
        public void RevertTextureData()
        {
            playerTexture.SetData(textureData);
        }
        public IPlayerSprite CreateNewPlayerSprite(IPlayerSprite playerSprite)
        {
            Type playerSpriteType = playerSprite.GetType();
            return (IPlayerSprite)Activator.CreateInstance(playerSpriteType, playerTexture, powerUp);
        }
        public IPlayerSprite CreateLeftIdlePlayerSprite()
        {
            return new LeftIdlePlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateRightIdlePlayerSprite()
        {
            return new RightIdlePlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateLeftMovingPlayerSprite()
        {
            return new LeftMovingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateRightMovingPlayerSprite()
        {
            return new RightMovingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateRightJumpingPlayerSprite()
        {
            return new RightJumpingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateLeftJumpingPlayerSprite()
        {
            return new LeftJumpingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateLeftCrouchingPlayerSprite()
        {
            return new LeftCrouchingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateRightCrouchingPlayerSprite()
        {
            return new RightCrouchingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateRightSlidingPlayerSprite()
        {
            return new RightSlidingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateLeftSlidingPlayerSprite()
        {
            return new LeftSlidingPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateDeathPlayerSprite()
        {
            return new DeathPlayerSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateRightAnimationMushroomSprite()
        {
            return new RightAnimationMushroomSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateLeftAnimationMushroomSprite()
        {
            return new LeftAnimationMushroomSprite(playerTexture, powerUp);
        }
        public IPlayerSprite CreateRightAnimationFlowerSprite(IPlayerSprite previousSprite)
        {
            return new RightAnimationFlowerSprite(playerTexture, powerUp, previousSprite);
        }
        public IPlayerSprite CreateLeftAnimationFlowerSprite(IPlayerSprite previousSprite)
        {
            return new LeftAnimationFlowerSprite(playerTexture, powerUp, previousSprite);
        }
        public IPlayerSprite CreateGrabPoleSprite()
        {
            return new GrabPolePlayerSprite(playerTexture, powerUp);
        }
        public IPowerAbilitySprite CreateFireballSprite()
        {
            return new FireballSprite(playerTexture);
        }
        public IPlayerSprite CreateWonderOrbSprite()
        {
            return new WonderOrbPlayerSprite(playerTexture, powerUp);
        }
    }
}
