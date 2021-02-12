using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class SoundManager
    {
        SoundEffect death;
        SoundEffect gunShoot;
        SoundEffect background;
        SoundEffect enemyCol;

        ContentManager content;
        SoundManager(ContentManager cont)
        {
            content = cont;
        }



    }
}
