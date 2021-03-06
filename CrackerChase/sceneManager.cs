﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace CrackerChase
{
    //this struct is used to carry data across scene transitions
    public struct CrossSceneData
    {
        public CrossSceneData(int scoreInit = 0, int healthInit = 0)
        {
            score = scoreInit;
            health = healthInit;
        }
        public int score;
        public int health;
    }
    class SceneManager
    {
        //methods:
        //constructor
        public SceneManager()
        {
            //init the scenes
            mScenes = new List<GameScene>();
            mCurrentScene = 0;//by default we start in scene zero
            mCrossSceneData = new CrossSceneData();
        }


        //manages interaction of scenes (changing, adding, removing etc):
        public int addScene(GameScene scene)//should take in a scene to add to the list, returns the id of the new scene
        {
            mScenes.Add(scene);
            return mScenes.Count - 1;
        }
        public int getCurrentSceneID()//returns the index of the scene
        {
            return mCurrentScene;
        }

        public GameScene getCurrentScene()
        {
            return mScenes[mCurrentScene];
        }

        public GameScene getSceneByID(int ID)
        {
            return mScenes[ID];
        }
        public void removeSceneByID(int ID)
        {
            mScenes.Remove(mScenes[ID]);
        }
        public void selectNextScene(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight, ref CrossSceneData data)
        {
            mCurrentScene++;
            mScenes[mCurrentScene].onSwitchTo(deltaTime, keys, sceneManager, soundManager, inScreenWidth, inScreenHeight, ref data);
        }
        public void selectPrevScene()
        {
            mCurrentScene--;
        }
        public void selectSceneByID(int ID, float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight, ref CrossSceneData data)
        {
            mCurrentScene = ID;
            mScenes[mCurrentScene].onSwitchTo(deltaTime, keys, sceneManager, soundManager, inScreenWidth, inScreenHeight, ref data);
        }

        //manages updates, draws etc
        public void Update(float deltaTime, KeyboardState keys, SoundManager soundManager, int inScreenWidth, int inScreenHeight)
        {
            mScenes[mCurrentScene].update(deltaTime, keys, this, soundManager, inScreenWidth, inScreenHeight, ref mCrossSceneData);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mScenes[mCurrentScene].draw(spriteBatch);
        }


        //members:
        private List<GameScene> mScenes;
        private int mCurrentScene;//the index of the game scene list that is the currently selected scene
        private CrossSceneData mCrossSceneData;
    }
}
