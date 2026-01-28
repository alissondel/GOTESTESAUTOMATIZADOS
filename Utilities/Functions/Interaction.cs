using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;

namespace GOTESTS.Utilities.Functions
{
    public class Interaction
    {
        public IWebDriver driver;
        private readonly Functions.Validation validation;
        public Interaction(IWebDriver driver)
        {
            this.driver = driver;
            validation = new Functions.Validation(driver);
        }

        // Faz o campo sair do foco
        public void ClickOutside()
        {
            Actions actions = new Actions(driver);
            actions.MoveByOffset(5, 5).Click().Perform();
        }

        #region Field's

        // Prenche o valor no campo do tipo texto
        public void FieldText(string xpath, string value, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(value);
                if (description != null) Console.WriteLine("Preenchido o campo: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao preencher: " + description);
                Assert.Fail();
            }
        }

        // Prenche o valor no campo do tipo numerico
        public void FieldNumber(string xpath, int value, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(value.ToString());
                if (description != null) Console.WriteLine("Preenchido o campo: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao preencher: " + description);
                Assert.Fail();
            }
        }

        // Prenche o valor no campo do tipo hora
        public void FieldTime(string xpath, string value, [Optional] string description)
        {
            try
            {
                IWebElement campoHora = driver.FindElement(By.XPath(xpath));

                campoHora.Click();
                campoHora.Clear();
                campoHora.SendKeys(value);

                ClickOutside();
                if (description != null)
                    Console.WriteLine("Selecionou horário: " + description);
            }
            catch
            {
                if (description != null)
                    Console.WriteLine("Erro ao selecionar horário: " + description);

                Assert.Fail();
            }
        }

        // Prenche o valor no campo do tipo cor
        public void FieldColor(string xpath, int r, int g, int b, [Optional] string description)
        {
            try
            {
                validation.ValidateRgb(r, g, b);
                string hexColor = validation.RgbToHex(r, g, b);
                IWebElement colorInput = driver.FindElement(By.XPath(xpath));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(@"
                    arguments[0].value = arguments[1];
                    arguments[0].dispatchEvent(new Event('input', { bubbles: true }));
                    arguments[0].dispatchEvent(new Event('change', { bubbles: true }));
                ", colorInput, hexColor);

                if (description != null) Console.WriteLine("Preenchido o campo: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao preencher: " + description);
                Assert.Fail();
            }
        }
        #endregion

        #region Dropdown's
        // Seleciona apenas uma unica opção do campo select
        public void MenuDropDown(string xpath, string value, [Optional] string description)
        {
            try
            {
                string xPathValue = "//*[text()='" + value + "']";
                driver.FindElement(By.XPath(xpath)).Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                wait.Until(d => d.FindElement(By.XPath(xPathValue)));

                driver.FindElement(By.XPath(xPathValue)).Click();
                if (description != null) Console.WriteLine("Selecionou menu dropdown: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao selecionar menu dropdown: " + description);
                Assert.Fail();
            }
        }

        // Seleciona apenas uma unica opção do campo select pegando o valor do span
        public void MenuDropDownPromotion(string xpath, string value, [Optional] string description)
        {
            try
            {
                string xPathValue = $"//mat-option//span[normalize-space()='{value}']";
                driver.FindElement(By.XPath(xpath)).Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                wait.Until(d => d.FindElement(By.XPath(xPathValue)));

                driver.FindElement(By.XPath(xPathValue)).Click();
                if (description != null) Console.WriteLine("Selecionou menu dropdown: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao selecionar menu dropdown: " + description);
                Assert.Fail();
            }
        }

        public void MenuDropDown2(string xpath, string value, [Optional] string description)
        {
            try
            {
                IWebElement input = driver.FindElement(By.XPath(xpath));

                driver.FindElement(By.XPath(xpath)).SendKeys(value);
                string xPathValue = $"//mat-option//span[normalize-space(text())='{value}']";

                // Aguarda carregamento das opções
                Thread.Sleep(1000);

                input.SendKeys(Keys.Enter);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                wait.Until(d => d.FindElement(By.XPath(xPathValue)));

                driver.FindElement(By.XPath(xPathValue)).Click();

                input.SendKeys(Keys.Tab); // sai do input
                //ClickOutside();           // FINALIZA o evento no Angular
                if (description != null)
                    Console.WriteLine("Selecionou menu dropdown: " + description);
            }
            catch
            {
                if (description != null)
                    Console.WriteLine("Erro ao selecionar menu dropdown: " + description);
                Assert.Fail();
            }
        }

        // Seleciona apenas uma ou mais opção do campo select
        public void MenuDropDownCheckMultiple(string xpath, List<int> values, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click();

                foreach (var value in values)
                {
                    string optionXpath = $"//*[@id='mat-option-{value}']";

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
                    wait.Until(d => d.FindElement(By.XPath(optionXpath)));

                    IWebElement checkbox = driver.FindElement(By.XPath($"//*[@id='mat-option-{value}']/mat-pseudo-checkbox"));

                    if (!checkbox.Selected)
                        checkbox.Click();
                }

                ClickOutside();
                if (description != null)
                    Console.WriteLine("Selecionou itens no dropdown: " + description);
            }
            catch
            {
                if (description != null)
                    Console.WriteLine("Erro ao selecionar itens no dropdown: " + description);

                Assert.Fail();
            }
        }

        #endregion

        #region Button's
        // Metodo dque faz clicar no botão
        public void ClickElement(string element, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(element)).Click();
                Thread.Sleep(1000); // 1 segundo de espera após o clique
                if (description != null) Console.WriteLine("Clicou em: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao clicar em: " + description);
                Assert.Fail();
            }
        }

        // Metodo dque faz clicar no botão Switch
        public void ClickToggle(string xpath, bool values, [Optional] string description)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement clickableToggleButton = wait.Until(d =>
                {
                    IWebElement element = d.FindElement(By.XPath(xpath));
                    if (element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    return null;
                });

                clickableToggleButton.Click();

                if (description != null) Console.WriteLine($"Switch '{description}' definido para: {values}");
            }
            catch
            {
                if (description != null)
                    Console.WriteLine("Erro ao clicar no switch: " + description);

                Assert.Fail();
            }
        }

        // Clica no botão de submit
        public void ClickElementSubmit(string element, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(element)).Submit();
                Thread.Sleep(1000); // 1 segundo de espera após o clique
                if (description != null) Console.WriteLine("Clicou em: " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao clicar em: " + description);
                Assert.Fail();
            }
        }
        #endregion
    }
}
