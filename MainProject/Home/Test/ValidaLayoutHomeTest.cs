namespace MainProject
{
    class ValidaLayoutHomeTest : ValidaLayoutHomePage
    {
        [Test, Category("Default Test")]
        public void ValidaLayoutHome()
        {
            // Define cabeçalho do Log
            LogHeader();
            ValidaLogotipo();
            ValidaTxtsMenus();
            MoveMousePrimeiroMenu();
            ValidaTxtsSubMenuPrimeiro();
            MoveMouseSegundoMenu();
            ValidaTxtsSubMenuSegundo();
            ClicaIconePesquisa();
            ValidaCampoPesquisa();
            ValidaBtnSetaEsquerda();
            ValidaBtnSetaDireita();
            ValidaPostImagem();
            ValidaTxtTitulo1();
            ValidaTxtsSubTitulosGrid();
            ValidaPaginacao();
            ValidaTxtTitulo2();
            ValidaTxtsPostImagem();
        }
    }
}
