using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;

namespace CrackerChase
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        // Game World
        // These variables define the world 
        int screenWidth;
        int screenHeight;

        //scene manager
        SceneManager mSceneManager;
        //player
        Player mPlayer;
        Enemy mEnemy;

        List<Enemy> mEnemies;
        List<Barricade> mBarricade;
        //legacy crap
        //Mover cheese;
        //Target cracker;
        //Sprite background;
        //SoundEffect BurpSound;



        //List<Sprite> gameSprites = new List<Sprite>();
        //List<Target> crackers = new List<Target>();

        //SpriteFont messageFont;

        //string messageString = "Hello world";

        //int score;
        //int timer;

        //bool playing;


        void startPlayingGame()
        {
            /*
            foreach (Sprite s in gameSprites)
            {
                s.Reset();
            }
            foreach (Target t in crackers)
            {
                t.Reset();
            }
            messageString = "Cracker Chase";
            
            playing = true;
            timer = 600;
            score = 0;
            */

            bool isRunning = false;
            GameTime gameTime1 = new GameTime();
            while (isRunning)
            {
                this.Update(gameTime1);
            }
           
        }

      
        public Game1()
        {
            //init the scene manager
            mSceneManager = new SceneManager();
            //init graphics
            graphics = new GraphicsDeviceManager(this);
            //init content
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
            /*
            messageFont = Content.Load<SpriteFont>("MessageFont");

            Texture2D cheeseTexture = Content.Load<Texture2D>("cheese");
            Texture2D cloth = Content.Load<Texture2D>("Tablecloth");
            Texture2D crackerTexture = Content.Load<Texture2D>("cracker");

            BurpSound = Content.Load<SoundEffect>("Burp");

            background = new Sprite(screenWidth, screenHeight, cloth, screenWidth, 0, 0);
            gameSprites.Add(background);

            int crackerWidth = screenWidth / 20;

            for (int i = 0; i < 100; i++)
            {
                cracker = new Target(screenWidth, screenHeight, crackerTexture, crackerWidth, 0, 0);
                gameSprites.Add(cracker);
                crackers.Add(cracker);
            }
            
            int cheeseWidth = screenWidth / 15;
            cheese = new Mover(screenWidth, screenHeight, cheeseTexture, cheeseWidth, screenWidth / 2, screenHeight / 2, 500, 500);
            //gameSprites.Add(cheese);
            */

            //init the enemies list
            mEnemies = new List<Enemy>();
            mBarricade = new List<Barricade>();

            //space ship texture
            Texture2D spaceShipTex = Content.Load<Texture2D>("SpaceShip");
            int spaceshipWidth = screenWidth / 25;

            //add player with a new mover
            mPlayer = new Player(
                new Mover(screenWidth, screenHeight, spaceShipTex, spaceshipWidth, screenWidth / 2, screenHeight - 20, 500, 500),
                screenWidth, screenHeight, spaceShipTex, spaceShipTex, spaceshipWidth, screenWidth / 2, screenHeight - 20, 500, 500);
            mEnemies.Add(new Enemy(new Mover
                (screenWidth, screenHeight, spaceShipTex, spaceshipWidth, screenWidth / 2, screenHeight - 20, 500, 500),
                screenWidth, screenHeight, spaceShipTex, spaceshipWidth, screenWidth / 2, screenHeight - 20, 500, 500));

            mBarricade.Add(new Barricade(new Mover(screenWidth, screenHeight, spaceShipTex, spaceshipWidth, screenWidth / 4, screenHeight - 20, 500, 500),
                screenWidth, screenHeight, spaceShipTex, spaceshipWidth, screenWidth / 2, screenHeight - 20, 500, 500));



            /*mEnemy = new Enemy(new Mover
                (screenWidth,screenHeight,spaceShipTex,spaceshipWidth,screenWidth/2,screenHeight-20,500,500),
                screenWidth,screenHeight,spaceShipTex,spaceshipWidth,screenWidth/2,screenHeight-20,500,500);*/

            //Add the first scene
            Texture2D splashScreenTex = Content.Load<Texture2D>("splashScreen");
            Sprite splashImage = new Sprite(screenWidth, screenHeight, splashScreenTex, screenWidth, 0, 0);

            SplashScreen splashScreen = new SplashScreen(splashImage);//create splash screen
            mSceneManager.addScene(splashScreen);//add the splash screen

            GameplayScene gameTestScene = new GameplayScene(mPlayer, mEnemies, mBarricade);//create gameplay scene
            mSceneManager.addScene(gameTestScene);//add the scene to the manager
            

            startPlayingGame();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


     

        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //get the keys state
            KeyboardState keys = Keyboard.GetState();
            
            //passes an update call to the scene manager
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
            mSceneManager.Update(gameTime, keys, screenWidth, screenHeight);

        }




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //clear the screen
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            //passes a draw call to the scene manager
            mSceneManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
