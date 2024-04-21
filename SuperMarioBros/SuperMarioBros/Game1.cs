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
using SuperMarioBros.Enemies.Koopa;
using SuperMarioBros.Levels;
using SuperMarioBros.Collectibles;
using SuperMarioBros.Camera;
using SuperMarioBros.Blocks.BlockType;
using System.Runtime.CompilerServices;
using SuperMarioBros.Events;

namespace SuperMarioBros
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public IPlayer MarioPlayer { get; set; }
        public IController Controller { get; set; }
        //public LevelGenerator levelGenerator { get; set; }
        public CollisionManager collisionManager;
        public IEnemy goomba { get; set; }
        private CameraController camera;

        Texture2D _texture;
        Texture2D texture2;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.BlockSize = 32;
            _graphics.PreferredBackBufferWidth = (int)(512 * Globals.BlockSize/32);
            _graphics.PreferredBackBufferHeight = (int)(480 * Globals.BlockSize/32);
            Globals.ScreenWidth = (int)(512 * Globals.BlockSize / 32);
            Globals.ScreenHeight = (int)(480 * Globals.BlockSize / 32);
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { new Color(Color.Red, 0.05f) });
            texture2 = new Texture2D(GraphicsDevice, 1, 1);
            texture2.SetData(new Color[] { new Color(Color.Blue, 0.3f) });

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            PlayerSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            CollectiblesSpriteFactory.Instance.LoadAllTextures(Content);
            SoundFactory.Instance.LoadAllTextures(Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MarioPlayer = new Player(this);
            collisionManager = new CollisionManager(this, _spriteBatch);
            //goomba = new Koopa(new Vector2(400, 384));
            Controller = new GameplayController(this);
            camera = new CameraController(MarioPlayer);
            camera.LoadObjectsOnScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MarioPlayer.Update();
            AbstractEnemy.UpdateAllEnemies();
            AbstractBlock.UpdateAllBlocks();
            AbstractCollectibles.UpdateAllSprites();
            Controller.Update(gameTime);
            collisionManager.Update();
            camera.Update();
            AbstractEvent.UpdateAllEvents();
            SoundFactory.Instance.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Color color = Color.CornflowerBlue;
            if(MarioPlayer.Position.Y < Globals.ScreenHeight * -3)
            {
                float yPos = MarioPlayer.Position.Y;
                int colorA = (int)(0.0293548387 * yPos + 142.27);
                int colorB = (int)(0.0451612903 * yPos + 214.03);
                int colorC = (int)(0.071612903 * yPos + 340.12);
                if(colorA < 9)
                    colorA = 9;
                if(colorB < 9)
                    colorB = 9;
                if(colorC < 15)
                    colorC = 15;
                color = new Color(colorA, colorB, colorC);
            }
            GraphicsDevice.Clear(color);
            _spriteBatch.Begin(SpriteSortMode.BackToFront);

            MarioPlayer.Draw(_spriteBatch, null);
            AbstractEnemy.DrawAllEnemies(_spriteBatch);
            AbstractBlock.DrawAllBlocks(_spriteBatch,Color.White);
            AbstractCollectibles.DrawAllSprites(_spriteBatch,Color.White);
            //DrawCollisionBox();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public void DrawCollisionBox()
        {
            foreach (IGameObject obj in CollisionManager.GameObjectList)
            {
                Rectangle objHitBox = obj.GetHitBox();
                objHitBox.X -= CameraController.CameraPositionX;
                objHitBox.Y += CameraController.CameraPositionY;
                _spriteBatch.Draw(_texture, objHitBox, Color.White);
                if (obj is Pipe pipe && pipe.connectedPipe != null)
                {
                    objHitBox = pipe.GetEnterPipeHitBox();
                    objHitBox.X -= CameraController.CameraPositionX;
                    objHitBox.Y += CameraController.CameraPositionY;
                    _spriteBatch.Draw(texture2, objHitBox, Color.White);
                }
            }
            Rectangle playerHitBox = MarioPlayer.GetHitBox();
            playerHitBox.X -= CameraController.CameraPositionX;
            playerHitBox.Y += CameraController.CameraPositionY;
            _spriteBatch.Draw(_texture, playerHitBox, Color.White);
            Rectangle[] warnPlayerRectangles = { new Rectangle(playerHitBox.X, playerHitBox.Y - 9 * (int)(Globals.BlockSize / 32), playerHitBox.Width, (int)(9 * Globals.BlockSize / 32)), new Rectangle(playerHitBox.X, playerHitBox.Bottom, playerHitBox.Width, (int)(9 * Globals.BlockSize / 32)), new Rectangle((int)(playerHitBox.X - 9 * (Globals.BlockSize / 32)), playerHitBox.Y, (int)(9 * (Globals.BlockSize / 32)), playerHitBox.Height), new Rectangle(playerHitBox.Right, playerHitBox.Y, (int)(9 * (Globals.BlockSize / 32)), playerHitBox.Height) };
            foreach (Rectangle rectangle in warnPlayerRectangles)
            {
                _spriteBatch.Draw(texture2, rectangle, Color.White);
            }
        }
    }
}