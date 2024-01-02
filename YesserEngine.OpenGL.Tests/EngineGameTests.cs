using YesserEngine;

namespace YesserEngine.Core.Tests
{
    [TestClass]
    public class EngineGameTests
    {
#if DEBUG
        [TestMethod]
        public void GameStarts()
        {
            var game = new EngineGame(true);
            game.Run();
            
            Assert.IsNotNull(game);
            Assert.IsInstanceOfType<EngineGame>(game);
        }
#endif
    }
}