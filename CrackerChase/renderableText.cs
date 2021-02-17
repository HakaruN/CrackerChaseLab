using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CrackerChase
{
    /// <summary>
    /// Provides a renderable text to the screen
    /// </summary>
    class RenderableText
    {
        string mString;
        Vector2 mPosition;
        SpriteFont mMessageFont;
        Color mColour;

        public RenderableText(string stringIn, Vector2 posIn, SpriteFont font, Color col)
        {
            mString = stringIn;
            mPosition = posIn;
            mMessageFont = font;
            mColour = col;
        }

        public void renderText(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(mMessageFont, mString, mPosition, mColour);
        }

        #region position
        public void updatePos(Vector2 newPos)
        {
            mPosition = newPos;
        }
        public Vector2 getPos()
        {
            return mPosition;
        }
        #endregion

        #region colour
        public void updateColour(Color newColour)
        {
            mColour = newColour;
        }
        public Color getColour()
        {
            return mColour;
        }
        #endregion

        #region text
        public void updateText(string newText)
        {
            mString = newText;
        }
        public string getText()
        {
            return mString;
        }
        #endregion

        #region font
        public void updateFont(SpriteFont newFont)
        {
            mMessageFont = newFont;
        }
        public SpriteFont getFont()
        {
            return mMessageFont;
        }
        #endregion
    }
}
