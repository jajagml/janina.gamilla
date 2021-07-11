using JupiterToys.JsonModel;
using JupiterToys.PageModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JupiterToys.Test
{
    [TestClass]
    public class TestCases : BaseTest
    {
        private LandingPageModel homePage;
        private ContactPageModel contactPage;
        private ShopPageModel shopPage;
        private CartPageModel cartPage;

        [TestMethod]
        public void TestCase1()
        {
            homePage = new LandingPageModel(this.WebDriver);

            // 1. From the home page go to contact page
            homePage.NavigateToJupiterToys();
            homePage.IsPageLoaded();
            contactPage = homePage.NavigateToContact();
            contactPage.IsPageLoaded();

            // 2. Click submit button
            contactPage.ClickSubmit();

            // 3. Validate errors
            Assert.IsTrue(contactPage.IsForenameErrorDisplayed());
            Assert.IsTrue(contactPage.IsEmailErrorDisplayed());
            Assert.IsTrue(contactPage.IsMessageErrorDisplayed());

            // 4. Populate mandatory fields
            contactPage.EnterForename("Jaja");
            contactPage.EnterEmail("Jaja@test.com");
            contactPage.EnterMessage("Jaja test");

            // 5. Validate errors are gone                 
            Assert.IsFalse(contactPage.IsForenameErrorDisplayed());
            Assert.IsFalse(contactPage.IsEmailErrorDisplayed());
            Assert.IsFalse(contactPage.IsMessageErrorDisplayed());

        }

        [TestMethod]
        public void TestCase2() 
        {
            homePage = new LandingPageModel(this.WebDriver);

            //1.From the home page go to contact page
            homePage.NavigateToJupiterToys();
            homePage.IsPageLoaded();
            contactPage = homePage.NavigateToContact();
            contactPage.IsPageLoaded();

            //2.Populate mandatory fields
            contactPage.EnterForename("Jaja");
            contactPage.EnterEmail("Jaja@test.com");
            contactPage.EnterMessage("Jaja test");

            //3.Click submit button
            contactPage.ClickSubmit();
            contactPage.WaitForSendingFeedbackToFinished();

            //4.Validate successful submission message
            Assert.IsTrue(contactPage.IsSubmissionSuccess());
        }

        [TestMethod]
        public void TestCase3() 
        {
            homePage = new LandingPageModel(this.WebDriver);
            
            //1.From the home page go to shop page
            homePage.NavigateToJupiterToys();
            homePage.IsPageLoaded();
            shopPage = homePage.NavigateToShop();

            //2.Click buy button 2 times on “Funny Cow”
            var testData = TestData3();
            shopPage.BuyProduct(testData[0]);

            //3.Click buy button 1 time on “Fluffy Bunny”
            shopPage.BuyProduct(testData[1]);

            //4.Click the cart menu
            cartPage = shopPage.NavigateToCart();
            cartPage.IsPageLoaded();

            //5.Verify the items are in the cart
            var results = cartPage.GetCartItems();

            foreach (var item in testData) 
            {
                Assert.IsTrue(results.Any(n => n.ItemName == item.ItemName));
                Assert.IsTrue(results.Any(n => n.Quantity == item.Quantity));
            }

        }

        [TestMethod]
        public void TestCase4() 
        {
            homePage = new LandingPageModel(this.WebDriver);
            homePage.NavigateToJupiterToys();
            homePage.IsPageLoaded();
            shopPage = homePage.NavigateToShop();

            //1.Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
            var testData = TestData4();
            shopPage.BuyProduct(testData[0]);
            shopPage.BuyProduct(testData[1]);
            shopPage.BuyProduct(testData[2]);

            //2.Go to the cart page
            cartPage = shopPage.NavigateToCart();
            cartPage.IsPageLoaded();

            //3.Verify the price for each product
            //4.Verify that each product’s sub total = product price * quantity
            var results = cartPage.GetCartItems();

            foreach (var item in testData)
            {
                Assert.IsTrue(results.Any(n => n.Price == item.Price));
                var itemQuantity = Math.Round(item.Price * item.Quantity, 2);
                Assert.IsTrue(results.Any(n => n.SubTotal == (float)itemQuantity));
            }

            //5.Verify that total = sum(sub totals)
            float total = 0;
            for (var i =0; i < testData.Count; i++) 
            {
                var itemQuantity = Math.Round(results[i].Price * results[i].Quantity, 2);
                total += (float)itemQuantity;
            }

            Assert.AreEqual(total, cartPage.GetTotal());
        }

        //2 Funny Cow, 1 Fluffy Bunny
        private List<CartJSON> TestData3()
        {
            return new List<CartJSON>()
            {
                new CartJSON
                {
                    ItemName = "Funny Cow",
                    Quantity = 2
                },
                new CartJSON
                {
                    ItemName = "Fluffy Bunny",
                    Quantity = 2
                }
            };
        }

        //2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
        private List<CartJSON> TestData4()
        {
            return new List<CartJSON>()
            {
                new CartJSON
                {
                    ItemName = "Stuffed Frog",
                    Quantity = 2,
                    Price = 10.99f
                },
                new CartJSON
                {
                    ItemName = "Fluffy Bunny",
                    Quantity = 5,
                    Price = 9.99f
                },
                new CartJSON
                {
                    ItemName = "Valentine Bear",
                    Quantity = 3,
                    Price = 14.99f
                }
            };
        }
    }
}
