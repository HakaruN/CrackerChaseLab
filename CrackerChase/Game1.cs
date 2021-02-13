using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics.Contracts;

namespace CrackerChase
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // These variables define the world 
        int screenWidth;
        int screenHeight;

        //scene manager
        SceneManager mSceneManager;
        //content manager/store
        ContentStore mContentStore;
        //sound manager
        SoundManager mSoundManager;

        //TODO: remove from here and add directly to the scene that needs the players, enemies and barricades
        Player mPlayer;
        List<Enemy> mEnemies;
        List<Barricade> mBarricade;



        void startPlayingGame()
        {
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
            //init audio
            mSoundManager = new SoundManager(Content);
            //init content
            Content.RootDirectory = "Content";
            mContentStore = new ContentStore(Content);

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

            //load sounds
            string gunSound = "laser";
            string backgroundSong = "spaceInvaders";
            mContentStore.addSoundEffect(gunSound);
            mContentStore.addSong(backgroundSong);
            mSoundManager.playSong(mContentStore.getSong(backgroundSong));

            //fonts
            mContentStore.addSpriteFont("MessageFont");


            //init the enemies list
            mEnemies = new List<Enemy>();
            mBarricade = new List<Barricade>();

            //splash screen texture
            string splashScreenTex = "splashScreen";
            mContentStore.addTexture(splashScreenTex);
            //gameplay background 
            string backGroundTexture = "BackGrounds";
            mContentStore.addTexture(backGroundTexture);
            //Enemy texture
            string enemyTexture = "Alien1";
            mContentStore.addTexture(enemyTexture);
            //space ship texture
            string spaceShipTexture = "SpaceShip";
            mContentStore.addTexture(spaceShipTexture);
            int spaceshipWidth = screenWidth / 25;
            //barricade texture
            string barricateTexture = "block";
            mContentStore.addTexture(barricateTexture);
            int barricadeWidth = 10;
            //bullet texture
            string bulletTexture = "bullet";
            mContentStore.addTexture(bulletTexture);
            int bulletWidth = screenWidth / 20;



            //add player with a new mover
            int playerHorisontalSpeed = 200;
            int [] playerDimentions = { 50, 50};
            mPlayer = new Player(mContentStore, spaceShipTexture, bulletTexture, gunSound, screenWidth / 2, screenHeight - mContentStore.getTexture(spaceShipTexture).Height, playerHorisontalSpeed, 0, playerDimentions[0], playerDimentions[1]);

            //add enemies
            int numEnemyRows = 3, numEnemiyCols = 5;
            int enemyPosX = 0, enemyPosY = 0;
            int enemySpacingX = 50, enemySpacingY = 60;//space between enemies (num pixels)
            int[] enemyDimentions = { 50, 50 };
            for (int i = 0; i < numEnemiyCols; i++)
            {
                for (int j = 0; j < numEnemyRows; j++)
                {
                    mEnemies.Add(new Enemy(mContentStore, enemyTexture, enemyPosX + (i * enemySpacingX), enemyPosY + (j * enemySpacingY), 0, 0, enemyDimentions[0], enemyDimentions[1]));
                }
            }
            //add barricades
            int numBarricades = 4;
            int barricadeOffset = (int)(screenWidth * 0.2f);
            int barricadeSpacing = 150;
            int[] barricadeDimentions = { 75, 25 };
            for (int i = 0; i < numBarricades; i++)
            {
                mBarricade.Add(new Barricade(mContentStore, barricateTexture, i * barricadeSpacing + barricadeOffset, 
                    (screenHeight * 0.9f) - mContentStore.getTexture(barricateTexture).Height, 
                    barricadeDimentions[0], barricadeDimentions[1]));
            }


            //the required things for the scenes
            int[] splashImageDimentions = { screenWidth, screenHeight };
            Sprite splashImage = new Sprite(mContentStore, splashScreenTex, 0, 0, splashImageDimentions[0], splashImageDimentions[1]);

            //gameplay background
            Sprite backGroundImage = new Sprite(mContentStore, backGroundTexture, 0, 0, splashImageDimentions[0], splashImageDimentions[1]);
            

            //create the scenes
            SplashScreen splashScreen = new SplashScreen(splashImage, 1);//create splash screen
            MainMenu mainMenu = new MainMenu(splashImage, mContentStore.GetSpriteFont("MessageFont"));
            GameplayScene gameScene = new GameplayScene(mPlayer, mEnemies, mBarricade, backGroundImage);//create gameplay scene

            //add the scenes to the manager
            mSceneManager.addScene(splashScreen);//add the splash screen
            mSceneManager.addScene(mainMenu);//add the splash screen
            mSceneManager.addScene(gameScene);//add the scene to the manager

          
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
            mSceneManager.Update(1.0f/60.0f, keys, mSceneManager, mSoundManager, screenWidth, screenHeight);

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
