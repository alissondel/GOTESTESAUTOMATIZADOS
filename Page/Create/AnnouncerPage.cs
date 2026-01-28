using GOTESTS.Utilities;
using OpenQA.Selenium;

namespace GOTESTS.Page.Create
{
    public class AnnouncerPage
    {
        public Utils utils;
        public IWebDriver driver;

        public AnnouncerPage(IWebDriver driver)
        {
            this.driver = driver;
            utils = new Utils(this.driver);
        }

        // Acessa o menu de gestão de ouvintes
        public void ClickBtnSidebar()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", "Cliquei no botão de Gestão de Ouvintes");
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/div/a[3]", "Cliquei no botão de locutores");
        }

        // Clica no botão de adicionar locutores
        public void AddAnnouncer()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", 120);
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", "Cliquei no botão de adicionar novo locutor");
        }

        // Preenche o cadastro de locutores
        public void RegisterAnnouncer()
        {
            utils.FieldText("//*[@id='mat-input-0']", "Alisson do QA", "Digitei o nome do locutor");
            utils.FieldText("//*[@id='mat-input-1']", "Testando este campo de obs", "Digitei uma observação");
        }

        // Clica no botão salvar do formulário de locutores
        public void ClickBtnSave()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/div[3]/button[2]");
        }
    }
}
