using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class HighScoreScene : GameScene
    {
        public HighScoreScene(Sprite splashImage, SpriteFont messageFont)
        {
            mSplashImage = splashImage;
            mMessageFont = messageFont;//font used to display text
            mHighScoreTextPos = new Vector2();
        }
        public void update(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight,ref CrossSceneData data)
        {
            mHighScoreTextPos.X = (inScreenWidth - mMessageFont.MeasureString(mMessageString).X) / 2;
            mHighScoreTextPos.Y = inScreenHeight * 0.2f;
            mMessageString = "Score: " + data.score;
        }

        public void draw(SpriteBatch spriteBatch)
        {

            mSplashImage.Draw(spriteBatch);//draw the splash screen
            spriteBatch.DrawString(mMessageFont, mMessageString, mHighScoreTextPos, Color.Green);
        }

        Sprite mSplashImage;//image shown onscreen during the splash screen
        string mMessageString = "Score: ";
        SpriteFont mMessageFont;
        Vector2 mHighScoreTextPos;
    }
}
