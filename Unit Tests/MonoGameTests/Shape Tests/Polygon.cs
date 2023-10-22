using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Unit_Tests.MonoGameTests.Shape_Tests
{
    [TestClass]
    public class TestPolygon 
    { 
        [TestMethod]
        public void TestIsInsideIn() 
        {
            // inside
            List<Vector2> list = new List<Vector2>();
            list.Add(new Vector2(100, 50));
            list.Add(new Vector2(100, 50));
            list.Add(new Vector2(50,100));

            Polygon poly = new Polygon(new Vector2(50,50), list, Color.Green);
            bool inside = poly.isInside(new Vector2(75,75));

            Assert.IsTrue(inside);



        }
        [TestMethod]
        public void TestIsInsideOut()
        {
            // outside
            List<Vector2> list = new List<Vector2>();
            list.Add(new Vector2(100, 50));
            list.Add(new Vector2(100, 50));
            list.Add(new Vector2(50, 100));

            Polygon poly = new Polygon(new Vector2(50, 50), list, Color.Green);
            bool inside = poly.isInside(new Vector2(150, 75));

            Assert.IsFalse(inside);


        }
        [TestMethod]
        public void TestIsInsideEdge()
        {
            // on the egde
            List<Vector2> list = new List<Vector2>();
            list.Add(new Vector2(100, 50));
            list.Add(new Vector2(100, 50));
            list.Add(new Vector2(50, 100));

            Polygon poly = new Polygon(new Vector2(50, 50), list, Color.Green);
            bool inside = poly.isInside(new Vector2(100, 100));

            Assert.IsTrue(inside);

        }
    }


}
