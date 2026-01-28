using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GOTESTS.Utilities
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(bool headless)
        {
            ChromeOptions options = new ChromeOptions();

            if (headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--no-sandbox");
            }
            else
            {
                options.AddArgument("disk-cache-size=0");
                options.AddArgument("start-maximized");
            }

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // GARANTE TAMANHO REAL
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            Console.WriteLine("Tamanho da tela pre-setado:" + driver.Manage().Window.Size);

            return driver;
        }
    }
}