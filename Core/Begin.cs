// EXPORTS PAGES
using GOTESTS.Page.Create;
using GOTESTS.Page.Login;
using GOTESTS.Utilities;

// EXPORTS LIBRARIES
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;

namespace GOTESTS.Core
{
    [TestFixture]
    public class Begin
    {
        private IWebDriver driver;
        protected SeleniumSettings selenium;
        protected CredentialsSettings credentials;
        
        Utils utils;
        
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
            utils = new Utils(driver);
            if (!selenium.Headless) selenium.DriverQuit = false;

            driver.Navigate().GoToUrl(selenium.BaseUrl);
        }

        [Test]
        [Category("base")]
        public void ExecuteTests()
        {
            // Realiza login
            var loginPage = new LoginPage(driver);
            loginPage.Login(credentials.Email, credentials.Password);

            // Cadastrar Sorteio
            var prizeDrawPage = new PrizeDrawPage(driver);
            prizeDrawPage.ClickBtnSidebar();
            prizeDrawPage.AddDrawPage();
            prizeDrawPage.RegisterDrawPage();
            prizeDrawPage.FilterByPeriod();
            prizeDrawPage.ClickBtnSave();
            prizeDrawPage.ModalConfirm();

            // Cadastrar Promoção
            //var promotionPage = new PromotionPage(driver);
            //promotionPage.ClickBtnSidebar();
            //promotionPage.AddPromotion();
            //promotionPage.RegisterPromotion();
            //promotionPage.ReserveGift();
            //promotionPage.Participations();
            //promotionPage.ClickBtnSave();

            // Cadastrar Locutores
            //var announcerPage = new AnnouncerPage(driver);
            //announcerPage.ClickBtnSidebar();
            //announcerPage.AddAnnouncer();
            //announcerPage.RegisterAnnouncer();
            //announcerPage.ClickBtnSave();

            // Cadastrar Etiqueta
            //var labelPage = new LabelPage(driver);
            //labelPage.ClickBtnSidebar();
            //labelPage.AddLabel();
            //labelPage.RegisterLabel();
            //labelPage.ClickBtnSave();

            // Cadastrar Brinde
            //var giftPage = new GiftPage(driver);
            //giftPage.ClickBtnSidebar();
            //giftPage.AddGift();
            //giftPage.RegisterGift();
            //giftPage.ClickBtnSave();

            // Cadastrar Ouvinte
            //var registerListenerPage = new RegisterListenerPage(driver);
            //registerListenerPage.ClickBtnSidebar();
            //registerListenerPage.AddListener();
            //registerListenerPage.Registerlistener();
            //registerListenerPage.ClickBtnSave();

            // Cadastrar Programa 
            //var registerProgramPage = new RegisterProgramPage(driver);
            //registerProgramPage.ClickBtnSidebar();
            //registerProgramPage.AddProgram();
            //registerProgramPage.RegisterProgram();
            //registerProgramPage.ClickBtnSave();
            //registerProgramPage.ClickBtnConfirm();
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