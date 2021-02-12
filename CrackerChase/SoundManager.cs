using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
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
        Song backgroundSound;
        SoundEffect fireGun;
        ContentManager content;
       public SoundManager(ContentManager cont)
        {
            content = cont;
            playerDeath = content.Load<SoundEffect>("explosion");
            fireGun = content.Load<SoundEffect>("laser");
            backgroundSound = content.Load<Song>("spaceInvaders");
            enemyColision = content.Load<SoundEffect>("beep1");
        }
        public void playDeath()
        {
            playerDeath.CreateInstance().Play();
        }

        public void playGun()
        {
            fireGun.CreateInstance();
        }

        public void playBackground()
        {
                   }

        public void enemyCol()
        {
            enemyColision.CreateInstance();
        }



    }
}
