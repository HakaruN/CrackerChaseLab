using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    interface gameScene//an interface that ensures all games scenes will have an update and draw method
    {
        void update(GameTime gametime);
        void draw();
    }
}
