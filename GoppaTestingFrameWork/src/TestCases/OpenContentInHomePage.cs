/*
 * The test case verifies functionality of openning the content
 *
 */
using NUnit.Framework;
using GoppaTestingFrameWork.src.Lib;

namespace GoppaTestingFrameWork.src.TestCases
{
    class OpenContentInHomePage : BaseMethods
    {
        string URL = "https://goppa.benivo.com";
        string Login = "anahit.mardoyan@gmail.com";
        string Password = "Test123";

        [SetUp]
        // Setup driver settings
        public void Init()
        {
            SetBaseURL(URL);
            SetCredentials(Login, Password);
        }

        [Test]
        public void OpenContent()
        {
            // Open Url
            CreateDriver();
            OpenWelcomePage();
            // Go to Login page
            ClickOnElement("xpath", "//div[@id='btnDiv']/button");
            System.Threading.Thread.Sleep(4000);
            // Login
            LoginToAccount();
            // Scroll page down
            Scroll();
            System.Threading.Thread.Sleep(4000);
            ClickOnElement("xpath", "//div[@ng-click='goTo(content)']");
            // Make sure the content is opened
            VerifyElementIsPresent("className", "modal-dialog");
        }

        [TearDown]
        // Quit the webdriver
        public void CloseDriver()
        {
            TearDown(verificationErrors);
        }
    }
}
