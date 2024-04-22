using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter;
using SuperMarioBros.Levels;
using SuperMarioBros.Collectibles.Collectibles;
using SuperMarioBros.Collectibles;

namespace SuperMarioBros.Camera
{
    public class CameraController
    {
        private IPlayer player;
        public static int CameraPositionX { get; private set; } = 0;
        public static int CameraPositionY { get; private set; } = 0;
        private int currentChunck;
        private HashSet<int> chuncksLoaded;
        private LevelGenerator levelGenerator;
        private const int NUMBER_CHUNKS = 13;
        public static List<Tuple<IGameObject, IGameObject>> UpdateObjectQueue;
        private bool wonderingInProcess;
        private bool wonderEvent;
        private bool stopVertical;
        private int counter;
        public CameraController(IPlayer player)
        {
            this.player = player;
            chuncksLoaded = new HashSet<int>();
            levelGenerator = new LevelGenerator();
            UpdateObjectQueue = new List<Tuple<IGameObject, IGameObject>>();
            wonderingInProcess = false;
            wonderEvent = false;
            stopVertical = false;
            counter = 0;
        }
        public void Update()
        {
            int previousChunk = currentChunck;
            if (!wonderingInProcess)
            {
                if (player.Position.X - CameraPositionX > Globals.ScreenWidth / 2)
                {
                    CameraPositionX += (int)(player.Position.X - CameraPositionX - Globals.ScreenWidth / 2);
                }
                else if (player.Position.X - CameraPositionX < Globals.ScreenWidth / 3 && CameraPositionX > 0)
                {
                    CameraPositionX += (int)(player.Position.X - CameraPositionX - Globals.ScreenWidth / 3);
                    if (CameraPositionX < 0)
                        CameraPositionX = 0;
                }
                if(wonderEvent && player.Position.Y + CameraPositionY < Globals.ScreenHeight / 2)
                {
                    CameraPositionY += (int)(Globals.ScreenHeight / 2 - player.Position.Y - CameraPositionY);
                }    
                else if (wonderEvent && player.Position.Y + CameraPositionY > Globals.ScreenHeight / 2 && CameraPositionY > 0)
                {
                    CameraPositionY += (int)(Globals.ScreenHeight / 2 - player.Position.Y - CameraPositionY);
                    if (CameraPositionY < 0)
                        CameraPositionY = 0;
                }
            }
            else
            {
                if(counter == 175)
                {
                    levelGenerator.CreateWonderEventFile();
                    wonderingInProcess = false;
                    wonderEvent = true;
                }
                counter++;
            }
            currentChunck = (int)(player.Position.X / Globals.ScreenWidth);
            LoadAndUnloadChunks(currentChunck, previousChunk);
            if(UpdateObjectQueue.Count > 0)
            {
                levelGenerator.ReplaceObject(UpdateObjectQueue[0].Item1, UpdateObjectQueue[0].Item2);
                if (UpdateObjectQueue[0].Item1 is WonderFlower flower && !wonderingInProcess)
                    BeginWonderEvent(flower);
                if (UpdateObjectQueue[0].Item1 is WonderSeed seed)
                    EndWonderEvent(seed);
                UpdateObjectQueue.Remove(UpdateObjectQueue[0]);
            }
            if(stopVertical && !player.IsFalling)
            {
                wonderEvent = false;
                stopVertical = false;
            }
        }
        public void LoadObjectsOnScreen()
        {
            levelGenerator.CreateAllFiles(NUMBER_CHUNKS);
            levelGenerator.LoadFileFromChunk(0);
            chuncksLoaded.Add(0);
            levelGenerator.LoadFileFromChunk(1);
            chuncksLoaded.Add(1);
        }   
        private void LoadAndUnloadChunks(int currentChunk, int previousChunk)
        {
            int direction = 0;
            bool endPoint = currentChunck + 1 < NUMBER_CHUNKS;
            bool startPoint = currentChunck - 2 >= 0;
            if (currentChunk > previousChunk)
                direction = 1;
            else if (currentChunk < previousChunk)
            {
                direction = -1;
                endPoint = currentChunck + 1 * direction >= 0;
                startPoint = currentChunck - 2 * direction < NUMBER_CHUNKS;
            }

            if (direction != 0 && chuncksLoaded.Contains(currentChunk))
            {
                //Fix last part of if statement
                if (!chuncksLoaded.Contains(currentChunck + 1 * direction) && endPoint)
                {
                    levelGenerator.LoadFileFromChunk(currentChunck + 1 * direction);
                    chuncksLoaded.Add(currentChunck + 1 * direction);
                }
                if (chuncksLoaded.Contains(currentChunck - 2 * direction) && startPoint)
                {
                    levelGenerator.UnloadFileFromChunk(currentChunk - 2 * direction);
                    chuncksLoaded.Remove(currentChunck - 2 * direction);
                }
            }
            else if (!chuncksLoaded.Contains(currentChunk))
                ResetChunks(currentChunk);
        }
        private void ResetChunks(int currentChunk)
        {
            foreach(int chunk in chuncksLoaded) 
            {
                levelGenerator.UnloadFileFromChunk(chunk);
            }
            chuncksLoaded = new HashSet<int>();
            for(int i = currentChunk - 1; i <= currentChunk + 1; i++)
            {
                levelGenerator.LoadFileFromChunk(i);
                chuncksLoaded.Add(i);
            }
        }
        public static bool CheckInFrame(Rectangle position)
        {
            return !(position.Right < CameraPositionX || position.Left > CameraPositionX + Globals.ScreenWidth);
        }
        public void BeginWonderEvent(WonderFlower flower)
        {
            wonderingInProcess = true;
            Rectangle hitBox = flower.GetBlockHitBox();
            CameraPositionX = hitBox.X + hitBox.Width/2 - Globals.ScreenWidth/2;
        }
        public void EndWonderEvent(WonderSeed seed)
        {
            Rectangle hitBox = seed.GetBlockHitBox();
            CameraPositionX = hitBox.X + hitBox.Width / 2 - Globals.ScreenWidth / 2;
            CameraPositionY = hitBox.Y + hitBox.Height / 2 - Globals.ScreenHeight / 2;
            levelGenerator.RemoveWonderEventFile();
            AbstractCollectibles.Collectibles.Remove(seed);
            SoundFactory.Instance.RestartSong();
            stopVertical = true;
        }
        public static void RepositionCamera(Rectangle hitBox)
        {
            CameraPositionX = hitBox.X + hitBox.Width / 2 - Globals.ScreenWidth / 2;
            CameraPositionY = hitBox.Y + hitBox.Height / 2 - Globals.ScreenHeight / 2;
        }
    }
}
