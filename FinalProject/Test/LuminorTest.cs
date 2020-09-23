using FinalProject.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    class LuminorTest
    {
        private static LuminorPage _luminorPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //IWebElement popup = driver.FindElement(By.Id("edit-agree"));
            //popup.Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _luminorPage = new LuminorPage(driver);

        }
        [TestCase("100000", "50000", "2.5", "20", "265", TestName = "Test with house price 100000, down payment 50000, interest rate 2.5, loan term 20 and result 265 parameters")]
        [TestCase("100000", "20000", "1.8", "30", "288", TestName = "Test with house price 100000, down payment 20000, interest rate 1.8, loan term 30 and result 288 parameters")]
       
        public static void TestLuminorLoan(string price, string downPayment, string interestRate, string loanTerm, string result)
        {
            _luminorPage.InsertHousePrice(price);
            _luminorPage.InsertDownPayment(downPayment);
            _luminorPage.EditInterestRate(interestRate);
            _luminorPage.EditLoanTerm(loanTerm);     
        }
    }
}
