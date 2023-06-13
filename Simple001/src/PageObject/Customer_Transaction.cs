using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Simple001.src.PageObject
{
    public class Customer_Transaction
    {
        private IWebDriver driver;

        public Customer_Transaction(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "userSelect")]
        public IWebElement SelectCustomerAccountDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Login']")]
        public IWebElement LoginButton { get; set; }

        //A dropdown to choose an item = 1003
        [FindsBy(How = How.Id, Using = "accountSelect")]
        public IWebElement CustomerPageDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Deposit']")]
        public IWebElement DepositButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Withdrawl']")]
        public IWebElement WithdrawButton { get; set; }

        //This input field applies to deposit and withdrawal execution
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='amount']")]
        public IWebElement AmountInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[normalize-space(text())='Deposit'])[2]")]
        public IWebElement AmountToBeDepositButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Withdraw']")]
        public IWebElement AmountToBeWithdrawButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='center']/strong[2]")]
        public IWebElement CustomerBalanceText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[normalize-space(text())='Deposit Successful']")]
        public IWebElement depositSuccessMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[normalize-space(text())='Transaction successful']")]
        public IWebElement withdrawalSuccessMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[normalize-space(text())='Transaction Failed. You can not withdraw amount more than the balance.']")]
        public IWebElement withdrawalFailedMessage { get; set; }

        //A dropdown method to select Account = Hermoine Granger to login
        public void SelectCustomerToLogin()
        {
            var selectElement = new SelectElement(SelectCustomerAccountDropdown);
            selectElement.SelectByText("Hermoine Granger");
            LoginButton.Click();
        }

        //A dropdown method to choose 1003
        public void SelectCustomerPageDropdown()
        {
            var selectElement = new SelectElement(CustomerPageDropdown);
            selectElement.SelectByValue("number:1003");
        }

        //Execute deposit action
        public void Deposit(string amount)
        {
            DepositButton.Click();
            AmountInputField.SendKeys(amount);
            Console.WriteLine("Deposit amount entered: " + amount);
            AmountToBeDepositButton.Click();
            if (depositSuccessMessage.Displayed)
            {
                //Here assume the message is always display after the transaction
            }

        }

        //Execute withdrawal action
        public void Withdraw(string amount)
        {
            WithdrawButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            AmountInputField.SendKeys(amount);
            Console.WriteLine("Withdrawal amount entered: " + amount);
            AmountToBeWithdrawButton.Click();
        }


        //Perform single transaction
        public double PerformSingleTransaction(string amount, string transactionType)
        {
            double balance = double.Parse(CustomerBalanceText.Text);
            Console.WriteLine("balance is " + balance);
            if (transactionType.Equals("Debit", StringComparison.OrdinalIgnoreCase))
            {
                Deposit(amount);
                balance += double.Parse(amount);
            }
            else if (transactionType.Equals("Credit", StringComparison.OrdinalIgnoreCase))
            {
                if (balance < double.Parse(amount))
                {
                    try
                    {
                        if (withdrawalFailedMessage.Displayed)
                        {
                            Console.WriteLine("Transaction Failed. You can not withdraw amount more than the balance.");
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        // Handle the exception here
                        // Console.WriteLine("No withdrawal message found");
                    }
                }
                else
                {
                    Withdraw(amount);
                    balance -= double.Parse(amount);
                }
            }


            double newBalanceUI = double.Parse(CustomerBalanceText.Text);

            return newBalanceUI;


        }

        //Perform customer transactions based on the sheet data
        public void PerformTransactions()
        {

            string[][] newDataSet = null;

            newDataSet = DataReader.GetSpreadSheetData("Customer_1003_Transactions");

            int newTotalColumns = newDataSet[0].Length;

            double balance = double.Parse(CustomerBalanceText.Text);

            for (int r = 0; r < newDataSet.Length; r++)
            {
                balance = PerformSingleTransaction(newDataSet[r][newTotalColumns - 2], newDataSet[r][newTotalColumns - 1]);
            }

            // Use the final balance for further processing if needed
            Console.WriteLine("Final balance after all transactions: " + balance);

        }
    }
}