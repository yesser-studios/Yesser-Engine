using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace YesserEngine.CustomEventArgs
{
    public class ContentEventArgs : EventArgs
    {
        public static new ContentEventArgs Empty = new ContentEventArgs(null);

        public ContentManager Content { get; set; }

        public ContentEventArgs(ContentManager content)
        {
            Content = content;
        }
    }
}
