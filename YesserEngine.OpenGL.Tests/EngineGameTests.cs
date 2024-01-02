using YesserEngine;

namespace YesserEngine.Core.Tests
{
    [TestClass]
    public class EngineGameTests
    {
        [TestMethod]
        public void GameStarts()
        {
            using var game = new EngineGame
            game.Run();
        }
    }
}