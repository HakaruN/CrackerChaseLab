using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class GameplayScene : GameScene
    {
        public GameplayScene(Player player)
        {
            mPlayer = player;
            gameScore = 0;
        }

        public GameplayScene(Enemy enemy)
        {
            mEnemy = enemy;
        }

        public void Update(GameTime gametime, KeyboardState keys, SceneManager manager, int inScreenWidth, int inScreenHeight)
        {
            //call update method on the player
            mPlayer.Update(1/60f, keys, inScreenWidth, inScreenHeight);

            mEnemy.Update(gametime);

            //call update method on the aliens
            /*
            for(int i = 0; i < mEnemies.Count(); i++)
            {
               mEnemies[i].Update(gametime);
            }
            */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //call draw method on the player
            mPlayer.Draw(spriteBatch);

            /*
            //call draw on the aliens
            for(int i = 0; i < mEnemies.Count(); i++)
            {
               mEnemies[i].Draw(spriteBatch);
            }
            */

            mEnemy.Draw(spriteBatch);
        }

        int gameScore;
        Player mPlayer;//player
        //List<Enemy> mEnemies;//list of the aliens
        Enemy mEnemy;

        //todo: add list of aliens, player object
    }
}
