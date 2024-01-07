using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesserEngine.CustomEventArgs;

namespace YesserEngine.OpenGL.Tests
{
    internal class TestGameObject : IGameObject
    {
        public bool DrawRan = false;
        public bool InitializeRan = false;
        public bool LoadContentRan = false;
        public bool UpdateRan = false;

        public EngineGame? RegisteredIn { get; set; }

        public void Draw(object sender, DrawEventArgs e)
        {
            DrawRan = true;
        }

        public void Initialize()
        {
            InitializeRan = true;
        }

        public void LoadContent(object sender, ContentEventArgs e)
        {
            LoadContentRan = true;
        }

        public void Update(object sender, EventArgs e)
        {
            UpdateRan = true;
        }
    }
}
