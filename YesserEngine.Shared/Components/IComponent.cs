using System;
using System.Collections.Generic;
using System.Text;

namespace YesserEngine.Components
{
    public interface IComponent
    {
        GameObject RegisteredIn { get; set; }
        void Initialize();
    }
}
