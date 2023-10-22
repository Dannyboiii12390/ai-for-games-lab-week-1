
using Microsoft.Xna.Framework;
using MonoGameLib.Shapes;

namespace Unit_Tests.MonoGameTests.Shape_Tests
{
    [TestClass]
    public class TestCircle
    {
        [TestMethod]
        public void isInsideTestIn()
        {
            //inside the circle
            Circle circ = new Circle(new Vector2(50, 50), 30, Color.Red);
            bool inside = circ.isInside(new Vector2(50, 50));
            Assert.IsTrue(inside);
        }
        [TestMethod]
        public void isInsideTestOut()
        {
            // outside the circle
            Circle circle = new Circle(new Vector2(50, 50), 30, Color.Red);
            bool inside = circle.isInside(new Vector2(50, 100));
            Assert.IsFalse(inside);
        }
        [TestMethod]
        public void isInsideTestEdge()
        {
            //on the egde of the circle
            Circle circle = new Circle(new Vector2(50, 50), 30, Color.Red);
            bool inside = circle.isInside(new Vector2(50, 80));
            Assert.IsTrue(inside);
        }
    }
}