using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class gameplayScene : gameScene
    {
        public void Update(GameTime gametime)
        {
            //call update method on the player
            mPlayer.Update(gametime);

            //call update method on the aliens
            for(int i = 0; i < mEnemies.Count(); i++)
            {
                mEnemies[i].Update(gametime);
            }
        }

        public void Draw(GameTime gametime)
        {
            //call draw method on the player
            mPlayer.Draw(gametime);
            
            //call draw on the aliens
            for(int i = 0; i < mEnemies.Count(); i++)
            {
                mEnemies[i].Draw(gametime);
            }
        }

        int gameScore;
        Player mPlayer;//player
        List<Enemy> mEnemies;//list of the aliens
        
        //todo: add list of aliens, player object
    }
}
