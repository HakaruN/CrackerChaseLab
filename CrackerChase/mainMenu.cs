using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace CrackerChase
{
    class MainMenu : GameScene
    {


        public MainMenu(Sprite splashImage, SpriteFont messageFont)
        {
            mMessageFont = messageFont;//font used to display text
            mSplashImage = splashImage;

            mPressStartPos = new Vector2();
        }
        public void update(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight,ref CrossSceneData data)
        {
            //if we have endured the required amount of time, transition to next scene
            if(keys.IsKeyDown(Keys.Enter))
            {
                sceneManager.selectNextScene();
            }

            mPressStartPos.X = (inScreenWidth - mMessageFont.MeasureString(mMessageString).X) / 2;
            mPressStartPos.Y = inScreenHeight * 0.2f;// inScreenHeight - (inScreenHeight * 0.2f);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            mSplashImage.Draw(spriteBatch);//draw the splash screen
            spriteBatch.DrawString(mMessageFont, mMessageString, mPressStartPos, Color.Green);
        }


        //members
        Sprite mSplashImage;//image shown onscreen during the splash screen
        string mMessageString = "Press enter to play";
        SpriteFont mMessageFont;
        Vector2 mPressStartPos;
    }
}
