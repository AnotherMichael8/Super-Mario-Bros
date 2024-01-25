using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Blocks;
using SuperMarioBros.Controllers;
using SuperMarioBros.PlayerCharacter;
using SuperMarioBros.PlayerCharacter.PlayerStates;
using System.Linq.Expressions;
using SuperMarioBros.Collision;
using SuperMarioBros.Enemies;
using SuperMarioBros.Enemies.Goomba;

namespace SuperMarioBros
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public IPlayer MarioPlayer { get; set; }
        public IController Controller { get; set; }
        public LevelGenerator levelGenerator { get; set; }
        public CollisionManager collisionManager;
        public IEnemy goomba { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MarioPlayer = new Player(this);
            collisionManager = new CollisionManager(this);
            goomba = new Goomba(new Vector2(200, 384));
            Controller = new GameplayController(this);
            levelGenerator = new LevelGenerator();
            levelGenerator.CreateFloor();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MarioPlayer.Update();
            goomba.Update();
            Controller.Update(gameTime);
            collisionManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.BackToFront);

            MarioPlayer.Draw(_spriteBatch, Color.White);
            goomba.Draw(_spriteBatch);
            levelGenerator.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}