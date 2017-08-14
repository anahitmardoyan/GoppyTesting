/*
 * The test case verifies login functionality
 *
 */
using NUnit.Framework;
using GoppaTestingFrameWork.src.Lib;

namespace GoppaTestingFrameWork.src.TestCases
{
    class LoginToGoppa : BaseMethods
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
        public void LogIn()
        {
            // Open Url
            CreateDriver();
            OpenWelcomePage();
            VerifyElementIsPresent("xpath", "//div[@id='btnDiv']/button");
            // Go to Login page
            ClickOnElement("xpath", "//div[@id='btnDiv']/button");
            System.Threading.Thread.Sleep(4000);
            // Login
            LoginToAccount();
            // Make sure you are successfully logged in
            VerifyElementIsPresent("id", "fcUser");
        }

        [TearDown]
        // Quit the webdriver
        public void CloseDriver()
        {
            TearDown(verificationErrors);
        }
    }
}
