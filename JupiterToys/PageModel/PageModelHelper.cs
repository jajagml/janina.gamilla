using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace JupiterToys.PageModel
{
    public abstract class PageModelHelper
    {
        protected IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Constructor of PageModelHelper
        /// </summary>
        /// <param name="driver">driver</param>
        public PageModelHelper(IWebDriver driver)
        {
            this.WebDriver = driver;
        }

        /// <summary>
        /// Use to have implicit wait
        /// </summary>
        /// <param name="ms">milliseconds</param>
        protected void ImplicitWait(int ms = 3000)
        {
            this.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ms);
        }

        /// <summary>
        /// Use to wait certain element
        /// </summary>
        /// <param name="element">element</param>
        /// <param name="needImplicit">need implicit</param>
        /// <param name="ms">milliseconds</param>
        /// <returns></returns>
        protected bool ExplicitWait(IWebElement element, bool needImplicit = false, int ms = 1000)
        {
            WebDriverWait explicitWait = new WebDriverWait(this.WebDriver, TimeSpan.FromMilliseconds(ms));

            if (needImplicit)
                ImplicitWait();

            try
            {
                explicitWait.Until(x => element.Displayed);
                return true;
            }
            catch(NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the Page loaded
        /// </summary>
        /// <param name="el">element</param>
        /// <returns>true if page loaded</returns>
        protected bool IsPageLoaded(IWebElement el) 
        {
            return IsMyElementDisplayed(el);
        }

        /// <summary>
        /// Wait the element then click
        /// </summary>
        /// <param name="el">element to click</param>
        protected void WaitThenClick(IWebElement el)
        {
            ExplicitWait(element: el, ms: 5000);
            el.Click();
        }

        /// <summary>
        /// FindElement with wait
        /// </summary>
        /// <param name="el">element</param>
        /// <returns>IWebElement</returns>
        protected IWebElement FindMyElement(By el)
        {
            IWebElement element;
            ImplicitWait(10);
            try
            {
                var wait = new WebDriverWait(this.WebDriver, new TimeSpan(0, 0, 15));
                element = wait.Until(condition =>
                {
                    try
                    {
                        var myElement = this.WebDriver.FindElement(el);
                        return myElement;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                });

            }
            catch
            {
                return null;
            }

            return element;
        }

        /// <summary>
        /// Check if the element is displayed
        /// </summary>
        /// <param name="el">element</param>
        /// <returns>true when element is diplayed</returns>
        protected bool IsMyElementDisplayed(IWebElement el)
        {
            if (el != null)
                return el.Displayed;
            return false;
        }
    }
}
