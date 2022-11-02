using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_1;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int resultado = Product.Gain(6, 4);
            Assert.AreEqual(24, resultado);
        }
    }
}