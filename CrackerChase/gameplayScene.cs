﻿using Microsoft.Xna.Framework;
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
        public GameplayScene(Player player, List<Enemy> enemies, List<Barricade> barricades, ref int enemiesXPos, ref int enemiesYPos)
        {
            mPlayer = player;
            mEnemies = enemies;
            mBarricades = barricades;
            gameScore = 0;
            mEnemiesXPos = enemiesXPos;
            mEnemiesYPos = enemiesYPos;
        }


        public void Update(GameTime gametime, KeyboardState keys, SceneManager manager, int inScreenWidth, int inScreenHeight)
        {
            //call update method on the player
            mPlayer.Update(1/60f, keys, inScreenWidth, inScreenHeight);

            ///mEnemy.Update(gametime);

            //call update method on the aliens

            //set enemy to change direction when they reach 10 pixels from the screen side
            if(mEnemiesXPos <= 10)
            {
                enemyMoveDir = false;
                mEnemiesYPos = mEnemiesYPos - 1;
            }
            else if(mEnemiesXPos >= inScreenWidth - 1)
            {
                enemyMoveDir = true;
                mEnemiesYPos = mEnemiesYPos - 1;
            }

            //apply position changes
            if(enemyMoveDir == false)
            {
                mEnemiesXPos = mEnemiesXPos - 1;
            }
            else
            {
                mEnemiesXPos = mEnemiesXPos + 1;
            }
            Console.WriteLine("xPos {0}, yPos {1}", mEnemiesXPos, mEnemiesYPos);
            

            for (int i = 0; i < mEnemies.Count(); i++)
            {
                mEnemies[i].SetPosition(mEnemies[i].GetPos().X + mEnemiesXPos, mEnemies[i].GetPos().Y + mEnemiesYPos);
                mEnemies[i].Update(gametime);
            }

            for(int i = 0; i < mBarricades.Count; i++)
            {
                mBarricades[i].Update(gametime);
            }

            //end game logic
            if(mEnemiesYPos <= 100)
            {
                Console.WriteLine("Game lost");
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
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
        bool enemyMoveDir = false;
        int mEnemiesXPos, mEnemiesYPos;
        Player mPlayer;//player
        List<Enemy> mEnemies;//list of the aliens
        List<Barricade> mBarricades;
        //Enemy mEnemy;

        //todo: add list of aliens, player object
    }
}
