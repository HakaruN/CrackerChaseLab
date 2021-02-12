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
        SoundEffect playerDeath;
        SoundEffect enemyColision;
        SoundEffect backgroundSound;
        SoundEffect fireGun;
        ContentManager content;
        SoundManager(ContentManager cont)
        {
            content = cont;

            playerDeath = content.Load<SoundEffect>("explosion");
            fireGun = content.Load<SoundEffect>("laser");
            backgroundSound = content.Load<SoundEffect>("spaceInvaders"); 
            enemyColision = content.Load<SoundEffect>("beep1");
        }
        void playDeath()
        {
            playerDeath.CreateInstance();
        }

        void playGun()
        {
            fireGun.CreateInstance();
        }

        void playBackground()
        {
            backgroundSound.Play();
        }

        void enemyCol()
        {
            enemyColision.CreateInstance();
        }

    }
}
