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
        Mover mMover;//the mover that represents the player        
        Mover mBullet;

        public Enemy(int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {

        }

        public Enemy(Mover playerMover, int inScreenWidth, int inScreenHeight, Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inScreenWidth, inScreenHeight, inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {
            mMover = playerMover;
        }

        public void Draw(SpriteBatch spriteBatch)
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

        public void Update(GameTime gameTime)
        {

        }



    }
}
