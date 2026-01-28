// EXPORTS PAGES
using GOTESTS.Page.Create;
using GOTESTS.Utilities;

// EXPORTS LIBRARIES
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;

namespace GOTESTS.Test.Create
{
    [TestFixture]
    public class LabelTests
    {
        protected IWebDriver driver;
        protected SeleniumSettings selenium;
        protected ScreenshotHelper screenshotHelper;

        Utils utils;
        LabelPage labelPage;

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
            labelPage = new LabelPage(this.driver);
        }

        [Test]
        [Category("Cadastro de Etiquetas")]
        public void RegisterLabel()
        {
            labelPage.ClickBtnSidebar();
            screenshotHelper.capture("Clicar no botão de sidebar");
            labelPage.AddLabel();
            labelPage.RegisterLabel();
            labelPage.ClickBtnSave();
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
