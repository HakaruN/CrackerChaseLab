using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;

namespace CrackerChase
{

    class Barricade : Sprite
    {
        bool bIsGone = false;
        public int barricadeHealth = 5;

        public Barricade(ContentStore content, string texName, float defaultXPos, float defaultYPos, int spriteWidth, int spriteHeight)
            : base(content, texName, defaultXPos, defaultYPos, spriteWidth, spriteHeight)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!bIsGone)
            {
                base.Draw(spriteBatch);
            }
        }


        public override void Update(float deltaTime)
        {
            if(barricadeHealth <= 0)
            {
                bIsGone = true;
            }
            base.Update(deltaTime);
        }


    }
}
