using AutoItX3Lib;
using ImageTypers;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace DemoHide
{
    class Program
    {
        private static readonly AutoItX3Lib.AutoItX3 Auto = new AutoItX3();
        static void Main(string[] args)
        {
            SolveCap();

            //Auto.Run("Notepad.exe");
            //Auto.WinSetState("Untitled - Notepad", "", Auto.SW_SHOW);
            //Auto.WinWait("Untitled - Notepad");
            //Auto.WinActivate("Untitled - Notepad");
            //Auto.Send("Welcome in C#");
            //Thread.Sleep(2000);
            //Auto.WinSetState("Untitled - Notepad", "", Auto.SW_SHOW);
            //Thread.Sleep(2000);
            //Auto.WinClose("Untitled - Notepad");
            //Auto.WinWait("Notepad");
            //Auto.ControlClick("Notepad", "", @"[CLASS:Button; INSTANCE:2]");
        }

        static void SolveCap()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(@"https://www.google.com/recaptcha/api2/demo");

            string sitekey = "6Le-wvkSAAAAAPBMRTvw0Q4Muexq9bi0DJwx_mJ-";

            ImagetypersAPI i = new ImagetypersAPI("38E06080C13C4CCFA78947B2F2CA9A06");

            string captchaId = i.submit_recaptcha("https://www.google.com/recaptcha/api2/demo", sitekey);

            while (i.in_progress(captchaId))
            {
                Thread.Sleep(10000);
            }

            string result = i.retrieve_captcha(captchaId);

            string style = "arguments[0].style[\"display\"] = \"\"";


            #region First Solve
            ((IJavaScriptExecutor)driver).ExecuteScript(style, driver.FindElement(By.Id("g-recaptcha-response")));

            driver.FindElement(By.Id("g-recaptcha-response")).SendKeys(result);
            #endregion

            #region Second Solve
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //js.ExecuteScript("document.getElementById('g-recaptcha-response').innerHTML='" + result + "';");
            #endregion

            driver.FindElement(By.Id("recaptcha-demo-submit")).Click();

        }
    }
}
