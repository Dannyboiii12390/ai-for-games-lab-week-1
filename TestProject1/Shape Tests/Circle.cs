using MonoGameLib.Shapes;


namespace TestProject1
{
    [TestClass]
    public class TestCircle
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void isInsideTest1()
        {
            Circle circ = new Circle(50, 50, 30);
            bool inside = circ.isInside(new Vector2(50, 50));
            Assert.IsTrue(inside);
        }
        [TestMethod]
        public void isInsideTest2()
        {
            Circle circle = new Circle(50, 50, 30);
            bool inside = circle.isInside(new Vector2(50, 100));
            Assert.IsFalse(inside);
        }
        [TestMethod]
        public void isInsideTest3()
        {
            Circle circle = new Circle(50, 50, 30);
            bool inside = circle.isInside(new Vector2(50, 80));
            Assert.IsTrue(inside);
        }
    }
}