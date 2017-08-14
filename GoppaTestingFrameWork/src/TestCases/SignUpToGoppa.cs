/*
 * The test case verifies sign up functionality
 *
 */
using NUnit.Framework;
using GoppaTestingFrameWork.src.Lib;

namespace GoppaTestingFrameWork.src.TestCases
{
    class SignUpToGoppa : BaseMethods
    {
        string URL = "https://goppa.benivo.com";
        string FName = "Testing";
        string LName = "Account";
        string Pass = "Test1234";
        string PNumber = "5555555555";

        [SetUp]
        // Setup driver settings
        public void Init()
        {
            SetBaseURL(URL);
        }

        [Test]
        public void SignUp()
        {
            // Open Url
            CreateDriver();
            OpenWelcomePage();
            System.Threading.Thread.Sleep(4000);
            SendValueToElement("xpath", "//input[@name='FirstName']", FName);
            SendValueToElement("xpath", "//input[@name='LastName']", LName);
            ClickOnElement("xpath", "//span[@aria-label='Select box activate']");
            ClickOnElement("xpath", "//span[contains(text(), 'Prefer not to say')]");
            string Email = GenerateString();
            Email = Email + "@gmail.com";
            SendValueToElement("xpath", "//input[@name='Email']", Email);
            SendValueToElement("xpath", "//input[@name='Password']", Pass);
            SendValueToElement("xpath", "//input[@name='Phone']", PNumber);
            ClickElementByJavaScriptExecutor("document.getElementsByClassName('btn btn-default form-control ui-select-toggle')[2]");
            ClickOnElement("xpath", "//span[contains(text(), 'Amsterdam')]");
            ClickOnElement("xpath", "//input[@name='StartDate']");
            ClickOnElement("xpath", "//span[contains(text(), '16')]");
            ClickOnElement("xpath", "//button[@type='submit']");
            System.Threading.Thread.Sleep(10000);
            ClickOnElement("xpath", "//div[@name='country']");
            ClickOnElement("xpath", "//span[contains(text(), 'United States')]");
            for (int i = 0; i < 5; i++)
            {
                ClickOnElement("xpath", "//button[@type='button']");
                System.Threading.Thread.Sleep(4000);
            }
            ClickOnElement("xpath", "//span[contains(text(), '18')]");
            for (int i = 0; i < 5; i++)
            {
                ClickOnElement("xpath", "//button[@type='button']");
                System.Threading.Thread.Sleep(4000);
            }
            System.Threading.Thread.Sleep(10000);
            VerifyElementIsPresent("xpath", "//h2[contains(text(), 'Your step-by-step journey')]");
            ClickOnElement("xpath", "//button[@class='close ng-scope']");
        }

        [TearDown]
        // Quit the webdriver
        public void CloseDriver()
        {
            TearDown(verificationErrors);
        }
    }
}