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

        public void draw(SpriteBatch spriteBatch)
        {
            //call draw method on the player
            mPlayer.draw(spriteBatch);
            
            //call draw on the aliens
            for(int i = 0; i < mAliens.Count(); i++)
            {
                mAliens[i].draw(spriteBatch);
            }
        }

        int gameScore;
        Player mPlayer;//player
        List<Alien> mAliens;//list of the aliens
        
        //todo: add list of aliens, player object
    }
}
