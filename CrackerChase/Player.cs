using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;

namespace CrackerChase
{
    class Player : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Sprite> gameSprites = new List<Sprite>();

        SpriteFont messageFont;

        string messageString = "Hello world";

        Mover mainPlayer;

        int screenWidth;
        int screenHeight;

        bool bHasFired = false;

        public Player()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            messageFont = Content.Load<SpriteFont>("MessageFont");

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            Texture2D mainPlayerTexture = Content.Load<Texture2D>("mainPlayer");
            gameSprites.Add(mainPlayer);

            int mainPlayerWidth = screenWidth / 15;

            mainPlayer = new Mover(screenWidth, screenHeight, mainPlayerTexture, mainPlayerWidth, screenWidth / 2, screenHeight / 2, 500, 500);
        }

        public new void Update(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();


            if(keys.IsKeyDown(Keys.Left))
            {
                mainPlayer.StopMovingLeft();
            }
            else
            {
                mainPlayer.StopMovingLeft();
            }

            if(keys.IsKeyDown(Keys.Right))
            {
                mainPlayer.StartMovingRight();
            }
            else
            {
                mainPlayer.StopMovingRight();
            }

            if(keys.IsKeyDown(Keys.Space))
            {

            }

            foreach (Sprite s in gameSprites)
            {
                s.Update(1.0f / 60.0f);
            }

            base.Update(gameTime);
        }

        void Fire()
        {

        }
        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            foreach (Sprite s in gameSprites)
            {
                s.Draw(spriteBatch);
            }
            float xPos = (screenWidth - messageFont.MeasureString(messageString).X) / 2;

            Vector2 statusPos = new Vector2(xPos, 10);

            spriteBatch.DrawString(messageFont, messageString, statusPos, Color.Red);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }


}
