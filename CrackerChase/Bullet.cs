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
        public Bullet(Texture2D bulletTexture, int inDrawWidth, float inResetX, float inResetY, float inResetXSpeed, float inResetYSpeed, SoundManager soundManager) : base(bulletTexture, inDrawWidth, inResetX, inResetY, inResetXSpeed, inResetYSpeed)
        {

        }
    }
}
