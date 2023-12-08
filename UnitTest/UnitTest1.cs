using App;

namespace UnitTest
{
    [TestClass]               
    public class HelperTest   
    {
        [TestMethod]
        //Test method to change symbols with html encoding  
        public void TestEscapeHtml()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.AreEqual("&lt;html&gt;&lt;head&gt;&lt;/head&gt;&lt;body&gt;&lt;/body&gt;&lt;/html&gt;", helper.HtmlTest("<html><head></head><body></body></html>"));
        }


        [TestMethod]
        //Test method to check for null in html string
        public void TestEscapeHtmlEx()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");

            var ex = Assert.ThrowsException<ArgumentException>(
                () => helper.HtmlTest(null!));
            Assert.AreEqual("Argument 'html' is null", ex.Message);
        }


        [TestMethod]
        //Test method to check for the presence of an attribute in an html line
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


        [TestMethod]
        //Test method to comparison modify string
        public void EllipsisTest()  
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.AreEqual(
                "He...",
                helper.Ellipsis("Hello, World", 5));
            Assert.AreEqual(
                "Hel...",
                helper.Ellipsis("Hello, World", 6));
            Assert.AreEqual(
                "Test...",
                helper.Ellipsis("Test String", 7));
        }


        [TestMethod]
        //Test method to check if strings are concatenated correctly
        public void CombineUrlTest()
        {
            Helper helper = new();
            Dictionary<String[], String> testCases = new()
            {
                //{ new[] {"/home", "/index", "/123"}, "/home/index/123"},
                //{ new[] {"/shop/", "/cart", "123/"}, "/shop/cart/123" },
                //{ new[] {"auth/", "logout", "/123/" }, "/auth/logout/123"},
                { new[] {"/home///", "index"}, "/home/index/null"},
                { new[] { "///home/", "/index"}, "/home/index/null" },
                { new[] { "home/", "////index"}, "/home/index/null"},
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(testCase.Value, helper.CombineUrl(testCase.Key[0],
                    testCase.Key[1]), $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}");
            }
        }

        [TestMethod]
        //Test method for checking matches in a modified string of words
        public void EllipsisExceptionTest()
        {
            Helper helper = new();
            var ex = Assert.ThrowsException<ArgumentNullException>( () => helper.Ellipsis(null!, 1));
            Assert.IsTrue(
                ex.Message.Contains("input"),
                "Exception message shoud contain 'input' substring"
                );
            var ex2 = Assert.ThrowsException<ArgumentException>(
                         () => helper.Ellipsis("2342344", 2)
                     );
            Assert.IsTrue(ex2.Message.Contains("len"));

            var ex3 = Assert.ThrowsException<ArgumentOutOfRangeException>(
                         () => helper.Ellipsis("1234", 6)
                     );
            Assert.IsTrue(ex3.Message.Contains("len"));
        }
    }
}