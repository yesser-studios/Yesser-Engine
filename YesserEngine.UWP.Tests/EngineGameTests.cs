
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YesserStudios.Engine;
using MonoGame.Framework;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace YesserEngine.UWP.Tests
{
    [TestClass]
    public class EngineGameTests
    {
        [TestMethod]
        public void GameStarts()
        {
            var game = XamlGame<EngineGame>.Create(string.Empty, Window.Current.CoreWindow, new SwapChainPanel());

            Assert.IsNotNull(game);
            Assert.IsInstanceOfType(game, typeof(EngineGame));

            game.Exit();
        }
    }
}
