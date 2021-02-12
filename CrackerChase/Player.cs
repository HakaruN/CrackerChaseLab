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
                    mBullet.StartMovingUp();
                }
                else
                {
                    mBullet.StopMovingUp();
                }
            }




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
                mBullet.SetPosition(mMover.GetPos());
                mBullet.StartMovingUp();
            }
>>>>>>> 54a334e46439cace0ee7aabcb481187de35ac5e7
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
            bHasFired = true;

            if (mBullet != null)
            {
                mBullet.SetPosition(GetPos().X, GetPos().Y);
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
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }

            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                messageFont = Content.Load<SpriteFont>("MessageFont");

                screenWidth = GraphicsDevice.Viewport.Width;
                screenHeight = GraphicsDevice.Viewport.Height;

                Texture2D mainPlayerTexture = Content.Load<Texture2D>("mainPlayer");
                gameSprites.Add(mainPlayer);

<<<<<<< HEAD
                int mainPlayerWidth = screenWidth / 15;

                mainPlayer = new Mover(screenWidth, screenHeight, mainPlayerTexture, mainPlayerWidth, screenWidth / 2, screenHeight / 2, 500, 500);
            }
=======
            base.Draw(gameTime);
        }
    }
>>>>>>> master

            public new void Update(GameTime gameTime)
            {
                KeyboardState keys = Keyboard.GetState();


                if(keys.IsKeyDown(Keys.Left))
                {
                    mainPlayer.StopMovingLeft();
                }
                else
                {
                    mainPlayer.StopMovingLeft();
                }

                if(keys.IsKeyDown(Keys.Right))
                {
                    mainPlayer.StartMovingRight();
                }
                else
                {
                    mainPlayer.StopMovingRight();
                }

                if(keys.IsKeyDown(Keys.Space) && !bHasFired)
                {
                    Fire();
                }

                foreach (Sprite s in gameSprites)
                {
                    s.Update(1.0f / 60.0f);
                }

                base.Update(gameTime);
            }

            void Fire()
            {
                bHasFired = true;
            }
            public new void Draw(GameTime gameTime)
            {

                spriteBatch.Begin();

                foreach (Sprite s in gameSprites)
                {
                    s.Draw(spriteBatch);
                }
                float xPos = (screenWidth - messageFont.MeasureString(messageString).X) / 2;

                Vector2 statusPos = new Vector2(xPos, 10);

                spriteBatch.DrawString(messageFont, messageString, statusPos, Color.Red);

                spriteBatch.End();


                base.Draw(gameTime);
            }
        }
        */

    }
}
