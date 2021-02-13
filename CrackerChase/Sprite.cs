using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrackerChase
{
    class Sprite
    {



        protected Texture2D texture;
        public Texture2D getTexture() { return texture; }
        protected Rectangle rectangle;

        protected float xPosition;
        protected float yPosition;

        protected float xResetPosition;
        protected float yResetPosition;

        public Sprite(Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY)
        {
            texture = inSpriteTexture;



            xResetPosition = inResetX;
            yResetPosition = inResetY;

            float aspect = inSpriteTexture.Width / inSpriteTexture.Height;
            int height = (int)Math.Round(inDrawWidth * aspect);
            rectangle = new Rectangle(0, 0, inDrawWidth, height);

            Reset();
        }

        public void SetPosition(float x, float y)
        {
            xPosition = (int)Math.Round(x);
            yPosition = (int)Math.Round(y);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            rectangle.X = (int)Math.Round(xPosition);
            rectangle.Y = (int)Math.Round(yPosition);
            spriteBatch.Draw(texture, rectangle, Color.White);
            //Console.WriteLine("xpos: {0}, ypos: {1}", xPosition, yPosition);
        }

        public virtual void Update(float deltaTime)
        {

        }

        public void SetResetPosition(float x, float y)
        {
            xResetPosition = x;
            yResetPosition = y;
        }
        public void offsetPosition(float xOffset, float yOffset)
        {
            xPosition += xOffset;
            yPosition += yOffset;
        }

        public virtual void Reset()
        {
            SetPosition(xResetPosition, yResetPosition);
        }

        public Vector2 GetCentre()
        {
            float x = xPosition + rectangle.Width / 2;
            float y = yPosition + rectangle.Height / 2;
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
            return rectangle.Intersects(s.rectangle);
        }

        //check if the sprite is onscreen
        public virtual bool isOnscreen(int inScreenWidth, int inScreenHeight)
        {

            if (xPosition < inScreenWidth && xPosition > 0)
            {
                //within the width of the screen
                if (yPosition < inScreenHeight && yPosition > 0)
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
