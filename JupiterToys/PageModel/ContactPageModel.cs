using OpenQA.Selenium;

namespace JupiterToys.PageModel
{
    public class ContactPageModel : BasePageModel
    {
        /// <summary>
        /// Constructor of Contact Page
        /// </summary>
        /// <param name="driver"></param>
        public ContactPageModel(IWebDriver driver) : base(driver)
        { }

        /// <summary>
        /// Submit button
        /// </summary>
        private IWebElement SubmitButton => FindMyElement(By.CssSelector("[class='btn-contact btn btn-primary']"));

        /// <summary>
        /// Forename error message
        /// </summary>
        private IWebElement ForenameError => FindMyElement(By.Id("forename-err"));

        /// <summary>
        /// Email error message
        /// </summary>
        private IWebElement EmailError => FindMyElement(By.Id("email-err"));

        /// <summary>
        /// Message error message
        /// </summary>
        private IWebElement MessageError => FindMyElement(By.Id("message-err"));

        /// <summary>
        /// Forename field
        /// </summary>
        private IWebElement ForenameField => FindMyElement(By.Name("forename"));

        /// <summary>
        /// Email field
        /// </summary>
        private IWebElement EmailField => FindMyElement(By.Name("email"));

        /// <summary>
        /// Message field
        /// </summary>
        private IWebElement MessageField => FindMyElement(By.Name("message"));

        /// <summary>
        /// Alert info
        /// </summary>
        private IWebElement AlertInfo => FindMyElement(By.CssSelector("[class='alert alert-info ng-scope']"));

        /// <summary>
        /// Alert success
        /// </summary>
        private IWebElement AlertSuccess => FindMyElement(By.CssSelector("[class='alert alert-success']"));

        /// <summary>
        /// Alert info
        /// </summary>
        private IWebElement SendingFeedbackPopUp => FindMyElement(By.CssSelector("[class='popup modal hide ng-scope in']"));


        /// <summary>
        /// Check if page loaded
        /// </summary>
        /// <returns>true if page loaded</returns>
        public override bool IsPageLoaded()
        {
            return IsPageLoaded(AlertInfo) && IsPageLoaded(SubmitButton);
        }

        /// <summary>
        /// Click Submit button
        /// </summary>
        public void ClickSubmit() 
        {
            SubmitButton.Click();
        }

        /// <summary>
        /// Is Forename Error displayed
        /// </summary>
        /// <returns>true if element is displayed</returns>
        public bool IsForenameErrorDisplayed() 
        {
            return IsMyElementDisplayed(ForenameError);
        }

        /// <summary>
        /// Is Email Error displayed
        /// </summary>
        /// <returns>true if element is displayed</returns>
        public bool IsEmailErrorDisplayed()
        {
            return IsMyElementDisplayed(EmailError);
        }

        /// <summary>
        /// Is Message Error displayed
        /// </summary>
        /// <returns>true if element is displayed</returns>
        public bool IsMessageErrorDisplayed()
        {
            return IsMyElementDisplayed(MessageError);
        }

        /// <summary>
        /// Enter Forename
        /// </summary>
        /// <param name="forename">string to be input</param>
        public void EnterForename(string forename) 
        {
            ForenameField.SendKeys(forename);
        }

        /// <summary>
        /// Enter Email
        /// </summary>
        /// <param name="email">string to be input</param>
        public void EnterEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        /// <summary>
        /// Enter Message
        /// </summary>
        /// <param name="msg">string to be input</param>
        public void EnterMessage(string msg)
        {
            MessageField.SendKeys(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool WaitForSendingFeedbackToFinished() 
        {
            ImplicitWait(30);
            return SendingFeedbackPopUp.Displayed;
        }

        /// <summary>
        /// Defines if the submission is success
        /// </summary>
        /// <returns>true if submission success</returns>
        public bool IsSubmissionSuccess() 
        {
            return AlertSuccess.Displayed;
        }
    }
}
