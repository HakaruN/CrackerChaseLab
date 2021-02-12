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
            MovingUp = true;
        }
        public void StopMovingUp()
        {
            MovingUp = false;
        }

        public void StartMovingDown()
        {
            MovingDown = true;
        }
        public void StopMovingDown()
        {
            MovingDown = false;
        }

        public void StartMovingLeft()
        {
            MovingLeft = true;
        }
        public void StopMovingLeft()
        {
            MovingLeft = false;
        }

        public void StartMovingRight()
        {
            MovingRight = true;
        }
        public void StopMovingRight()
        {
            MovingRight = false;
        }

        public Vector2 GetPos()
        {
            Vector2 position = new Vector2(xPosition,yPosition);

            return position;
        }


        protected bool MovingUp;
        protected bool MovingDown;
        protected bool MovingLeft;
        protected bool MovingRight;

        protected float resetXSpeed;
        public float getResetXSpeed() { return resetXSpeed; }
        protected float resetYSpeed;
        public float getResetYSpeed() { return resetYSpeed; }

        protected float xSpeed;
        protected float ySpeed;

        public Mover(int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) :
            base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY)
        {
            resetXSpeed = inResetXSpeed;
            resetYSpeed = inResetYSpeed;
            Reset();
        }
        /*
        public Mover(Mover other) 
            : base(other.getScreenWidth(), other.getScreenHeight(), other.getTexture(), inDrawWidth, inResetX, inResetY)
        {
            resetXSpeed = other.getResetXSpeed();
            resetYSpeed = other.getResetYSpeed();
        }
        */
        public override void Reset()
        {
            MovingDown = false;
            MovingUp = false;
            MovingLeft = false;
            MovingRight = false;
            SetSpeed(resetXSpeed, resetYSpeed);
            base.Reset();
        }

        public void SetSpeed(float inXSpeed, float inYSpeed)
        {
            xSpeed = inXSpeed;
            ySpeed = inYSpeed;
        }

        public override void Update(float deltaTime)
        {
            if (MovingLeft)
            {
                xPosition = xPosition - (xSpeed * deltaTime);
                Console.WriteLine("Moving left");
            }
            if (MovingRight)
            {
                xPosition = xPosition + (xSpeed * deltaTime);
                Console.WriteLine("Moving right");
            }
            if (MovingUp)
            {
                yPosition = yPosition - (ySpeed * deltaTime);
                Console.WriteLine("Moving up");
            }
            if (MovingDown)
            {
                yPosition = yPosition + (ySpeed * deltaTime);
                Console.WriteLine("Moving down");
            }

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
            //Console.WriteLine("xpos: {0}, ypos:{1}", xPosition,yPosition );
            base.Update(deltaTime);
        }
        /*
        public override void Draw(SpriteBatch spriteBatch)
        {
            rectangle.X = (int)Math.Round(xPosition);
            rectangle.Y = (int)Math.Round(yPosition);
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
        */

    }
}
