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
            mContentStore.addSoundEffect("laser");
            mContentStore.addSong("spaceInvaders");
            mSoundManager.playSong(mContentStore.getSong("spaceInvaders"));


            //init the enemies list
            mEnemies = new List<Enemy>();
            mBarricade = new List<Barricade>();

            //Enemy texture
            mContentStore.addTexture("Alien1");
            //space ship texture
            mContentStore.addTexture("SpaceShip");
            int spaceshipWidth = screenWidth / 25;
            //barricade texture
            mContentStore.addTexture("block");
            int barricadeWidth = 10;
            //bullet texture
            mContentStore.addTexture("bullet");
            int bulletWidth = screenWidth / 20;


            
            //add player with a new mover
            mPlayer = new Player(mContentStore.getTexture("SpaceShip"), mContentStore.getTexture("SpaceShip"), bulletWidth, screenWidth / 2, screenHeight - 20, 500, 500, mContentStore.GetSoundEffect("laser"));

            //add enemies
            int numEnemyRows = 3, numEnemiyCols = 5;
            int enemyPosX = 0, enemyPosY = 0;
            int enemySpacingX = 50, enemySpacingY = 60;//space between enemies (num pixels)

            for (int i = 0; i < numEnemiyCols; i++)
            {
                for (int j = 0; j < numEnemyRows; j++)
                {
                    mEnemies.Add(new Enemy(mContentStore.getTexture("Alien1"), spaceshipWidth, enemyPosX + (i * enemySpacingX), enemyPosY + (j * enemySpacingY), 500, 500, mSoundManager));
                }
            }

            //add barricades
            int numBarricades = 4;
            int barricadeOffset = (int)(screenWidth * 0.2f);
            int barricadeSpacing = 150;
            for (int i = 0; i < numBarricades; i++)
            {
                mBarricade.Add(new Barricade(mContentStore.getTexture("block"), barricadeWidth, i * barricadeSpacing + barricadeOffset, screenHeight * 0.8f));
            }


            //the required things for the scenes
            Texture2D splashScreenTex = Content.Load<Texture2D>("splashScreen");
            Sprite splashImage = new Sprite(splashScreenTex, screenWidth, 0, 0);
            SpriteFont messageFont = Content.Load<SpriteFont>("MessageFont");

            //create the scenes
            SplashScreen splashScreen = new SplashScreen(splashImage, 1);//create splash screen
            MainMenu mainMenu = new MainMenu(splashImage, messageFont);
            GameplayScene gameTestScene = new GameplayScene(mPlayer, mEnemies, mBarricade);//create gameplay scene

            //add the scenes to the manager
            mSceneManager.addScene(splashScreen);//add the splash screen
            mSceneManager.addScene(mainMenu);//add the splash screen
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
