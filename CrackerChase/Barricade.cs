using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;

namespace CrackerChase
{

    class Barricade : Mover
    {
        bool bIsGone = false;
        public int barricadeHealth = 5;

        //members
        Mover mMover;//the mover that represents the player

        public Barricade(int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {

        }

        public Barricade(Mover playerMover, int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            mMover = playerMover;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!bIsGone)
            {
                mMover.Draw(spriteBatch);
            }
        }

        //add a sprite to the sprite list
        public void addSprite(Mover m)
        {
            mMover = m;
        }

        public void Update(GameTime gameTime)
        {
            if(barricadeHealth <= 0)
            {
                bIsGone = true;
            }
        }


    }
}
