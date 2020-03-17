using Flux.Web;
using KT.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.PageObject
{
    public class GoogleHome : KTPageBase
    {
        #region locators
        private readonly By _fld_Search = By.XPath("//input[@name='q']");
        private readonly By _lnk25thResult = By.XPath("//a[@aria-label='Page 25']");
        private readonly By _lnkFifthValue = By.XPath("//div[@id='rso']/div[5]");
        private readonly By _lnkNext = By.XPath("//a[@id='pnnext']/span[.='Next']");
        #endregion

        /// <summary>
        /// Open and Search in Google
        /// </summary>
        /// <param name="text"></param>
        public void GoogleSearch(String text)
        {
            Actions.NavigateToUrl(WebEnvironment.AppSettings["GoogleUrl"]);
            Actions.SendKeys(_fld_Search, text);
            Actions.PressKey(Keys.Enter);
            Waits.WaitForPageLoad();
            if (Actions.IsAlertPresent())
            {
                Actions.AcceptAlert();
            }
            Actions.Click(_lnkFifthValue);
            Waits.WaitForPageLoad();
            Actions.NavigateToUrl(WebEnvironment.AppSettings["GoogleUrl"]);
            Actions.SendKeys(_fld_Search, text);
            Actions.PressKey(Keys.Enter);
            Waits.WaitForPageLoad();
            if (Actions.IsAlertPresent())
            {
                Actions.AcceptAlert();
            }

            for (int it = 0; it <= 19;  it++ )
            {
                Actions.ScrollToBottom();
                Actions.Click(_lnkNext);
                Waits.WaitForPageLoad();
            }

            Actions.ScrollToBottom();
            Actions.Click(_lnk25thResult);
            Waits.WaitForPageLoad();
        }
    }
}