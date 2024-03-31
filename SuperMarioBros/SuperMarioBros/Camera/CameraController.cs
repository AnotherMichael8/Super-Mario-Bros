﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMarioBros.PlayerCharacter;
using SuperMarioBros.Levels;
using SuperMarioBros.Collectibles.Collectibles;

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
        private bool wonderingInProcess;
        private int counter;
        public CameraController(IPlayer player)
        {
            this.player = player;
            chuncksLoaded = new HashSet<int>();
            levelGenerator = new LevelGenerator();
            UpdateObjectQueue = new List<Tuple<IGameObject, IGameObject>>();
            wonderingInProcess = false;
            counter = 0;
        }
        public void Update()
        {
            int previousChunk = currentChunck;
            if (!wonderingInProcess)
            {
                if (player.Position.X - CameraPosition > Globals.ScreenWidth / 2)
                {
                    CameraPosition += (int)(player.Position.X - CameraPosition - Globals.ScreenWidth / 2);
                }
                else if (player.Position.X - CameraPosition < Globals.ScreenWidth / 3 && CameraPosition > 0)
                {
                    CameraPosition += (int)(player.Position.X - CameraPosition - Globals.ScreenWidth / 3);
                    if (CameraPosition < 0)
                        CameraPosition = 0;
                }
            }
            else
            {
                if(counter == 175)
                {
                    levelGenerator.CreateWonderEventFile();
                    wonderingInProcess = false;
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
                UpdateObjectQueue.Remove(UpdateObjectQueue[0]);
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
            return !(position.Right < CameraPosition || position.Left > CameraPosition + Globals.ScreenWidth);
        }
        public void BeginWonderEvent(WonderFlower flower)
        {
            wonderingInProcess = true;
            Rectangle hitBox = flower.GetBlockHitBox();
            CameraPosition = hitBox.X + hitBox.Width/2 - Globals.ScreenWidth/2;
        }
    }
}
