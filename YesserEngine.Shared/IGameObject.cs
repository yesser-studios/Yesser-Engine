using System;
using System.Collections.Generic;
using System.Text;
using YesserEngine.CustomEventArgs;

namespace YesserEngine
{
    public interface IGameObject
    {
        void Initialize();
        void LoadContent(object sender, ContentEventArgs e);
        void Update(object sender, EventArgs e);
        void Draw(object sender, ContentEventArgs e);
    }
}
