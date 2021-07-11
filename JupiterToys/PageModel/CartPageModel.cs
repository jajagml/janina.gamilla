using JupiterToys.JsonModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JupiterToys.PageModel
{
    public class CartPageModel : BasePageModel
    {
        /// <summary>
        /// Constructor of Cart Page
        /// </summary>
        /// <param name="driver"></param>
        public CartPageModel(IWebDriver driver) : base(driver)
        { }

        /// <summary>
        /// Alert Message 
        /// </summary>
        private IWebElement AlertMsg => FindMyElement(By.CssSelector("[class='alert']"));
        
        /// <summary>
        /// Cart Message when there is an ordered item
        /// </summary>
        private IWebElement CartMsg => FindMyElement(By.CssSelector("[class='cart-msg']"));
        
        /// <summary>
        /// Cart Items Panel
        /// </summary>
        private IWebElement CartItemsPanel => FindMyElement(By.CssSelector("[class='table table-striped cart-items']"));
        
        /// <summary>
        /// List of Cart Items from Panel
        /// </summary>
        private IEnumerable<IWebElement> CartItems => CartItemsPanel.FindElements(By.CssSelector("[class='cart-item ng-scope']"));
        
        /// <summary>
        /// Total amount of ordered items from Panel
        /// </summary>
        private IWebElement Total => CartItemsPanel.FindElement(By.CssSelector("[class='total ng-binding']"));
        
        /// <summary>
        /// Check if Cart page loaded
        /// </summary>
        /// <returns>true when the page loaded</returns>
        public override bool IsPageLoaded()
        {
            return IsPageLoaded(AlertMsg) || IsPageLoaded(CartMsg);
        }
        
        /// <summary>
        /// Use to get the items from the Panel
        /// </summary>
        /// <returns>lists of items</returns>
        public List<CartJSON> GetCartItems() 
        {
            var result = new List<CartJSON>();

            var items = CartItems.ToList();

            foreach (var item in items) 
            {
                var td = item.FindElements(By.CssSelector("td"));
                var price = td[1].Text.Replace("$", "");
                var quantity = item.FindElement(By.CssSelector("[name='quantity']")).GetAttribute("value");
                var subTotal = td[3].Text.Replace("$", "");

                result.Add(new CartJSON
                {
                    ItemName = td[0].Text,
                    Price = float.Parse(price),
                    Quantity = Int32.Parse(quantity),
                    SubTotal = float.Parse(subTotal)
                });
            }

            return result;
        }
        
        /// <summary>
        /// Get total amount from the panel
        /// </summary>
        /// <returns>amount</returns>
        public float GetTotal() 
        {
            var total = Total.Text.Replace("Total: ", "");
            return float.Parse(total);
        }
    }
}
