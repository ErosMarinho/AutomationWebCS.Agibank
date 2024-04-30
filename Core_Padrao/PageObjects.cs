namespace AutomationWebCS.Agibank.Core_Padrao
{
    public class PageObjects : Begin
    {
        #region Menu do Sistema
        public void AcionaMenu() =>
            ClicaElemento("//*/aside/div[@class='button__menu']", "menu Principal");

        #endregion

        #region Botões do Sistema

        public void ClicaBtnIconePesquisa()
        {
            ClicaElemento("(//*[@class='ast-icon icon-search'])[2]", "botão ícone de Pesquisa");
        }

        #endregion

        #region Campos do Sistema
               
        public void ApagarTxtCampoPesquisa()
        {
            LimpaDados("//*[@class='search-field']");
        }


        #endregion
    }
}