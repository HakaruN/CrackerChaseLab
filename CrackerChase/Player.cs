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

        bool bHasFired = false;

        public Player(int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, Texture2D bulletTexture, int inDrawWidth,  float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            //init the bullet
            mBullet = new Mover(inScreenWidth, inScreenHeight, bulletTexture, inDrawWidth, 50, 50, 0, 0);
        }

        public Player(Mover playerMover, int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, Texture2D bulletTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            //init the bullet
            mBullet = new Mover(inScreenWidth, inScreenHeight, bulletTexture, inDrawWidth, 50, 50, 0, 0);

            mMover = playerMover;
        }

        //check if bullet is onscreen
        private bool isBulletOnscreen(int inScreenWidth, int inScreenHeight)
        {
            if(mBullet.GetPos().X < inScreenWidth || mBullet.GetPos().X > 0)
            //if its within the width of the screen
            {
                if(mBullet.GetPos().Y < inScreenHeight || mBullet.GetPos().Y > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

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
<<<<<<< HEAD
=======


            if(mBullet != null)
            {
                if (isBulletOnscreen(inScreenWidth, inScreenHeight))
                {
                    //if the bullet is onscreen then move the bullet up
                    mBullet.StartMovingUp();
                    bHasFired = true;
                }
                else
                {
                    //set has fired to false so we can fire again
                    bHasFired = false;
                }
                
            }

>>>>>>> 7530ffd9a5458f869c7eb38478a9959606ffec7a
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            mMover.Draw(spriteBatch);            
            //spriteBatch.End();
        }

        //add a sprite to the sprite list
        public void addSprite(Mover m)
        {
            mMover = m;
        }

        public void fireGun()
        {
<<<<<<< HEAD
            bHasFired = true;

            if (mBullet != null)
            {
                mBullet.SetPosition(mMover.GetPos().X, mMover.GetPos().Y);
                mBullet.StartMovingUp();
            }

            //fire the bullet

            //play sound

        }


        /*
        class Player : Game
        {
<<<<<<< HEAD
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;

            List<Sprite> gameSprites = new List<Sprite>();
=======
            spriteBatch.Begin();
>>>>>>> master

            SpriteFont messageFont;

            string messageString = "Hello world";

            Mover mainPlayer;

            int screenWidth;
            int screenHeight;

            bool bHasFired = false;

            public Player()
=======
            //bHasFired = true;

            if (mBullet != null && bHasFired)
>>>>>>> 7530ffd9a5458f869c7eb38478a9959606ffec7a
            {
                mBullet.SetPosition(GetPos().X, GetPos().Y);
                //mBullet.SetPosition(mMover.GetPos());
            }


            //fire the bullet

            //play sound

        }

    }
}
