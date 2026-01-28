using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Runtime.InteropServices;

namespace GOTESTS.Utilities.Functions
{
    public class Manipulation
    {
        public IWebDriver driver;
        public Manipulation(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Metodo de Wait's
        // Método para aguardar carregamento da pagina (Metodo com lambda expression)
        public void Wait(int time) => Thread.Sleep(time);

        // Metodo que espera o elemento surja na tela via XPath
        public void WaitElement(string element, int seconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElement(By.XPath(element)));
        }

        // Metodo que espera o elemento sumir da tela via XPath
        public void WaitElementGone(string element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            wait.Until(d => d.FindElements(By.XPath(element)).Count == 0);
        }

        // Metodo que espera o botão ficar habilitado via XPath
        public void WaitActive(string xpath, [Optional] string description, int seconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                wait.Until(d => {
                    IWebElement element = d.FindElement(By.XPath(xpath));
                    return element.Displayed && element.Enabled;
                });

                if (description != null)
                    Console.WriteLine("Elemento ativo: " + description);
            }
            catch (WebDriverTimeoutException)
            {
                if (description != null) Console.WriteLine("Erro ao clicar em: " + description);
                Assert.Fail();
            }
        }

        // Metodo que espera o Toast aparecer via XPath
        public void WaitToast(string xpath, [Optional] string description, int seconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                IWebElement toast = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));

                string mensagemToast = toast.Text;

                Console.WriteLine("Erro informativo do Toast: " + description);
                Assert.That(mensagemToast, Does.Contain(description), "Mensagem de erro não exibida!");

            }
            catch (WebDriverTimeoutException)
            {
                if (description != null) Console.WriteLine("Erro ao clicar em: " + description);
                Assert.Fail();
            }
        }
        #endregion

        #region Metodo de Campos
        // Metodo para limpar campo de input via XPath (Metodo com lambda expression)
        public void ClearField(string xpath) => driver.FindElement(By.XPath(xpath)).Clear();

        // Metodo que clica fora de um elemento (Metodo com lambda expression)
        public void ClickOut() => driver.FindElement(By.XPath("//html")).Click();
        #endregion
    }
}
