using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;

namespace CrackerChase
{
    class Player : Mover
    {
        //members
        Mover mMover;//the mover that represents the player        
        Mover mBullet;
        SoundManager soundManager;

        bool bHasFired = false;
        bool isOnScreen = false;

        public Player(int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, Texture2D bulletTexture, int inDrawWidth,  float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            //init the bullet
            mBullet = new Mover(inScreenWidth, inScreenHeight, bulletTexture, inDrawWidth, -10, -10, 0, 100);
        }

        public Player(Mover playerMover, int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, Texture2D bulletTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            //init the bullet
            mBullet = new Mover(inScreenWidth, inScreenHeight, bulletTexture, inDrawWidth, -10, -10, 0, 100);

            mMover = playerMover;
        }

        public Mover getBullet()
        {
            return mBullet;
        }

        //check if bullet is onscreen
        private bool isBulletOnscreen(int inScreenWidth, int inScreenHeight)
        {
            //Console.WriteLine("xpos: {0}, ypos: {1}", mBullet.GetPos().X, mBullet.GetPos().Y);

            if (mBullet.GetPos().X < inScreenWidth && mBullet.GetPos().X > 0)
            //if its within the width of the screen
            {
                if(mBullet.GetPos().Y < inScreenHeight && mBullet.GetPos().Y > 0)
                {
                    //Console.WriteLine("Bullet onscreen");
                    return true;
                }
                else
                {
                    //Console.WriteLine("Bullet offscreen");
                    mBullet.SetPosition(-100.0f, -100.0f);
                    return false;
                }
            }
            //Console.WriteLine("Bullet offscreen");
            return false;
        }

        public void Update(float deltaTime, KeyboardState keys, int inScreenWidth , int inScreenHeight)
        {

            //do player specific updating:
            if (keys.IsKeyDown(Keys.Left) || (keys.IsKeyDown(Keys.A)))
            {
                mMover.StartMovingLeft();
            }
            else
            {
                mMover.StopMovingLeft();
            }

            if (keys.IsKeyDown(Keys.Right) || (keys.IsKeyDown(Keys.D)))
            {
                mMover.StartMovingRight();
            }
            else
            {
                mMover.StopMovingRight();
            }

            if (keys.IsKeyDown(Keys.Space) && !bHasFired)
            {
                fireGun();
            }            

            //call the update function for the mover object
            mMover.Update(1.0f / 60f);
            mBullet.Update(1.0f / 60f);


            //update the bullet
            //Console.WriteLine("xpos: {0}, ypos: {1}", mBullet.GetPos().X, mBullet.GetPos().Y);
            if (isBulletOnscreen(inScreenWidth, inScreenHeight))
            {
                //if the bullet is onscreen then move the bullet up
                mBullet.StartMovingUp();
                bHasFired = true;
                isOnScreen = true;
                //Console.WriteLine("Bullet onscreen");
            }
            else
            {
                //set has fired to false so we can fire again
                bHasFired = false;
                isOnScreen = false;
                //Console.WriteLine("Bullet offscreen");
            }



        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            mMover.Draw(spriteBatch);

            //if bullet on screen, draw the bullet
            if (isOnScreen)
            {
                //spriteBatch.Begin();
                mBullet.Draw(spriteBatch);
                //spriteBatch.End();
            }
            
        }

        //add a sprite to the sprite list
        public void addSprite(Mover m)
        {
            mMover = m;
        }

        public void fireGun()
        {
            //bHasFired = true;

            mBullet.SetPosition(mMover.GetPos().X, mMover.GetPos().Y);
            //Console.WriteLine("firing gun");
            //mBullet.StartMovingUp();

            //fire the bullet

            //play sound

        }



    }
}
