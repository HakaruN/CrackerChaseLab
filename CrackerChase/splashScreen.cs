using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class SplashScreen : GameScene
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="splashImage"> image shown onscreen during the splash screen</param>
        /// <param name="screenTime"> how long the splash screen will apear for before ending, default 5 seconds</param>
        public SplashScreen(Sprite splashImage, int screenTime = 2)
        {
            mSplashImage = splashImage;
            mScreenTime = screenTime;
            mEnduredScreenTime = 0;
        }
        public void Update(GameTime gametime, KeyboardState keys, SceneManager manager, int inScreenWidth, int inScreenHeight)
        {
            //if we have endured the required amount of time, transition to next scene
            if(mEnduredScreenTime >= mScreenTime)
            {
                manager.selectNextScene();
            }
            mEnduredScreenTime += (1f / 60f);//increment the endured splash time

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            mSplashImage.Draw(spriteBatch);//draw the splash screen
            //spriteBatch.End();
        }



        Sprite mSplashImage;//image shown onscreen during the splash screen
        int mScreenTime;//how long will the splash screen be onscreen for
        float mEnduredScreenTime;//how long has the splash screen been onscreen for
    }
}
