using OpenQA.Selenium;
using System.Runtime.InteropServices;

namespace GOTESTS.Utilities
{
    public class Utils
    {
        public IWebDriver driver;
        private readonly ScreenshotHelper screenshotHelper;

        private readonly Functions.Manipulation manipulation;
        private readonly Functions.Interaction interaction;
        private readonly Functions.Validation validation;

        public Utils(IWebDriver driver)
        {
            this.driver = driver;

            screenshotHelper = new ScreenshotHelper(driver);
            manipulation = new Functions.Manipulation(driver);
            interaction = new Functions.Interaction(driver);
            validation = new Functions.Validation(driver);
        }

        #region Metodo de Manipulação
        // WAIT'S AND OTHERS
        public void Wait(int time) => manipulation.Wait(time);
        public void WaitElement(string element, int seconds = 90) => manipulation.WaitElement(element, seconds);
        public void WaitElementGone(string element) => manipulation.WaitElementGone(element);
        public void WaitActive(string xpath, [Optional] string description, int seconds = 10) => manipulation.WaitActive(xpath, description, seconds);
        public void WaitToast(string xpath, [Optional] string description, int seconds = 2) => manipulation.WaitToast(xpath, description, seconds);
        public void ClearField(string xpath) => manipulation.ClearField(xpath);
        public void ClickOut() => manipulation.ClickOut();
        #endregion

        #region Metodo de Interação
        // FIELD'S
        public void FieldText(string xpath, string value, [Optional] string description) => interaction.FieldText(xpath, value, description);
        public void FieldNumber(string xpath, int value, [Optional] string description) => interaction.FieldNumber(xpath, value, description);
        public void FieldTime(string xpath, string value, [Optional] string description) => interaction.FieldTime(xpath, value, description);
        public void FieldColor(string xpath, int r, int g, int b, [Optional] string description) => interaction.FieldColor(xpath, r, g, b, description);

        // DROPDOWN'S
        public void MenuDropDown(string xpath, string value, [Optional] string description) => interaction.MenuDropDown(xpath, value, description);
        public void MenuDropDownPromotion(string xpath, string value, [Optional] string description) => interaction.MenuDropDownPromotion(xpath, value, description);
        public void MenuDropDown2(string xpath, string value, [Optional] string description) => interaction.MenuDropDown2(xpath, value, description);
        public void MenuDropDownCheckMultiple(string xpath, List<int> values, [Optional] string description) => interaction.MenuDropDownCheckMultiple(xpath, values, description);

        // Button's
        public void ClickElement(string element, [Optional] string description) => interaction.ClickElement(element, description);
        public void ClickToggle(string xpath, bool values, [Optional] string description) => interaction.ClickToggle(xpath, values, description);
        public void ClickElementSubmit(string element, [Optional] string description) => interaction.ClickElementSubmit(element, description);
        #endregion

        #region Metodo de Validações
        public void ValidateData(string xpath, string value, [Optional] string description) => validation.ValidateData(xpath, value, description);
        public bool ValidateElementExists(string xpath) => validation.ValidateElementExists(xpath);
        public void ValidateRgb(int r, int g, int b) => validation.ValidateRgb(r, g, b);
        public string RgbToHex(int r, int g, int b) => validation.RgbToHex(r, g, b);
        #endregion

        #region Metodo para tirar Screenshot de Erros
        public void TakeScreenshot(string fileName) => screenshotHelper.capture(fileName);
        #endregion
    }
}