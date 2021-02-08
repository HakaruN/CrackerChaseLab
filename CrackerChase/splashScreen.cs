using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    class splashScreen : gameScene
    {
        public void update(GameTime gametime)
        {

        }

        public void draw(SpriteBatch spriteBatch)
        {
            rectangle.X = (int)Math.Round(xPosition);
            rectangle.Y = (int)Math.Round(yPosition);
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
