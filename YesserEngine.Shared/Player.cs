using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using YesserEngine.PlayerControl;

namespace YesserEngine
{
    public class Player
    {
        public IPlayerControlType PlayerControlType { get; set; }
    }
}
