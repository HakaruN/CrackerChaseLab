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

        public Barricade(Texture2D inSpriteTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed) : base(inSpriteTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!bIsGone)
            {
                base.Draw(spriteBatch);
            }
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
