using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input");
        By GoogleSearIcon = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[2]/div[2]/div[5]/center/input[1]");
        By UnoSquareGoogleResult = By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div[1]/a/h3");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[2]/a");
        By PracticeAreas = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[3]/a");
        By ContactUs = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[9]/a");
        By OurDNA = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[5]/a");
        By Articles = By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[6]/a");

        #endregion
        static void Main(string[] args)
        {

            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            //Wirite the locator for the Google Search Bar
            element = Browser.FindElement(program.GoogleSearchBar);

            // Write Assert True that element is present [Google Search] button

            //Send the text "Unosquare" to the Text Bar
            program.SendText(element, "Unosquare");

            // Click on the Search Button
            element.SendKeys(Keys.Return);

            

            // Locate the first result corresponding to Unosquare and click on the Link
            element = Browser.FindElement(program.UnoSquareGoogleResult);

            // Write Assert Equal [Unosquare: Digital Transformation Services | Agile Staffing ...] vs [Element.text]
            Assert.AreEqual(element.Text, "Unosquare: Digital Transformation Services | Agile Staffing ...");

            program.Click(element);

            // Write Assert True that element is present [Our Dna] menu object
            element = Browser.FindElement(program.OurDNA);
            Assert.IsTrue(element.Displayed);


            // Write Assert True that element is present [Articles & Events] menu object
            element = Browser.FindElement(program.Articles);
            Assert.IsTrue(element.Displayed);

            // Write Assert Equal [Digital transformation solutions] vs [Element.text] h2 ojbect

            //Locate the Service Menu and Click the element
            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            //Locate the Practice Areas Menu and Click the Element
            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            //Locate the Contact Us Menu and Click the Element
            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

            Browser.Quit(); 


        }
    }
}
