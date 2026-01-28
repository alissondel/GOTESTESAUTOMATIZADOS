using GOTESTS.Utilities;
using OpenQA.Selenium;

namespace GOTESTS.Page.Create
{
    public class PromotionPage
    {
        public Utils utils;
        public IWebDriver driver;

        public PromotionPage(IWebDriver driver)
        {
            this.driver = driver;
            utils = new Utils(this.driver);
        }

        // Acessa o menu de gestão de ouvintes
        public void ClickBtnSidebar()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", 8000);
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/button", "Cliquei no botão de Gestão de Ouvintes");
            utils.ClickElement("/html/body/app-root/ng-component/div/app-side-menu/aside/nav/ng-scrollbar/div/cdk-accordion/cdk-accordion-item[2]/div/a[9]", "Cliquei no botão de promoção");
        }

        // Clica no botão de adicionar locutores
        public void AddPromotion()
        {
            utils.WaitElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", 120);
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/infoui-datatable/div[1]/button[1]", "Cliquei no botão de adicionar nova promoção");
        }

        // Preenche o cadastro de promoção
        public void RegisterPromotion()
        {
            utils.FieldText("//*[@id='mat-input-0']", "Salve o São Paulo FC", "Digitei o nome do promoção");
            utils.MenuDropDown2("//*[@id='mat-select-3']", "Indeterminado", "Digitei o periodo indeterminado "); // Bug não era para ocorrer
            utils.TakeScreenshot("Erro ao selecionar o periodo indeterminado");
            utils.MenuDropDown2("//*[@id='mat-select-3']", "Determinado", "Digitei o periodo determinado");
            utils.FieldText("//*[@id='mat-input-1']", "16-01-2026", "Digitei a data de incio");
            utils.FieldTime(
                "//*[@id='mat-input-2']",
                "08:00",
                "Selecionei o horário de Início"
            );
            utils.FieldText("//*[@id='mat-input-3']", "17-01-2026", "Digitei a data de término");
            utils.FieldTime(
                "//*[@id='mat-input-4']",
                "09:00",
                "Selecionei o horário de termini"
            );
            utils.FieldText("//*[@id='mat-input-5']", "Testando observação", "Digitei uma observação");
        }

        // Metodo que reserva o brinde
        public void ReserveGift ()
        {
            utils.ClickToggle("//*[@id='mat-mdc-slide-toggle-0-button']", true, "Cliquei no botão de atribuir brindes");
            utils.ClickElement("//*[@id='mat-tab-group-0-content-0']/div/app-promotion-prize-list/div/div/button", "Cliquei no botão de reserva bride");
            utils.MenuDropDown2("//*[@id='mat-input-6']", "Brinde do teteu", "Pesquisei o brinde e selecionei");
            utils.FieldNumber("//*[@id='mat-input-8']", 10, "Informei a quantidade reservada");
            utils.WaitActive("//*[@id='mat-mdc-dialog-0']/div/div/ng-component/div/div[3]/button[2]", "Esperando o botão habilitar");
            utils.ClickElement("//*[@id='mat-mdc-dialog-0']/div/div/ng-component/div/div[3]/button[2]", "Cliquei no botão de salvar brinde");
        }

        // Metodo que atribui a pergunta
        public void AssignQuestion()
        {
        }

        public void Participations()
        {
            utils.ClickElement("//*[@id='mat-tab-group-0-label-2']/span[2]/span", "Cliquei no botão de participações");
            utils.ClickToggle("//*[@id='mat-mdc-slide-toggle-2-button']", true, "Cliquei no botão de participações automaticas");
            utils.WaitElement("//*[@id='mat-select-4']", 90);
            //utils.ClickElement("//*[@id='mat-tab-group-0-content-2']/div/app-promotion-participation-list/div/app-participation-source-form/div/div[1]/button", "Cliquei no botão de adicionar participantes automática");
            //utils.ClickElement("//*[@id='mat-tab-group-0-content-2']/div/app-promotion-participation-list/div/app-participation-source-form/div/div[2]/div[2]/div/div/button", "Cliquei no segundo botão de deletar");
            utils.MenuDropDownPromotion(
                "//*[@id='mat-select-4']/div/div[2]/div",
                "Facebook",
                "Selecionei a plataforma: "
            );
            utils.MenuDropDownPromotion(
                "//*[@id='mat-select-5']/div/div[2]/div",
                "Cabrita FM",
                "Selecionei o titulo da pagina"
            );
            utils.MenuDropDownPromotion(
                "//*[@id='mat-select-6']/div/div[2]/div",
                "Bééééé tarde",
                "Selecionei o titulo da postagem"
            );  
        }

        // Clica no botão salvar do formulário de locutores
        public void ClickBtnSave()
        {
            utils.ClickElement("/html/body/app-root/ng-component/div/div[2]/main/ng-scrollbar/div/ng-component/div/div[2]/button[2]", "Cliquei no botão de salvar");
            utils.WaitToast("//*[contains(text(),'ERROR_NAME_ALREADY_EXISTS')]", "ERROR_NAME_ALREADY_EXISTS", 3);
        }
    }

}
