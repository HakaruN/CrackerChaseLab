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
        //Mover mMover;//the mover that represents the player        
        Mover mBullet;

        //gunfire sound
        SoundEffect mGunFire;

        //bullet properties (TODO: abstract bullet to own class)
        bool bHasFired = false;
        public bool isOnScreen = false;



        public Player(Texture2D inSpriteTexture, Texture2D bulletTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed, SoundEffect gunFire)
            : base(inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            //init the bullet
            mBullet = new Mover(bulletTexture, inDrawWidth, -10, -10, 0, 500);
            //gun sound
            mGunFire = gunFire;
        }

        public Mover getBullet()
        {
            return mBullet;
        }

        //check if bullet is onscreen
        private bool isBulletOnscreen(int inScreenWidth, int inScreenHeight)
        {

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

        public void Update(float deltaTime, KeyboardState keys, int inScreenWidth , int inScreenHeight, SoundManager soundManager)
        {

            //do player specific updating:
            if (keys.IsKeyDown(Keys.Left) || (keys.IsKeyDown(Keys.A)))
            {
                this.StartMovingLeft();
            }
            else
            {
                this.StopMovingLeft();
            }

            if (keys.IsKeyDown(Keys.Right) || (keys.IsKeyDown(Keys.D)))
            {
                this.StartMovingRight();
            }
            else
            {
                this.StopMovingRight();
            }

            if (keys.IsKeyDown(Keys.Space) && !bHasFired)
            {
                fireGun(soundManager);
            }            

            //call the update function for the mover object
            base.Update(1.0f / 60f);
            mBullet.Update(1.0f / 60f);


            //update the bullet
            if (isBulletOnscreen(inScreenWidth, inScreenHeight))
            {
                //if the bullet is onscreen then move the bullet up
                mBullet.StartMovingUp();
                bHasFired = true;
                isOnScreen = true;
            }
            else
            {
                //set has fired to false so we can fire again
                bHasFired = false;
                isOnScreen = false;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            //if bullet on screen, draw the bullet
            if (isOnScreen)
            {
                //spriteBatch.Begin();
                mBullet.Draw(spriteBatch);
                //spriteBatch.End();
            }
            
        }


        public void fireGun(SoundManager soundManager)
        {

            //fire the bullet
            mBullet.SetPosition(this.GetPos().X, this.GetPos().Y);

            //play sound
            soundManager.playSound(mGunFire);
        }



    }
}
