using Microsoft.VisualStudio.TestTools.UnitTesting;
using YesserEngine.Components;

namespace YesserEngine.OpenGL.Tests
{
    [TestClass]
    public class ComponentTests
    {
        [TestMethod]
        public void ColliderWorks()
        {
            Collider collider1 = new Collider()
            {
                Width = 50,
                Height = 50,
                XOffset = 5,
                YOffset = 5,
            };

            Collider collider2 = new Collider()
            {
                Width = 100,
                Height = 100,
                XOffset = 49,
                YOffset = 49
            };

            Collider collider3 = new Collider()
            {
                Width = 70,
                Height = 90,
                XOffset = 10,
                YOffset = 50
            };

            Collider collider4 = new Collider()
            {
                Width = 70,
                Height = 150,
                XOffset = 30,
                YOffset = 60
            };

            Collider collider5 = new Collider()
            {
                Width = 10,
                Height = 10,
                XOffset = 0,
                YOffset = 0
            };

            Collider collider6 = new Collider()
            {
                Width = 10,
                Height = 10,
                XOffset = 100,
                YOffset = 100
            };

            Assert.IsFalse(collider5.CollidesWith(collider6));

            Assert.IsTrue(collider1.CollidesWith(collider2));

            Assert.IsTrue(collider1.CollidesWith(collider3));
            Assert.IsTrue(collider2.CollidesWith(collider3));

            Assert.IsTrue(collider1.CollidesWith(collider4));
            Assert.IsTrue(collider2.CollidesWith(collider4));
            Assert.IsTrue(collider3.CollidesWith(collider4));
        }
    }
}
