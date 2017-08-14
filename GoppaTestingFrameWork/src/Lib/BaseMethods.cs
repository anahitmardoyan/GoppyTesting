using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace GoppaTestingFrameWork.src.Lib
{
    public class BaseMethods
    {
        private static String FIREFOX = "FIREFOX";
        public FirefoxDriverService service;
        public IWebDriver driver;
        protected IWebElement root;
        protected String url;
        protected String login;
        protected String pass;
        protected StringBuilder verificationErrors = new StringBuilder();
        public String path = AppDomain.CurrentDomain.BaseDirectory;
        
        public void SetBaseURL(String url)
        {
            this.url = url;
        }

        public void SetCredentials(String username, String password)
        {
            this.login = username;
            this.pass = password;
        }

        public void CreateDriver()
        {
            try
            {
                //service = FirefoxDriverService.CreateDefaultService(@"C:\Users\Anahit\Documents\Visual Studio 2017\Projects\TestFrameWork\geckodriver-v0.18.0-win32");
                service = FirefoxDriverService.CreateDefaultService(@path);
                driver = new FirefoxDriver(service);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }
            //driver.Manage().Timeouts().ImplicitlyWait(30, Ti);   //ImplicitlyWait(30, TimeUnit.SECONDS);
        }

        public void OpenWelcomePage()
        {
            driver.Navigate().GoToUrl(url);
        }

        protected By GetLocator(String methodName, String searchElement)
        {
            By locator = null;
            switch (methodName)
            {
                case "id":
                    locator = By.Id(searchElement);
                    break;
                case "xpath":
                    locator = By.XPath(searchElement);
                    break;
                case "tagName":
                    locator = By.TagName(searchElement);
                    break;
                case "className":
                    locator = By.ClassName(searchElement);
                    break;
                case "linkText":
                    locator = By.LinkText(searchElement);
                    break;
                case "cssSelector":
                    locator = By.CssSelector(searchElement);
                    break;
                default:
                    locator = By.Id(searchElement);
                    break;
            }

            return locator;
        }

        public void LoginToAccount()
        {
            // Enter login and password
            SendValueToElement("id", "username", login);
            SendValueToElement("id", "password", pass);
            // Login
            ClickOnElement("xpath", "//input[@value='Login']");
            System.Threading.Thread.Sleep(10000);
        }

        public void ClickOnElement(String method, String webElement)
        {
            try
            {
                By locator = GetLocator(method, webElement);
                driver.FindElement(locator).Click();
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }
        }

        public void ClickElementByJavaScriptExecutor(String selectorQuery)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                root = (IWebElement)executor.ExecuteScript("return " + selectorQuery);
                root.Click();
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }
        }

        public void SendValueToElement(String method, String webElement, String value)
        {
            By locator = GetLocator(method, webElement);
            try
            {
                IWebElement textBox = driver.FindElement(locator);
                textBox.Clear();
                textBox.SendKeys(Keys.Insert);
                textBox.SendKeys(value);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }

        }

        public void VerifyElementIsPresent(String method, String webElement)
        {
            try
            {
                System.Threading.Thread.Sleep(4000);
                Boolean isPresent = driver.FindElement(GetLocator(method, webElement)).Displayed;
                Assert.AreEqual(true, isPresent);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }
        }

        public void VerifyTheTextOfElementContains(String method, String Webelement, String partialText)
        {
            try
            {
                Thread.Sleep(2000);
                String actualText = driver.FindElement(GetLocator(method, Webelement)).Text;
                Assert.AreEqual(true, actualText.Contains(partialText));
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }
        }

        public void ScrollToElement(String method, String webElement)
        {
            try
            {
                var element = driver.FindElement(GetLocator(method, webElement));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }
        }

        public void Scroll()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.ToString());
            }
        }

        public String GenerateString()
        {
            // Generate rendom string
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                char c = chars[random.Next(chars.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }


        public void TearDown(StringBuilder error)
        {

            driver.Quit();
            String errorString = error.ToString();
            if (!"".Equals(errorString))
            {
                Assert.Fail(errorString);
            }
        }


    }
}

