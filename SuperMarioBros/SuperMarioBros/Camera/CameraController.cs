using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.PlayerCharacter;
using SuperMarioBros.Levels;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Camera
{
    public class CameraController
    {
        private IPlayer player;
        public static int CameraPosition { get; private set; } = 0;
        private int currentChunck;
        private HashSet<int> chuncksLoaded;
        private LevelGenerator levelGenerator;
        private const int NUMBER_CHUNKS = 13;
        public static List<Tuple<IGameObject, IGameObject>> UpdateObjectQueue;
        public CameraController(IPlayer player)
        {
            this.player = player;
            chuncksLoaded = new HashSet<int>();
            levelGenerator = new LevelGenerator();
            UpdateObjectQueue = new List<Tuple<IGameObject, IGameObject>>();
        }
        public void Update()
        {
            int tempChunck = currentChunck;
            if(player.Position.X - CameraPosition > Globals.ScreenWidth / 2)
            {
                CameraPosition += (int)(player.Position.X - CameraPosition - Globals.ScreenWidth/2);
            }
            currentChunck = (int)(player.Position.X / Globals.ScreenWidth);
            if (tempChunck != currentChunck)
                LoadAndUnloadChunks(currentChunck);
            if(UpdateObjectQueue.Count > 0)
            {
                levelGenerator.ReplaceObject(UpdateObjectQueue[0].Item1, UpdateObjectQueue[0].Item2);
                UpdateObjectQueue.Remove(UpdateObjectQueue[0]);
            }
        }
        public void LoadObjectsOnScreen()
        {
            levelGenerator.CreateAllFiles(NUMBER_CHUNKS);
            levelGenerator.LoadFile(0);
            chuncksLoaded.Add(0);
            levelGenerator.LoadFile(1);
            chuncksLoaded.Add(1);
        }   
        private void LoadAndUnloadChunks(int currentChunk)
        {
            if (chuncksLoaded.Contains(currentChunk))
            {
                if (!chuncksLoaded.Contains(currentChunck + 1) && currentChunck + 1 < NUMBER_CHUNKS)
                {
                    levelGenerator.LoadFile(currentChunck + 1);
                    chuncksLoaded.Add(currentChunck + 1);
                }
                if (chuncksLoaded.Contains(currentChunck - 2) && currentChunk - 2 >= 0)
                {
                    levelGenerator.UnloadFile(currentChunk - 2);
                    chuncksLoaded.Remove(currentChunck - 2);
                }
            }
            else
                ResetChunks(currentChunk);
        }
        private void ResetChunks(int currentChunk)
        {
            foreach(int chunk in chuncksLoaded) 
            {
                levelGenerator.UnloadFile(chunk);
            }
            chuncksLoaded = new HashSet<int>();
            for(int i = currentChunk - 1; i <= currentChunk + 1; i++)
            {
                levelGenerator.LoadFile(i);
                chuncksLoaded.Add(i);
            }
        }
        public static bool CheckInFrame(Rectangle position)
        {
            return !(position.Right < CameraPosition || position.Left > CameraPosition + Globals.ScreenWidth);
        }
    }
}
