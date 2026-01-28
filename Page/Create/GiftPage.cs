using GOTESTS.Utilities;
using OpenQA.Selenium;

namespace GOTESTS.Page.Create
{
    public class GiftPage
    {
        public Utils utils;
        public IWebDriver driver;

        public GiftPage(IWebDriver driver)
        {
            this.driver = driver;
            utils = new Utils(this.driver);
        }

        // Acessa o menu de gestão de ouvintes
        public void ClickBtnSidebar()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", "Cliquei no botão de Gestão de Ouvintes");
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/div/a[4]", "Cliquei no botão de Brindes");
        }

        // Clica no botão de adicionar brindes
        public void AddGift()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", 120);
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", "Cliquei no botão de adicionar novo brinde");
        }

        // Preenche o formulário de cadastro de brinde
        public void RegisterGift() {
            utils.FieldText("//*[@id='mat-input-0']", "Brinde do QA 2", "Digitei o nome do brinde");
            utils.FieldText("//*[@id='mat-input-1']", "Unidade", "Digitei a unidade de medida");
            utils.FieldNumber("//*[@id='mat-input-2']", 1, "Digitei a quantidade minima do estoque");
            utils.FieldText("//*[@id='mat-input-3']", "Teste do QA 2", "Digitei uma observação");
            utils.ClickToggle("//*[@id='mat-mdc-slide-toggle-0-button']", true, "Cliquei no botão de adicionar movimento");
            utils.MenuDropDown("//*[@id='mat-select-2']", "Compra", "Selecionei a opção compra");
            utils.FieldNumber("//*[@id='mat-input-4']", 20, "Digitei a quantidade de compra");
        }

        // Clica no botão salvar do formulário de brinde
        public void ClickBtnSave()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/div[3]/button[2]");
        }
    }
}
