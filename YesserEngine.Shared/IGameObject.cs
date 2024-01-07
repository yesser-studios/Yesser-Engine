using System;
using System.Collections.Generic;
using System.Text;
using YesserEngine.Components;
using YesserEngine.CustomEventArgs;

namespace YesserEngine
{
    public interface IGameObject
    {
        EngineGame RegisteredIn { get; set; }
        void Initialize();
        void LoadContent(object sender, ContentEventArgs e);
        void Update(object sender, EventArgs e);
        void Draw(object sender, DrawEventArgs e);
    }
}
