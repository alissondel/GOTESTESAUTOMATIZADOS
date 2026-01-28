using GOTESTS.Utilities;
using OpenQA.Selenium;

namespace GOTESTS.Page.Create
{
    public class LabelPage
    {
        public Utils utils;
        public IWebDriver driver;

        public LabelPage(IWebDriver driver)
        {
            this.driver = driver;
            utils = new Utils(this.driver);
        }

        // Acessa o menu de gestão de ouvintes
        public void ClickBtnSidebar()
        {
            //bool sidebarAberto = driver
            //    .FindElements(By.CssSelector(".menu-section__indicator.expanded"))
            //    .Count > 0;

            //if (!sidebarAberto)
            //{
            //}
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", "Cliquei no botão de Gestão de Ouvintes");
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/div/a[5]", "Cliquei no botão de etiquetas");
        }

        // Clica no botão de adicionar etiquetas
        public void AddLabel()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", 120);
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", "Cliquei no botão de adicionar novo brinde");
        }

        public void RegisterLabel()
        {
            utils.FieldText("//*[@id='mat-input-0']", "Diamante", "Digitei o nome da etiqueta");
            utils.FieldColor("//*[@id='mat-input-1']", 0, 0, 0, "Preenchi a cor da etiqueta");
        }

        // Clica no botão salvar do formulário de ouvinte
        public void ClickBtnSave()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/div[3]/button[2]");
        }
    }
}
