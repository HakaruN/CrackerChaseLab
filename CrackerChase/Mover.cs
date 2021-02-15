using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class Mover : Sprite
    {
        public void StartMovingUp()
        {
            mIsMovingUp = true;
        }
        public void StopMovingUp()
        {
            mIsMovingUp = false;
        }

        public void StartMovingDown()
        {
            mIsMovingDown = true;
        }
        public void StopMovingDown()
        {
            mIsMovingDown = false;
        }

        public void StartMovingLeft()
        {
            mIsMovingLeft = true;
        }
        public void StopMovingLeft()
        {
            mIsMovingLeft = false;
        }

        public void StartMovingRight()
        {
            mIsMovingRight = true;
        }
        public void StopMovingRight()
        {
            mIsMovingRight = false;
        }

        public Vector2 GetPos()
        {
            Vector2 position = new Vector2(mXPos, mYPos);

            return position;
        }


        protected bool mIsMovingUp;
        protected bool mIsMovingDown;
        protected bool mIsMovingLeft;
        protected bool mIsMovingRight;


        protected float mXSpeed;
        protected float mYSpeed;

        public Mover(ContentStore content, string texName, float defaultXPos, float defaultYPos, float inDefaultXSpeed, float inDefaultYSpeed, int spriteWidth, int spriteHeight) :
            base(content, texName, defaultXPos, defaultYPos, spriteWidth, spriteHeight)
        {
            SetSpeed(inDefaultXSpeed, inDefaultYSpeed);
            Reset();
        }

        public void Reset()
        {
            mIsMovingDown = false;
            mIsMovingUp = false;
            mIsMovingLeft = false;
            mIsMovingRight = false;
        }

        public void SetSpeed(float inXSpeed, float inYSpeed)
        {
            mXSpeed = inXSpeed;
            mYSpeed = inYSpeed;
        }

        public override void Update(float deltaTime)
        {
            if (mIsMovingLeft)
            {
                mXPos = mXPos - (mXSpeed * deltaTime);
                //Console.WriteLine("moveing left");
            }
            if (mIsMovingRight)
            {
                mXPos = mXPos + (mXSpeed * deltaTime);
                //Console.WriteLine("moveing right");
            }
            if (mIsMovingUp)
            {
                mYPos = mYPos - (mYSpeed * deltaTime);
            }
            if (mIsMovingDown)
            {
                mYPos = mYPos + (mYSpeed * deltaTime);
            }

            /*//This takes care of ensuring the movers never go off screen
            if (xPosition < 0)
            {
                xPosition = 0;
            }
            if (xPosition + rectangle.Width > screenWidth)
            {
                xPosition = screenWidth - rectangle.Width;
            }

            if (yPosition < 0)
            {
                yPosition = 0;
            }
            if (yPosition + rectangle.Height > screenHeight)
            {
                yPosition = screenHeight - rectangle.Height;
            }
            */

            base.Update(deltaTime);
        }
    }
}
