using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Page
{
    class LuminorPage: BasePage
    {
        //private IWebElement loan = Driver.FindElement(By.CssSelector("#menu > div.menu__mobile-wrapper > ul.menu__list.menu__list--left.clearfix > li:nth-child(3) > a"));
        private IWebElement _dealamount => Driver.FindElement(By.Id("edit-deal-amount"));
        private IWebElement _downPayment => Driver.FindElement(By.Id("edit-down-payment"));
        private IWebElement _interestRate => Driver.FindElement(By.Id("edit-interest"));
        private IWebElement _loanTerm => Driver.FindElement(By.Id("edit-loan-term"));

        private IWebElement monthlyPayment => Driver.FindElement(By.CssSelector("edit-loan-term"));
        private IWebElement getResult => Driver.FindElement(By.CssSelector("#edit-summary > p.summary__primary > span"));

        private IWebElement _annuity => Driver.FindElement(By.Id("edit-repayment-type-annuity"));



        public LuminorPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = "https://www.luminor.lt/lt/privatiems/busto-paskolos-skaiciuokle";
        }
        
       
        public void InsertHousePrice( string price)
        {
            _dealamount.Clear();
            _dealamount.SendKeys(price);
        }
        public void InsertDownPayment(string downPayment)
        {
            _downPayment.Clear();
            _downPayment.SendKeys(downPayment);
        }
        public void EditInterestRate(string interestRate)
        {
            _interestRate.Clear();
            _interestRate.SendKeys(interestRate);
        }
        public void EditLoanTerm(string loanTerm)
        {
            _loanTerm.Clear();
            _loanTerm.SendKeys(loanTerm);
        }
        public  LuminorPage CheckAuto(bool Checked)
        {
            if (_annuity.Selected != Checked)
                _annuity.Click();
            return this;           
        }
        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            wait.Until(d => d.FindElement(By.CssSelector("#edit-summary > p.summary__primary > span")).Displayed);
        }
        public LuminorPage CheckResult(string result)
        {
            WaitForResult();
            Assert.IsTrue(getResult.Text.Contains(result), "Results are not the same");
            return this;
        }
    }
}
