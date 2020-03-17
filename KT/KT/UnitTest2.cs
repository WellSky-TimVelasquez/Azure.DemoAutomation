using KT.PageObject;
using NUnit.Framework;

namespace KT
{
    public class AmazonTest : KTTestBase
    {
        [Test]
        public void AmazonSearcgh()
        {
            var Amazon = Application.NewPage<AmazonHome>();
            Amazon.AmazonSearch("Legend Of Zelda");
            Amazon.Actions.CloseBrowser();
            Assert.Pass();
        }
    }
}
