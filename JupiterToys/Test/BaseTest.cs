using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JupiterToys.Test
{
    /// <summary>
    /// Base Test
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// WebDriver
        /// </summary>
        protected IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Set up the chrome options
        /// </summary>
        /// <returns>driver</returns>
        private IWebDriver GetWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-extensions");
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);

            return driver;
        }

        [TestInitialize]
        public void Init()
        {
            this.WebDriver = GetWebDriver();

        }

        [TestCleanup]
        public void CleanUp()
        {
            this.WebDriver.Close();

        }
    }
}
