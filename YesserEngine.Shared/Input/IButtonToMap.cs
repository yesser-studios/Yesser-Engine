using System;
using System.Collections.Generic;
using System.Text;

namespace YesserEngine
{
    public interface IButtonToMap
    {
        Player ConnectedPlayer { get; set; }

        bool IsDown();
    }
}
