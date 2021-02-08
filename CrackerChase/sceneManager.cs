using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class sceneManager
    {
        //methods:
        //constructor
        public sceneManager()
        {
            //init the scenes
            mScenes = new List<gameScene>();
            mCurrentScene = 0;//by default we start in scene zero
        }


        //manages interaction of scenes (changing, adding, removing etc):
        public void addScene()//should take in a scene to add to the list
        {
            //todo implement creation of a scene
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
        public void update()
        {
            mScenes[mCurrentScene].update();
        }
        public void draw()
        {
            mScenes[mCurrentScene].draw();
        }


        //members:
        private List<gameScene> mScenes;
        private int mCurrentScene;//the index of the game scene list that is the currently selected scene
    }
}
