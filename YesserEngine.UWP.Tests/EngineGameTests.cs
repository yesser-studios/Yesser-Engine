
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YesserStudios.Engine;

namespace YesserEngine.UWP.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EngineGameConstructorWorks()
        {
            var game = new EngineGame();

            Assert.IsNotNull(game);
            Assert.IsInstanceOfType(game, typeof(EngineGame));
        }
    }
}
