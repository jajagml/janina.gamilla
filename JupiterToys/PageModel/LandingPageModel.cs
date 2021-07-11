using OpenQA.Selenium;

namespace JupiterToys.PageModel
{
    /// <summary>
    /// Landing Page model
    /// </summary>
    public class LandingPageModel : BasePageModel
    {
        /// <summary>
        /// Constructor of Landing Page
        /// </summary>
        /// <param name="driver">driver</param>
        public LandingPageModel(IWebDriver driver) : base(driver)
        { }

        /// <summary>
        /// Jupiter Toys Header
        /// </summary>
        private IWebElement JupiterToysHeader => FindMyElement(By.CssSelector("h1"));

        /// <summary>
        /// Check if page loaded
        /// </summary>
        /// <returns>true if page loaded</returns>
        public override bool IsPageLoaded()
        {
            return IsPageLoaded(JupiterToysHeader);
        }

    }
}
