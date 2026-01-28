using GOTESTS.Utilities;
using OpenQA.Selenium;

namespace GOTESTS.Page.Create
{
    public class PrizeDrawPage
    {
        public Utils utils;
        public IWebDriver driver;

        public PrizeDrawPage(IWebDriver driver)
        {
            this.driver = driver;
            utils = new Utils(this.driver);
        }

        // Acessa o menu de gestão de ouvintes
        public void ClickBtnSidebar()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", "Cliquei no botão de Gestão de Ouvintes");
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/div/a[8]", "Cliquei no botão de sorteio");
        }

        // Clica no botão de adicionar sorteio
        public void AddDrawPage()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", 120);
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", "Cliquei no botão de adicionar novo sorteio");
        }

        public void RegisterDrawPage()
        {
            utils.MenuDropDown2("//*[@id='mat-input-0']", "Teste Alisson", "Pesquisei a promoção e selecionei");
            utils.FieldText("//*[@id='mat-input-1']", "28-01-2026", "Digitei a data do sorteio");
            utils.FieldTime(
                "//*[@id='mat-input-2']",
                "08:00",
                "Digitei a data e horario do sorteio"
            );
            utils.MenuDropDown2("//*[@id='mat-select-2']", "Aleatório/Randômico", "Selecionei a forma de sorteio");
            utils.MenuDropDown2("//*[@id='mat-select-3']", "Automático", "Selecionei o modo de serteio");
            utils.FieldNumber("//*[@id='mat-input-3']", 2, "Digitei a quantidade de sorteados");
            utils.FieldText("//*[@id='mat-input-4']", "Essa é uma obs de teste", "Digitei a observãção");
        }

        public void FilterByPeriod()
        {
            utils.ClickToggle("//*[@id='mat-mdc-slide-toggle-1-button']", true, "Ativei filtrar por periodo");
            utils.ClickElement("//*[@id='mat-tab-group-0-label-1']", "Cliquei no botão de filtrar por periodo");
            utils.FieldText("//*[@id='mat-input-5']", "27-01-2026", "Digitei a data de inicio");
            utils.FieldTime(
                "//*[@id='mat-input-6']",
                "08:00",
                "Digitei o horario inicial"
            );
            utils.FieldText("//*[@id='mat-input-7']", "31-01-2026", "Digitei a data de termino");
            utils.FieldTime(
                "//*[@id='mat-input-8']",
                "18:00",
                "Digitei o horario de termino"
            );
        }

        public void ClickBtnSave()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/div[3]/button[2]");
        }

        public void ModalConfirm()
        {
            utils.WaitElement("//*[@id='mat-mdc-dialog-0']", 120);
            utils.ClickElement("//*[@id='mat-mdc-dialog-0']/div/div/ng-component/div[2]/button[1]", "Selecionei a opção não");
        }

    }
}
