// EXPORTS PAGES
using GOTESTS.Page.Create;
using GOTESTS.Utilities;

// EXPORTS LIBRARIES
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;

namespace GOTESTS.Test.Create
{
    [TestFixture]
    public class RegisterProgramTests
    {
        protected IWebDriver driver;
        protected SeleniumSettings selenium;
        protected ScreenshotHelper screenshotHelper;

        Utils utils;
        RegisterProgramPage registerProgramPage;

        [OneTimeSetUp]
        public void SetupConfiguration()
        {
            selenium = TestConfiguration.Configuration
                .GetSection("Selenium")
                .Get<SeleniumSettings>()
                ?? throw new InvalidOperationException("Configuração 'Selenium' não encontrada no appsettings.json");
        }

        [SetUp]
        public void Setup()
        {
            driver = WebDriverFactory.CreateWebDriver(selenium.Headless);
            screenshotHelper = new ScreenshotHelper(this.driver);
            utils = new Utils(this.driver);
            driver.Navigate().GoToUrl(selenium.BaseUrl);
            registerProgramPage = new RegisterProgramPage(this.driver);
        }

        [Test]
        [Category("Cadastro de Programas")]
        public void RegisterProgram()
        {
            registerProgramPage.ClickBtnSidebar();
            screenshotHelper.capture("Clicar no botão de sidebar");
            registerProgramPage.AddProgram();
            registerProgramPage.RegisterProgram();
            registerProgramPage.ClickBtnSave();
            registerProgramPage.ClickBtnConfirm();
        }

        [TearDown]
        public void EndTest()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success && driver != null)
                    utils.TakeScreenshot($"ERRO_{TestContext.CurrentContext.Test.Name}");
            }
            finally
            {
                if (selenium.DriverQuit && driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
        }
    }
}