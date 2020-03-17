using Flux.Web;
using KT.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.PageObject
{
    public class AmazonHome : KTPageBase
    {
        #region locators
        private readonly By _btnAddtoCart = By.XPath("/html//input[@id='add-to-cart-button']");
        private readonly By _btnConttoCart = By.XPath("(/html//input[@id='smartShelfAddToCartNative'])[1]");
        private readonly By _btnSearch = By.XPath("//input[@value='Go']");
        private readonly By _ddpDept = By.XPath("//div[@id='nav-search-dropdown-card']/div[@class='nav-search-scope nav-sprite']");
        private readonly By _fldSearch = By.XPath("//input[@id='twotabsearchtextbox']");
        private readonly By _lnkLOZ = By.XPath("//img[@alt='The Legend of Zelda: Breath of the Wild - Nintendo Switch']");
        private readonly By _optVideoGames = By.XPath("//select[#'searchDropdownBox']/option[@innertext='Video Games']");
        #endregion

        /// <summary>
        /// Open and Search in Amazon
        /// </summary>
        /// <param name="text"></param>
        public void AmazonSearch(String text)
        {
            Actions.NavigateToUrl(WebEnvironment.AppSettings["AmazonUrl"]);
            Waits.WaitForPageLoad();
            
            Actions.Click(_ddpDept);
            Waits.Equals(3000);

            ///Issue: unsure how to scroll withing a dropdown with C#...
            //Actions.Click(_optVideoGames);
            ///...end

            Actions.SendKeys(_fldSearch, text);
            Actions.Click(_btnSearch);
            Waits.WaitForPageLoad();

            Actions.Click(_lnkLOZ);
            Waits.WaitForPageLoad();

            Actions.Click(_btnAddtoCart);
            Waits.Equals(3000);

            Actions.Click(_btnConttoCart);
        }
    }
}
