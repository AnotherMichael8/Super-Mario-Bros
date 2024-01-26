using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Enemies.Goomba.GoombaSprites;
using SuperMarioBros.Enemies.Koopa.KoopaSprites;
using SuperMarioBros.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Enemies
{
    public class EnemySpriteFactory
    {
        private static Texture2D enemyTexture;
        private static EnemySpriteFactory instance = new EnemySpriteFactory();
        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory() { }
        public void LoadAllTextures(ContentManager content)
        {
            enemyTexture = content.Load<Texture2D>("Enemies");
        }
        public IEnemySprite CreateMovingGoombaEnemySprite()
        {
            return new GoombaMovingSprite(enemyTexture);
        }
        public IEnemySprite CreateDeathGoombaEnemySprite()
        {
            return new GoombaDeathSprite(enemyTexture);
        }
        public IEnemySprite CreateMovingKoopaEnemySprite()
        {
            return new KoopaMovingSprite(enemyTexture);
        }
        public IEnemySprite CreateInShellKoopaEnemySprite()
        {
            return new KoopaInShellSprite(enemyTexture);
        }
    }
}
