using YesserEngine;
using YesserEngine.CustomEventArgs;
using YesserEngine.OpenGL.Tests;

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

        [TestMethod]
        public void GameObjectEventsWork()
        {
            var game = new EngineGame(true);
            var gameObj = new TestGameObject();
            game.RegisterGameObject(gameObj);

            game.InvokeLoadContentEvent(ContentEventArgs.Empty);
            game.InvokeUpdateEvent(EventArgs.Empty);
            game.InvokeDrawEvent(DrawEventArgs.Empty);

            Assert.IsTrue(gameObj.InitializeRan);
            Assert.IsTrue(gameObj.LoadContentRan);
            Assert.IsTrue(gameObj.UpdateRan);
            Assert.IsTrue(gameObj.DrawRan);
        }
#endif
    }
}