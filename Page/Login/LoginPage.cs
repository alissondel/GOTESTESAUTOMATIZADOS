using OpenQA.Selenium;
using GOTESTS.Utilities;

namespace GOTESTS.Page.Login
{
    public class LoginPage
    {
        public Utils utils;
        public IWebDriver driver;

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
            utils = new Utils(this.driver);
        }

        public void Login(string user, string password)
        {
            // Field Email
            utils.FieldText("//*[@id='email']", user, "Digitei o email");

            // Field Password
            utils.FieldText("//*[@id='password']", password, "Digitei a senha");

            // BTN Login
            utils.ClickElement("//*[@id='next']", "Cliquei no botão de realizar login");
        }
    }
}