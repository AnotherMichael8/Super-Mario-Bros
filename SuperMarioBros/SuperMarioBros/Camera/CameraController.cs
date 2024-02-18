using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.PlayerCharacter;
using SuperMarioBros.Levels;

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
        public CameraController(IPlayer player)
        {
            this.player = player;
            chuncksLoaded = new HashSet<int>();
            levelGenerator = new LevelGenerator();
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
        }
        public void LoadObjectsOnScreen()
        {
            levelGenerator.CreateAllFiles(NUMBER_CHUNKS);
            levelGenerator.LoadFile(0);
            levelGenerator.LoadFile(1);
        }   
        private void LoadAndUnloadChunks(int currentChunk)
        {
            if(currentChunck + 1 < NUMBER_CHUNKS)
            {
                levelGenerator.LoadFile(currentChunck + 1);
                chuncksLoaded.Add(currentChunck + 1);
            }
            if(currentChunk - 2 >= 0)
            {
                levelGenerator.UnloadFile(currentChunk - 2);
            }
        }
        public static bool CheckInFrame(Rectangle position)
        {
            return !(position.Right < CameraPosition || position.Left > CameraPosition + Globals.ScreenWidth);
        }

    }
}
