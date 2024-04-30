namespace AutomationWebCS.Agibank.Core_Padrao
{
    public class PageObjects : Begin
    {
        #region Menu do Sistema
        public void AcionaMenu() =>
            ClicaElemento("//*/aside/div[@class='button__menu']", "menu Principal");

        #endregion

        #region Botões do Sistema

        public void ClicaIconePesquisa()
        {
            ClicaElemento("(//*[@class='ast-icon icon-search'])[2]", "ícone de Pesquisa");
        }

        #endregion

        #region Campos do Sistema

        public void PreencheCampoPesquisaSemSucesso()
        {
            EscreveTexto("//*[@class='search-field']", "Bolsa Familia", "busca por: Bolsa Familia"); Enter();
            Enter();
        }

        #endregion
    }
}