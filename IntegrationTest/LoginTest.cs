using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace IntegrationTest
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver _driver;
        private readonly string _baseUrl = "http://localhost:5000";
        private readonly string _validEmail = "manoj@gmail.com";
        private readonly string _validPassword = "test";

        [TestInitialize]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void Login_WithValidCredentials_ShouldRedirectToHomePage()
        {
            // Login with valid details
            _driver.Navigate().GoToUrl($"{_baseUrl}/login");

            var emailField = _driver.FindElement(By.Id("email"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var submitButton = _driver.FindElement(By.Id("login-button"));

            // moving with valid login details
            emailField.SendKeys(_validEmail);
            passwordField.SendKeys(_validPassword);
            submitButton.Click();

          
            var expectedUrl = $"{_baseUrl}/home";
            Assert.AreEqual(expectedUrl, _driver.Url);
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ShouldShowErrorMessage()
        {
            // Arrange
            _driver.Navigate().GoToUrl($"{_baseUrl}/login");

            var emailField = _driver.FindElement(By.Id("email"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var submitButton = _driver.FindElement(By.Id("login-button"));

            // login with invalid details
            emailField.SendKeys("manoj123@gmail.com");
            passwordField.SendKeys("test1");
            submitButton.Click();

           
            var errorMessage = _driver.FindElement(By.ClassName("error-message"));
            Assert.IsNotNull(errorMessage);
        }
    }
}
