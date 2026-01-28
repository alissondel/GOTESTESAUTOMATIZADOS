using OpenQA.Selenium;

namespace GOTESTS.Utilities
{
    public class ScreenshotHelper
    {
        private readonly IWebDriver driver;

        public ScreenshotHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void capture(string fileName) {
            var now = DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss");

            // CAMINHO FIXO que você quer
            var dirPath = @"D:\QA\Projetos\GOTESTS\Screenshots";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine($"Pasta criada: {dirPath}");
            }

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var filePath = Path.Combine(dirPath, $"{fileName}_{now}.png");

            screenshot.SaveAsFile(filePath);
            Console.WriteLine($"Screenshot salvo: {filePath}");
        }
    }
}
