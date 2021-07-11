using OpenQA.Selenium;

namespace JupiterToys.PageModel
{
    /// <summary>
    /// Base page object
    /// </summary>
    public abstract class BasePageModel : PageModelHelper
    {
        private string PageUrl = "http://jupiter.cloud.planittesting.com";

        /// <summary>
        /// Constructor of Base Page
        /// </summary>
        /// <param name="driver">driver</param>
        public BasePageModel(IWebDriver driver) : base(driver)
        { }


        /// <summary>
        /// Contact Navigation
        /// </summary>
        private IWebElement ContactNav => FindMyElement(By.CssSelector("[id='nav-contact']"));

        /// <summary>
        /// Shop Navigation
        /// </summary>
        private IWebElement ShopNav => FindMyElement(By.CssSelector("[id='nav-shop']"));

        /// <summary>
        /// Cart Navigation
        /// </summary>
        private IWebElement CartNav => FindMyElement(By.CssSelector("[id='nav-cart']"));

        /// <summary>
        /// Get new instance of ContactPageModel
        /// </summary>
        /// <returns>new instance of ContactPageModel</returns>
        protected ContactPageModel GetContactPageModel()
        {
            return new ContactPageModel(this.WebDriver);
        }

        /// <summary>
        /// Get new instance of ShopPageModel
        /// </summary>
        /// <returns>new instance of ShopPageModel</returns>
        protected ShopPageModel GetShopPageModel()
        {
            return new ShopPageModel(this.WebDriver);
        }

        /// <summary>
        /// Get new instance of ShopPageModel
        /// </summary>
        /// <returns>new instance of ShopPageModel</returns>
        protected CartPageModel GetCartPageModel()
        {
            return new CartPageModel(this.WebDriver);
        }

        /// <summary>
        /// Navigate to Jupiter Toys website
        /// </summary>
        public void NavigateToJupiterToys()
        {
            this.WebDriver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Is Page loaded
        /// </summary>
        /// <returns>true when the page loaded</returns>
        public abstract bool IsPageLoaded();

        /// <summary>
        /// Navigate to contact page
        /// </summary>
        public ContactPageModel NavigateToContact()
        {
            WaitThenClick(ContactNav);
            return GetContactPageModel();
        }

        /// <summary>
        /// Navigate to shop page
        /// </summary>
        public ShopPageModel NavigateToShop()
        {
            WaitThenClick(ShopNav);
            return GetShopPageModel();
        }


        /// <summary>
        /// Navigate to cart page
        /// </summary>
        public CartPageModel NavigateToCart()
        {
            WaitThenClick(CartNav);
            return GetCartPageModel();
        }

    }
}
