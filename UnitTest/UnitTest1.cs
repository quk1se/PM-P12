using App;

namespace UnitTest
{
    [TestClass]               
    public class HelperTest   
    {
        [TestMethod]
        public void EllipsisTest()  
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            //Assert.AreEqual(
            //    "He...",
            //    helper.Ellipsis("Hello, World", 5));
            //Assert.AreEqual(
            //    "Hel...",
            //    helper.Ellipsis("Hello, World", 6));
            //Assert.AreEqual(
            //    "Test...",
            //    helper.Ellipsis("Test String", 7));


            //   DOTS TEST
            //Assert.AreEqual("test.", helper.Dots("test", 5));
            Assert.AreEqual("test", helper.Dots("test", 5));
        }
    }
}