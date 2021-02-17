using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CrackerChase
{
    class Enemy : Mover
    {
        //members    
        public bool mIsDead;


        public Enemy(ContentStore content, string texName, float defaultXPos, float defaultYPos, float inDefaultXSpeed, float inDefaultYSpeed, int spriteWidth, int spriteHeight) 
            : base(content, texName, defaultXPos, defaultYPos, inDefaultXSpeed, inDefaultYSpeed, spriteWidth, spriteHeight)
        {
            mIsDead = false;
        }

        static public void enemyToXML()
        {

        }

        
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (mIsDead == false)
            { 
                base.Draw(spriteBatch);
            }
        }

    }
}
