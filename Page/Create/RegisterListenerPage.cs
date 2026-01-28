using OpenQA.Selenium;
using GOTESTS.Utilities;

namespace GOTESTS.Page.Create
{
    public class RegisterListenerPage
    {
        public Utils utils;
        public IWebDriver driver;

        public RegisterListenerPage(IWebDriver driver)
        {
            this.driver = driver;
            utils = new Utils(this.driver);
        }


        // Acessa o menu e clical no botão de ouvinte
        public void ClickBtnSidebar()
        {
            //bool sidebarAberto = driver
            //    .FindElements(By.CssSelector(".menu-section__indicator.expanded"))
            //    .Count > 0;

            //if (!sidebarAberto)
            //{
            //}

            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", "Cliquei no botão de Gestão de Ouvintes");
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/div/a[6]", "Cliquei no botão de Ouvintes");
        }

        // Clica no botão de adicionar ouvinte
        public void AddListener()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", 120);
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", "Cliquei no botão de adicionar novo ouvinte");
        }

        // Preenche o formulário de cadastro de ouvinte
        public void Registerlistener()
        {
            utils.FieldText("//*[@id='mat-input-0']", "Programa QA", "Digitei Nome do Ouvinte");
            utils.FieldText("//*[@id='mat-input-1']", "20698129873", "Digitei CPF do Ouvinte");
            utils.FieldText("//*[@id='mat-input-2']", "245156677", "Digitei RG do Ouvinte");
            utils.FieldText("//*[@id='mat-input-3']", "2000-05-27", "Digitei Data de Nascimento do Ouvinte");
            utils.MenuDropDown("//*[@id='mat-select-4']", "Masculino", "Digitei genero do Ouvinte");
            utils.FieldText("//*[@id='mat-input-4']", "teste@teste.com", "Digitei email do Ouvinte");

        }

        // Clica no botão salvar do formulário de ouvinte
        public void ClickBtnSave()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/div/main/ng-scrollbar/div/app-listener-form/div/div[3]/button[2]");
        }
    }
}