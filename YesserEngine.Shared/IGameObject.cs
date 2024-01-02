using System;
using System.Collections.Generic;
using System.Text;
using YesserEngine.Shared.CustomEventArgs;

namespace YesserEngine.Shared
{
    public interface IGameObject
    {
        void Initialize();
        void LoadContent(object sender, ContentEventArgs e);
        void Update(object sender, EventArgs e);
        void Draw(object sender, ContentEventArgs e);
    }
}
