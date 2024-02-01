using System;
using System.Collections.Generic;
using System.Text;

namespace YesserEngine.Input
{
    public abstract class GamepadButton : IButtonToMap
    {
        public Player ConnectedPlayer { get; set; }

        /// <summary>
        /// Override. <br></br>
        /// Return true if a check for a button down of <see cref="Microsoft.Xna.Framework.Input.GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex)"/> is true.du
        /// </summary>
        /// <returns></returns>
        public abstract bool IsDown();
    }
}
