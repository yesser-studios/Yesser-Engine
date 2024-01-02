using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace YesserEngine.Shared.CustomEventArgs
{
    public class ContentEventArgs : EventArgs
    {
        public static new ContentEventArgs Empty = new ContentEventArgs(null);

        public SpriteBatch SpriteBatch {  get; set; }

        public ContentEventArgs(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }
    }
}
