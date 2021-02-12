using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    interface GameScene//an interface that ensures all games scenes will have an update and draw method
    {
        void Update(GameTime gametime, KeyboardState keys, SceneManager manager, int inScreenWidth, int inScreenHeight);
        void Draw(SpriteBatch spriteBatch);
    }
}
