using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class gameplayScene : gameScene
    {
        public void update(GameTime gametime)
        {
            //call update method on the player
            mPlayer.update(gametime);

            //call update method on the aliens
            for(int i = 0; i < mAliens.Count(); i++)
            {
                mAliens[i].update(gametime);
            }
        }

        public void draw()
        {
            //call draw method on the player
            mPlayer.draw();
            
            //call draw on the aliens
            for(int i = 0; i < mAliens.Count(); i++)
            {
                mAliens[i].draw();
            }
        }

        int gameScore;
        Player mPlayer;//player
        List<Alien> mAliens;//list of the aliens
        
        //todo: add list of aliens, player object
    }
}
