using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    interface gameScene//an interface that ensures all games scenes will have an update and draw method
    {
        void Update(GameTime gametime);
        void Draw(GameTime gametime);
    }
}
