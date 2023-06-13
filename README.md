This repository is used to store automation scripts for a technical assessment.

Automation website: https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login

Tools and Technologies: Selenium, C#, NUnit, Visual Studio

Test cases:
BankManager_AddCustomerTest.cs - Logs in as a Bank Manager, creates customers based on an Excel file, and then deletes specific customers.
CustomerLogin_CustomerTransactionTest - Logs in as a customer, performs debit and credit transactions, and verifies the current balance to ensure it matches the balance displayed in the UI.

Project Architecture:
This project utilizes the Page Object Model (POM) in Selenium. The POM divides the web application's user interface into separate page classes, with each class representing a specific page or component of the application. All tests are based on the NUnit testing framework.

Within the project structure, there are two separate folders:

Page Object folder:
Designed to encapsulate the elements (e.g., buttons, input fields) and actions (e.g., clicks, text input) related to a specific page or component.
Provides methods to interact with the elements on the page and perform actions.

Test folder:
Instantiates the required page object class(es) to access the web elements and actions.
Utilizes the methods defined in the page object classes to interact with the web elements and perform actions.

Please refer to the test report log located in the Testlog folder. Additionally, I have attached a test execution video for your reference.
