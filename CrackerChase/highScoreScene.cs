using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrackerChase
{
    public struct scores
    {
        public scores(string nameInit, string scoreInit)
        {
            name = nameInit;
            score = scoreInit;
        }
        public string name;
        public string score;
    }

    class HighScoreScene : GameScene
    {
        public HighScoreScene(Sprite splashImage, SpriteFont messageFont)
        {
            mSplashImage = splashImage;
            mContinueText = new RenderableText("Press enter to continue", new Vector2(), messageFont, Color.Red);
            mScore = new RenderableText("Score: ", new Vector2(), messageFont, Color.Green);


        }
        public void onSwitchTo(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight, ref CrossSceneData data)
        {
            //init the scores list
            mScores = new List<scores>();

            mScore.updateText("Score: " + data.score.ToString());

            //position the score text on the screen
            Vector2 scorePos = new Vector2(
                (inScreenWidth - mScore.getFont().MeasureString(mScore.getText()).X) / 2,//calc x pos
                inScreenHeight * 0.2f);//calx y pos - top 20% of screen
            mScore.updatePos(scorePos);


            scorePos = new Vector2(
                (inScreenWidth - mContinueText.getFont().MeasureString(mContinueText.getText()).X) / 2,//calc x pos
                inScreenHeight * 0.8f);//calx y pos - at bottom 20% of screen
            mContinueText.updatePos(scorePos);
        }
        public void update(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight,ref CrossSceneData data)
        {
            if (keys.IsKeyDown(Keys.Enter))
            {   //go back to the main menue
                sceneManager.selectSceneByID(1, deltaTime, keys, sceneManager, soundManager, inScreenWidth, inScreenHeight, ref data);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {

            mSplashImage.Draw(spriteBatch);//draw the splash screen
            //spriteBatch.DrawString(mMessageFont, mScoreString, mHighScoreTextPos, Color.Green);
            mScore.renderText(spriteBatch);
            mContinueText.renderText(spriteBatch);
        }

        Sprite mSplashImage;//image shown onscreen during the splash screen

        RenderableText mContinueText;
        RenderableText mScore;
        List<scores> mScores;
        
    }
}
