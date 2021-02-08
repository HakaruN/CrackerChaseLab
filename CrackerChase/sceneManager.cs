using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class SceneManager
    {
        //methods:
        //constructor
        public SceneManager()
        {
            //init the scenes
            mScenes = new List<gameScene>();
            mCurrentScene = 0;//by default we start in scene zero
        }


        //manages interaction of scenes (changing, adding, removing etc):
        public int addScene(gameScene scene)//should take in a scene to add to the list, returns the id of the new scene
        {
            mScenes.Add(scene);
            return mScenes.Count - 1;
        }
        public int getCurrentSceneID()//returns the index of the scene
        {
            return mCurrentScene;
        }

        public gameScene getCurrentScene()
        {
            return mScenes[mCurrentScene];
        }

        public gameScene getSceneByID(int ID)
        {
            return mScenes[ID];
        }
        public void removeSceneByID(int ID)
        {
            mScenes.Remove(mScenes[ID]);
        }


        //manages updates, draws etc
        public void Update(GameTime gameTime)
        {
            mScenes[mCurrentScene].Update(gameTime);
        }
        public void Draw(GameTime gametime)
        {
            mScenes[mCurrentScene].Draw(gametime);
        }


        //members:
        private List<gameScene> mScenes;
        private int mCurrentScene;//the index of the game scene list that is the currently selected scene
    }
}
