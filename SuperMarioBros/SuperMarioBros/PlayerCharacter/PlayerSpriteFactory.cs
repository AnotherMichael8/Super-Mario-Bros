using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PlayerCharacter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PlayerCharacter
{
    public class PlayerSpriteFactory
    {
        private static Texture2D playerTexture;
        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();
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
            playerTexture = content.Load<Texture2D>("LinkPlayerSpriteSheetFinal");
        }

        public IPlayerSprite CreateLeftMovingPlayerSprite()
        {
            return new LeftMovingPlayerSprite(playerTexture);
        }
        public IPlayerSprite CreateRightMovingPlayerSprite()
        {
            return new RightMovingPlayerSprite(playerTexture);
        }
        public IPlayerSprite CreateRightJumpingPlayerSprite()
        {
            return new RightJumpingPlayerSprite(playerTexture);
        }
        public IPlayerSprite CreateLeftJumpingPlayerSprite()
        {
            return new LeftJumpingPlayerSprite(playerTexture);
        }
        public IPlayerSprite CreateLeftCrouchingPlayerSprite()
        {
            return new LeftCrouchingPlayerSprite(playerTexture);
        }
        public IPlayerSprite CreateRightCrouchingPlayerSprite()
        {
            return new RightCrouchingPlayerSprite(playerTexture);
        }
    }
}
