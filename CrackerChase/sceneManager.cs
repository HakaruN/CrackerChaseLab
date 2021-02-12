using System;
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
    class SceneManager
    {
        //methods:
        //constructor
        public SceneManager()
        {
            //init the scenes
            mScenes = new List<GameScene>();
            mCurrentScene = 0;//by default we start in scene zero
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
        public void selectNextScene()
        {
            mCurrentScene++;
        }
        public void selectPrevScene()
        {
            mCurrentScene--;
        }
        public void selectSceneByID(int ID)
        {
            mCurrentScene = ID;
        }

        //manages updates, draws etc
        public void Update(GameTime gameTime, KeyboardState keys, int inScreenWidth, int inScreenHeight)
        {
            mScenes[mCurrentScene].Update(gameTime, keys, this, inScreenWidth, inScreenHeight);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mScenes[mCurrentScene].Draw(spriteBatch);
        }


        //members:
        private List<GameScene> mScenes;
        private int mCurrentScene;//the index of the game scene list that is the currently selected scene
    }
}
