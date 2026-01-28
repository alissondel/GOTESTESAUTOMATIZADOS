using OpenQA.Selenium;
using GOTESTS.Utilities;

namespace GOTESTS.Page.Create
{
    public class RegisterProgramPage
    {
        public Utils utils;
        public IWebDriver driver;

        public RegisterProgramPage(IWebDriver driver)
        {
            this.driver = driver;
            utils = new Utils(this.driver);
        }

        // Acessa o menu de gestão de ouvintes
        public void ClickBtnSidebar()
        {
            bool sidebarAberto = driver
                .FindElements(By.CssSelector(".menu-section__indicator.expanded"))
                .Count > 0;

            if (!sidebarAberto)
            {
                utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", "Cliquei no botão de Gestão de Ouvintes");
            }
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/div/a[7]", "Cliquei no botão de Programas");
        }

        // Clica no botão de adicionar programa
        public void AddProgram()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/div/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", 120);
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", "Cliquei no botão de adicionar novo programa");

        }

        // Preenche o formulário de cadastro de programa
        public void RegisterProgram()
        {
            utils.FieldText("//*[@id='mat-input-14']", "Programa do QALISSON", "Digitei o nome do programa");
            utils.MenuDropDown2("//*[@id='mat-mdc-chip-list-input-0']", "Pinguim", "Digitei o nome do locutor");
            utils.ClickElement("//*[@id='mat-tab-group-0-content-0']/div/app-schedule-manager/form/div[2]/div/button", "Cliquei no botão para adicionar o dia da semana do programa");
            utils.MenuDropDownCheckMultiple(
                "//*[@id='mat-tab-group-0-content-0']/div/app-schedule-manager/form/div[1]/div/mat-form-field[1]",
                new List<int>
                {
                    36,
                    37,
                    38,
                    39,
                    40,
                    41,
                    42
                },
                "Cliquei nos checkbox para selecionar os dias da semana"
            );
            utils.FieldTime(
                "//*[@id='mat-input-16']",
                "08:00",
                "Selecionei o horário de Início"
            );
            utils.FieldTime(
                "//*[@id='mat-input-17']",
                "09:00",
                "Selecionei o horário de Término"
            );
        }

        // Clica no botão salvar do formulário de programa
        public void ClickBtnSave()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/div/main/ng-scrollbar/div/ng-component/div/div[3]/button[2]", "Cliquei no botão de Salvar");
        }

        // Clica no botão confirmar o formulário de programa
        public void ClickBtnConfirm()
        {
            utils.WaitElement("//*[@id='mat-mdc-dialog-0']", 120);
            bool openDialog = utils.ValidateElementExists("//*[@id='mat-mdc-dialog-0']");

            if (openDialog == true)
            {
                utils.ClickElement("//*[@id='mat-mdc-dialog-0']/div/div/ng-component/div[2]/button[2]", "Clique no botão de confirmar o cadastro");
            }
        }
    }
}