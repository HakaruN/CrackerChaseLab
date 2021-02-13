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
        //The song that will make up the background music
        Song mBackgroundMusic;


        public SoundManager(ContentManager cont)
        {
      
        }
        public void playSound(SoundEffect sound)
        {
            sound.CreateInstance().Play();
        }
        
        public void playSong(Song song)
        {
            mBackgroundMusic = song;
            MediaPlayer.Play(mBackgroundMusic);
            
        }
        public void haltSong()
        {

        }
        public void setVolume(int vol)
        {

        }


    }
}
