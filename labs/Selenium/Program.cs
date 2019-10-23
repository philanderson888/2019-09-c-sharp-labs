using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Url = "https://www.bbc.co.uk";

            Console.WriteLine($"Page Source is {driver.PageSource.Length}");
            Console.WriteLine($"Driver is {driver.Url}");
            Console.WriteLine($"Page Title is {driver.Title}");
        }
    }

    class SeleniumTests
    {
        IWebDriver driver;

        [SetUp]
        public void Initialise()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void RunTest()
        {
            driver.Url = "https://www.bbc.co.uk";
            //  Console.WriteLine($"Page Source is {driver.PageSource}");
            Console.WriteLine($"Page Source is {driver.PageSource.Length}");

            Console.WriteLine($"Driver is {driver.Url}");
            Console.WriteLine($"Page Title is {driver.Title}");
            driver.Navigate().GoToUrl("https://www.intel.com");
            Thread.Sleep(1500);
            driver.Navigate().Back();
            Thread.Sleep(1500);
            driver.Navigate().Forward();
            Thread.Sleep(1500);
            driver.Navigate().Back();
            Thread.Sleep(1500);
            driver.Navigate().Refresh();
            Thread.Sleep(1500);

            driver.Url = "http://automationpractice.com/index.php";
            var element = driver.FindElement(By.ClassName("login"));
            element.Click();
            Thread.Sleep(1500);



            element = driver.FindElement(By.Name("email"));
            element.Clear();
            element.SendKeys("panderson@spartaglobal.com");



            element = driver.FindElement(By.Name("passwd"));
            element.Clear();
            element.SendKeys("a@jm67ZuxywGb8b");
            Thread.Sleep(1500);

            element = driver.FindElement(By.Name("SubmitLogin"));
            element.Click();
            Thread.Sleep(1500);
        }

        [TearDown]
        public void EndTest()
        {
            System.Threading.Thread.Sleep(5000);
            driver.Close();
        }


    }
}
