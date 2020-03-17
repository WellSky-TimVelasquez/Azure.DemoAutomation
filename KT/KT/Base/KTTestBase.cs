using Flux.Core;
using Flux.Web;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace KT
{
    public class KTTestBase : WebTestBase
    {
        /// <summary>
        /// This setup runs automatically before each test in the suite.
        /// </summary>
        [SetUp]
        public void SetupPerTest()
        {
            string browserName = string.Empty;
            string defaultDownloadFolder = string.Empty;
            string projectDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                browserName = WebEnvironment.AppSettings["BrowserType"].ToLower();
                defaultDownloadFolder = WebEnvironment.AppSettings["DefaultDownloadFolder"].ToLower();
                WebEnvironment env = new WebEnvironment();

                if (string.IsNullOrWhiteSpace(defaultDownloadFolder))
                {
                    env.InitializeDriver(browserName,projectDirectoryPath);
                }
                else
                {
                    switch (browserName)
                    {
                        case "chrome":
                            var driverOptions = new ChromeOptions();
                            driverOptions.AddUserProfilePreference("download.default_directory", defaultDownloadFolder);
                            env.InitializeDriverWithOptions(browserName, null, driverOptions, projectDirectoryPath);
                            //GlobalData.Set(GlobalDataKeys.DOWNLOAD_FOLDER, defaultDownloadFolder);
                            break;
                        //case "saucelabs":
                        //    if (WebEnvironment.AppSettings["BrowserType"].ToLower() == "saucelabs")
                        //    {
                        //        env.InitializeDriver(browserName);
                        //        string TestName = TestContext.CurrentContext.Test.Name;
                        //        string BuildName = TestContext.CurrentContext.Test.Properties.Get("Category").ToString();
                        //        ((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript("sauce:job-name=" + TestName);
                        //        ((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript("sauce:job-build=" + BuildName);
                        //    }
                        //    break;
                        case "ie":
                            env.InitializeDriver(browserName);
                            break;
                        default:
                            Log.Info("Error intializing: " + browserName);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                CustomExceptionHandler.CustomException(e, "Error occurred while trying to launch '" + browserName + "'.");
            }
        }

        /// <summary>
        /// This TearDown runs automatically after each test in the suite.
        /// </summary>
        [TearDown]
        public void TearDownPerTest()
        {
            // If you want to run scripts on saucelabs use below code inside TearDownPerTest()
            //if (WebEnvironment.AppSettings["BrowserType"].ToLower() == "saucelabs")
            //{
            //    bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            //    ((IJavaScriptExecutor)WebEnvironment.Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            //}
        }
    }
}
