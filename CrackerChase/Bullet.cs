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
        //gunfire sound
        protected SoundEffect mGunFire;
        bool mIsBulletDestroyed;//when the bullet hits something, its destroyed

        public SoundEffect getGunfireSound()
        {
            return mGunFire;
        }

        public Bullet(ContentStore content, string texName, string gunSoundName,  float defaultXPos, float defaultYPos, float inDefaultXSpeed, float inDefaultYSpeed, int spriteWidth, int spriteHeight) 
            : base(content, texName, defaultXPos, defaultYPos, inDefaultXSpeed, inDefaultYSpeed, spriteWidth, spriteHeight)
        {
            mGunFire = content.GetSoundEffect(gunSoundName);
            //mIsBulletDestroyed = true;//init to destroyed
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }
        public void undestroyBullet()
        {
            //Console.WriteLine("undestroying bullet");
            mIsBulletDestroyed = false;
        }
        public void destroyBullet()
        {
            //Console.WriteLine("destroying bullet");
            mIsBulletDestroyed = true;
        }

        public bool isDestroyed()
        {
            return mIsBulletDestroyed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //if the bullet isn't destroyed
            if (mIsBulletDestroyed == false)
            {
                base.Draw(spriteBatch);
            }
        }

    }
}
