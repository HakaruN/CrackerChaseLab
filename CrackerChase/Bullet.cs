using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrackerChase
{
    class Bullet : Mover
    {
        public Bullet(Texture2D bulletTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(bulletTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {

        }

        /*
        //check if bullet is onscreen
        public override bool isOnscreen(int inScreenWidth, int inScreenHeight)
        {

            //if its within the width of the screen
            if (xPosition < inScreenWidth && xPosition > 0)
            {
                if (yPosition < inScreenHeight && yPosition > 0)
                {
                    //Console.WriteLine("Bullet onscreen");
                    return true;
                }
                else
                {
                    //Console.WriteLine("Bullet offscreen");
                    this.SetPosition(-100.0f, -100.0f);
                    return false;
                }
            }
            //Console.WriteLine("Bullet offscreen");
            return false;
        }
        */
    }
}
