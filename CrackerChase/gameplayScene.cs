using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class GameplayScene : GameScene
    {
        public GameplayScene(Player player, List<Enemy> enemies, List<Barricade> barricades)
        {
            mPlayer = player;
            mEnemies = enemies;
            mBarricades = barricades;
            gameScore = 0;
            numStepsPerRow = 450;
            numStepsSoFar = 0;
            walkDir = true;
        }


        public void update(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight)
        {
            //call update method on the player
            mPlayer.Update(deltaTime, keys, inScreenWidth, inScreenHeight, soundManager);


            //calc enemy movements
            if (numStepsSoFar >= numStepsPerRow)
            {
                numStepsSoFar = 0;//reset the number of steps
                walkDir = !walkDir;//reverse the direction of walking

                //move all enemies down a bit
                for(int i = 0; i < mEnemies.Count(); i++)
                    mEnemies[i].offsetPosition(0.00f, inScreenHeight * 10f * deltaTime);
            }
            else
                numStepsSoFar++;// increment the number of steps

            if(walkDir)
            {   //walk left
                for (int i = 0; i < mEnemies.Count(); i++)
                {
                    mEnemies[i].offsetPosition(100f * deltaTime, 0);
                }
            }
            else
            {   //walk right
                for (int i = 0; i < mEnemies.Count(); i++)
                {
                    mEnemies[i].offsetPosition(-100f * deltaTime, 0);
                }
            }

            //update enemies logic
            for (int i = 0; i < mEnemies.Count(); i++)
            {
                mEnemies[i].Update(1.0f / 60.0f);
                if (mPlayer.getBullet().IntersectsWith(mEnemies[i]))
                {
                    mEnemies[i].mIsDead = true;//destroy enemy
                    //mPlayer.isOnScreen = false;
                }
            }

            //update barricades
            for (int i = 0; i < mBarricades.Count; i++)
            {
                mBarricades[i].Update(deltaTime);
            }

            
        }

        public void draw(SpriteBatch spriteBatch)
        {
            //call draw method on the player
            mPlayer.Draw(spriteBatch);

            
            //call draw on the aliens
            for(int i = 0; i < mEnemies.Count(); i++)
            {
               mEnemies[i].Draw(spriteBatch);
            }
            
            for(int i = 0; i < mBarricades.Count; i++)
            {
                mBarricades[i].Draw(spriteBatch);
            }

            //mEnemy.Draw(spriteBatch);
        }

        int gameScore;
        Player mPlayer;//player
        List<Enemy> mEnemies;//list of the aliens
        List<Barricade> mBarricades;
        //enemy movement
        int numStepsSoFar, numStepsPerRow;
        bool walkDir;
        //Enemy mEnemy;

        //todo: add list of aliens, player object
    }
}
