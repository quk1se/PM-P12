using App;

namespace UnitTest
{
    [TestClass]               
    public class HelperTest   
    {
        
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

        [TestMethod]
        public void CombineUrlTest()
        {
            Helper helper = new();
            Dictionary<String[], String> testCases = new()
            {
                //{ new[] {"/home", "/index", "/123"}, "/home/index/123"},
                //{ new[] {"/shop/", "/cart", "123/"}, "/shop/cart/123" },
                //{ new[] {"auth/", "logout", "/123/" }, "/auth/logout/123"},
                { new[] {"/home///", "index"}, "/home/index"},
                { new[] { "///home/", "/index"}, "/home/index" },
                { new[] { "home/", "////index"}, "/home/index"},
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(testCase.Value, helper.CombineUrl(testCase.Key[0],
                    testCase.Key[1]), $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}");
            }
        }
    }
}