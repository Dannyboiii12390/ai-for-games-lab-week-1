using MonoGameLib.Shapes;
using Microsoft.Xna.Framework;


namespace Unit_Tests.MonoGameTests.Shape_Tests
{
    [TestClass]
    public class TestTriangle
    {
        [TestMethod]
        public void isInsideTestIn()
        {
            //inside
            Triangle tri = new Triangle(new Vector2(50,50), new Vector2(100,50), new Vector2(75,100), Color.Green);
            bool inside = tri.isInside(new Vector2(75, 75));
            Assert.IsTrue(inside);



        }
        [TestMethod]
        public void isInsideTestOut() 
        {
            //outside
            Triangle tri = new Triangle(new Vector2(50, 50), new Vector2(100, 50), new Vector2(75, 100), Color.Green);
            bool inside = tri.isInside(new Vector2(100, 100));
            Assert.IsFalse(inside);


        }

        [TestMethod]
        public void isInsideTestEdge() 
        {
            //on edge
            Triangle tri = new Triangle(new Vector2(50, 50), new Vector2(100, 50), new Vector2(75, 100), Color.Green);
            bool inside = tri.isInside(new Vector2(75, 50));
            Assert.IsTrue(inside);

        }
    }
}
