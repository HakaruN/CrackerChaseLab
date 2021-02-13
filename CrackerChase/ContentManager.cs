using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace CrackerChase
{
    class ContentStore
    {
        //monogame content manager (used to load content)
        public ContentManager mContentIO;
        //stores the textures
        Dictionary<string, Texture2D> mTextures;
        //stores the songs
        Dictionary<string, Song> mSongs;
        //sound effects
        Dictionary<string, SoundEffect> mSoundEffects;

        public ContentStore(ContentManager contentLoader)
        {
            mTextures = new Dictionary<string, Texture2D>();
            mSongs = new Dictionary<string, Song>();
            mSoundEffects = new Dictionary<string, SoundEffect>();
            mContentIO = contentLoader;
        }

        //add a texture directly from file - overwrites the old texture if it exists
        public void addTexture(string texName)
        {
            if (mTextures.ContainsKey(texName))
            {
                mTextures[texName] = mContentIO.Load<Texture2D>(texName);
            }
            else
            {
                mTextures.Add(texName, mContentIO.Load<Texture2D>(texName));
            }
        }
        public void addTexture(Texture2D tex,string texName)
        {
            if (mTextures.ContainsKey(texName))
                mTextures[texName] = tex;
            else
                mTextures.Add(texName, tex);
        }

        //add a song directly from file - overwrites the old song if it exists
        public void addSong(string songName)
        {
            if (mSongs.ContainsKey(songName))
            {
                mSongs[songName] = mContentIO.Load<Song>(songName);
            }
            else
            {
                mSongs.Add(songName, mContentIO.Load<Song>(songName));
            }
        }
        //add a song - overwrites the old song if it exists
        public void addSong(Song song, string songName)
        {
            if (mSongs.ContainsKey(songName))
                mSongs[songName] = song;
            else
                mSongs.Add(songName, song);
        }

        //add a sound directly from file - overwrites the old sound if it exists
        public void addSoundEffect(string soundName)
        {
            if (mSoundEffects.ContainsKey(soundName))
            {
                mSoundEffects[soundName] = mContentIO.Load<SoundEffect>(soundName);
            }
            else
            {
                mSoundEffects.Add(soundName, mContentIO.Load<SoundEffect>(soundName));
            }
        }
        //add a sound - overwrites the old sound if it exists
        public void addSoundEffect(SoundEffect sound, string soundName)
        {
            if (mSoundEffects.ContainsKey(soundName))
                mSoundEffects[soundName] = sound;
            else
                mSoundEffects.Add(soundName, sound);
        }

        //gets a texture by its key/name
        public Texture2D getTexture(string texName)
        {
            if (mTextures.ContainsKey(texName))
                return mTextures[texName];
            else
                return null;
        }

        //gets a song by its key/name
        public Song getSong(string songName)
        {
            if (mSongs.ContainsKey(songName))
                return mSongs[songName];
            else
                return null;
        }

        //gets a sound effect by its key/name
        public SoundEffect GetSoundEffect(string soundName)
        {
            if (mSoundEffects.ContainsKey(soundName))
                return mSoundEffects[soundName];
            else
                return null;
        }

    }
}
