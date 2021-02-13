using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrackerChase
{
    class Sprite
    {

        protected Texture2D mTexture;
        protected ContentStore mContentStore;
        public Texture2D getTexture() { return mTexture; }
        protected Rectangle mRectangle;

        protected float mXPos, mYPos;


        public Sprite(ContentStore content, string texName, float defaultXPos, float defaultYPos, int spriteWidth, int spriteHeight)
        {
            //assign and load content
            mContentStore = content;
            mTexture = mContentStore.getTexture(texName);

            //cal aspect ratio and dimensions
            //float aspect = mTexture.Width / mTexture.Height;
            //int height = (int)Math.Round(inDrawWidth * aspect);

            //generate a rectangle with the dimentions of the texture
            mRectangle = new Rectangle(0, 0, spriteWidth, spriteHeight);
            Console.WriteLine();
            SetPosition(defaultXPos, defaultYPos);
        }

        public void SetPosition(float x, float y)
        {
            mXPos = (int)Math.Round(x);
            mYPos = (int)Math.Round(y);
        }
        public void offsetPosition(float xOffset, float yOffset)
        {
            mXPos += xOffset;
            mYPos += yOffset;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            mRectangle.X = (int)Math.Round(mXPos);
            mRectangle.Y = (int)Math.Round(mYPos);
            spriteBatch.Draw(mTexture, mRectangle, Color.White);
        }

        public virtual void Update(float deltaTime)
        {

        }



        public Vector2 GetCentre()
        {
            float x = mXPos + mRectangle.Width / 2;
            float y = mYPos + mRectangle.Height / 2;
            return new Vector2(x, y);
        }

        public float GetDistanceFrom(Sprite s)
        {
            Vector2 v1 = s.GetCentre();
            Vector2 v2 = GetCentre();
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            return (float)Math.Sqrt((dx * dx) + (dy * dy));
        }

        public bool IntersectsWith(Sprite s)
        {
            return mRectangle.Intersects(s.mRectangle);
        }

        //check if the sprite is onscreen
        public virtual bool isOnscreen(int inScreenWidth, int inScreenHeight)
        {

            if (mXPos < inScreenWidth && mXPos > 0)
            {
                //within the width of the screen
                if (mYPos < inScreenHeight && mYPos > 0)
                {
                    //within the height of the screen
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    
}
