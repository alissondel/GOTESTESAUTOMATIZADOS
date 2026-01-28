// EXPORTS PAGES
using GOTESTS.Utilities;
using GOTESTS.Page.Login;
using Microsoft.Extensions.Configuration;
// EXPORTS LIBRARIES
using OpenQA.Selenium;

namespace GOTESTS.Test.Login
{
    [TestFixture]
    public class LoginTests
    {

        protected IWebDriver driver;
        protected SeleniumSettings selenium;
        protected CredentialsSettings credentials;

        Utils utils;
        LoginPage loginPage;

        [OneTimeSetUp]
        public void SetupConfiguration()
        {
            selenium = TestConfiguration.Configuration
                .GetSection("Selenium")
                .Get<SeleniumSettings>()
                ?? throw new InvalidOperationException("Configuração 'Selenium' não encontrada no appsettings.json");

            credentials = TestConfiguration.Configuration
                .GetSection("Credentials")
                .Get<CredentialsSettings>()
            ?? throw new InvalidOperationException("Configuração 'Credentials' não encontrada no appsettings.json");
        }

        [SetUp]
        public void Setup()
        {
            driver = WebDriverFactory.CreateWebDriver(selenium.Headless);
            utils = new Utils(this.driver);
            driver.Navigate().GoToUrl(selenium.BaseUrl);
            loginPage = new LoginPage(this.driver);
        }

        [Test]
        [Category("Login")]
        public void Login()
        {
            loginPage.Login(credentials.Email, credentials.Password);
        }

        [TearDown]
        public void Teardown()
        {
            if (selenium.DriverQuit && driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}