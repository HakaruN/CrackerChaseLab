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
        void update(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight,ref CrossSceneData data);
        void draw(SpriteBatch spriteBatch);

        //the onSwitchTo function allows a scene to be initialised before updateing and drawing begins therefore it brings in all data that may be needed to do some initial drawing or updating
        void onSwitchTo(float deltaTime, KeyboardState keys, SceneManager sceneManager, SoundManager soundManager, int inScreenWidth, int inScreenHeight, ref CrossSceneData data);
    }
}
