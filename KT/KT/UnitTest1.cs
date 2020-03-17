using KT.PageObject;
using NUnit.Framework;

namespace KT
{
    public class GoogleTest : KTTestBase
    {
        [Test]
        public void GoogleSearch()
        {
            var Google = Application.NewPage<GoogleHome>();
            Google.GoogleSearch("Taco");
            Google.Actions.CloseBrowser();
            Assert.Pass();
        }
    }
}