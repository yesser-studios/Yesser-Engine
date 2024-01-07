using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace YesserEngine.CustomEventArgs
{
    public class DrawEventArgs : EventArgs
    {
        public static new DrawEventArgs Empty = new DrawEventArgs(null);

        public SpriteBatch SpriteBatch {  get; set; }

        public DrawEventArgs(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }
    }
}
