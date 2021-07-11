using JupiterToys.JsonModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JupiterToys.PageModel
{
    public class ShopPageModel : BasePageModel
    {
        /// <summary>
        /// Constructor of Shop Page
        /// </summary>
        /// <param name="driver"></param>
        public ShopPageModel(IWebDriver driver) : base(driver)
        { }

        /// <summary>
        /// Products Panel
        /// </summary>
        private IWebElement ProductsPanel => FindMyElement(By.CssSelector("[class='products ng-scope']"));

        /// <summary>
        /// List of products from the panel
        /// </summary>
        private IEnumerable<IWebElement> Products => ProductsPanel.FindElements(By.CssSelector("[class='product ng-scope']"));

        /// <summary>
        /// Verify if Shop Page is loaded
        /// </summary>
        /// <returns>true if page loaded</returns>
        public override bool IsPageLoaded()
        {
            return IsPageLoaded(ProductsPanel);
        }

        /// <summary>
        /// Buy product by Name
        /// </summary>
        /// <param name="item">item property</param>
        public void BuyProduct(CartJSON item) 
        {
            var products = Products.ToList();
            var count = item.Quantity;

            foreach (var prod in products)
            {
                if (prod.Text.Contains(item.ItemName)) 
                {
                    var btn = prod.FindElement(By.CssSelector("[class='btn btn-success']"));
                    for (var i = 0; i < count; i++) 
                    {
                        btn.Click();
                    }
                    break;
                }
            }
        }
    }
}
