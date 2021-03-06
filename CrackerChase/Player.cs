﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace CrackerChase
{
    class Player : Mover
    {
        //bullet
        Bullet mBullet;

        bool bHasFired = false;
        public bool isBulletOnScreen = false;


        public Player(ContentStore content, string playerTexName, string bulletTexName, string bulletSoundName, float defaultXPos, float defaultYPos, float inDefaultXSpeed, float inDefaultYSpeed, int spriteWidth, int spriteHeight)
            : base(content, playerTexName, defaultXPos, defaultYPos, inDefaultXSpeed, inDefaultYSpeed, spriteWidth, spriteHeight)
        {
            //init the bullet
            int[] bulletDimentions = { 30, 50 };
            mBullet = new Bullet(content, bulletTexName, bulletSoundName, -200, -200, 0, 400, bulletDimentions[0], bulletDimentions[1]);
        }

        public Bullet getBullet()
        {
            return mBullet;
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

            //call the update function for the mover object of the player
            base.Update(1.0f / 60f);


            //update the bullet
            mBullet.Update(1.0f / 60f);
            isBulletOnScreen = mBullet.isOnscreen(inScreenWidth, inScreenHeight);
            if (isBulletOnScreen)
            {
                //if the bullet is onscreen then move the bullet up and set the fired flag so we cant fire again
                mBullet.StartMovingUp();
                bHasFired = true;
            }
            else
            {
                //set has fired to false so we can fire again
                bHasFired = false;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //if the bullet is on screen draw it
            //Console.WriteLine("is bullet destroyed: {0}", mBullet.isDestroyed());
            if (mBullet.isDestroyed() == false)
            {
                mBullet.Draw(spriteBatch);
            }

            //draw the player
            base.Draw(spriteBatch);
        }


        public void fireGun(SoundManager soundManager)
        {

            //fire the bullet
            mBullet.SetPosition(this.GetPos().X, this.GetPos().Y);
            mBullet.undestroyBullet();//make the bullet not destroyed
            //Console.WriteLine("Undestroying bullet");

            //play sound
            soundManager.playSound(mBullet.getGunfireSound());
        }



    }
}
