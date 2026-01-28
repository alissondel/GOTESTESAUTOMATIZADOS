using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace GOTESTS.Utilities.Functions
{
    public class Validation
    {
        public IWebDriver driver;
        public Validation(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Método para validar se o valor esperado está presente na tela via XPath
        public void ValidateData(string xpath, string value, [Optional] string description)
        {
            try
            {
                // O site do correio possui um recaptcha e que atrapalha o teste, por isso foi necessário implementar o WebDriverWait para aguardar o carregamento do elemento antes da validação
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

                wait.Until(d =>
                    d.FindElement(By.XPath(xpath)).Text.Contains(value)
                );

                Assert.That(
                    driver.FindElement(By.XPath(xpath)).Text,
                    Does.Contain(value)
                );
                //Assert.That(driver.FindElement(By.XPath(xpath)).Text, Does.Contain(value));

                if (description != null) Console.WriteLine("Validou: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao validar: " + description);
                Assert.Fail();
            }
        }

        // Método para validar se o elemento existe na pagina via XPath
        public bool ValidateElementExists(string xpath)
        {
            try
            {
                driver.FindElement(By.XPath(xpath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Valida valor do campo do RGB
        public void ValidateRgb(int r, int g, int b)
        {
            if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                throw new ArgumentOutOfRangeException("Valores RGB devem estar entre 0 e 255.");
        }

        // Transforma cor rgb em hexadecimal
        public string RgbToHex(int r, int g, int b)
        {
            return $"#{r:X2}{g:X2}{b:X2}";
        }

    }
}