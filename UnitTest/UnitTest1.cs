using App;

namespace UnitTest
{
    [TestClass]               
    public class HelperTest   
    {
        [TestMethod]
        public void TestEscapeHtml()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.AreEqual("&lt;html&gt;&lt;head&gt;&lt;/head&gt;&lt;body&gt;&lt;/body&gt;&lt;/html&gt;", helper.HtmlTest("<html><head></head><body></body></html>"));
        }
        [TestMethod]
        public void TestEscapeHtmlEx()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");

            var ex = Assert.ThrowsException<ArgumentException>(
                () => helper.HtmlTest(null!));
            Assert.AreEqual("Argument 'html' is null", ex.Message);
        }
        [TestMethod]
        public void ContainsAttributesTest()
        {
            Helper helper = new();
            Assert.IsTrue(helper.ContainsAttributes("<div style=\"\"></div>"));
            Assert.IsTrue(helper.ContainsAttributes("<i style=\"code\" ></div>"));
            Assert.IsTrue(helper.ContainsAttributes("<i style=\"code\"  required ></div>"));
            Assert.IsTrue(helper.ContainsAttributes("<i style='code'  required></div>"));
            Assert.IsTrue(helper.ContainsAttributes("<i required style=\"code\" ></div>"));
            Assert.IsTrue(helper.ContainsAttributes("<i required style=\"code\"></div>"));
            Assert.IsTrue(helper.ContainsAttributes("<img onload=\"dangerCode()\" src=\"puc.png\"/>"));
            Assert.IsTrue(helper.ContainsAttributes("<img width=100 />"));
            Assert.IsFalse(helper.ContainsAttributes("<div></div>"));
            Assert.IsFalse(helper.ContainsAttributes("<div ></div>"));
            Assert.IsFalse(helper.ContainsAttributes("<br/>"));
            Assert.IsFalse(helper.ContainsAttributes("<br />"));
            Assert.IsFalse(helper.ContainsAttributes("<div required ></div>"));
            Assert.IsFalse(helper.ContainsAttributes("<div required></div>"));
            Assert.IsTrue(helper.ContainsAttributes("<img      width=500    required   />"));
        }
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