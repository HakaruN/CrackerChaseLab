using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;
namespace CrackerChase
{
    class Enemy : Mover
    {
        //members    
        public bool mIsDead;

        public Enemy(Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed, SoundManager soundManager) : base(inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            mIsDead = false;
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
