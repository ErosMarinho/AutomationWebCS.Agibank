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
            ClicaBtnIconePesquisa();
            ValidaCampoPesquisa();
            ValidaBtnSetaEsquerda();
            ValidaBtnSetaDireita();
            ValidaPostImagem();
            ValidaTxtTitulo1();
            ValidaTxtsSubTitulosGrid();
            ValidaPaginacao();
            ValidaTxtTitulo2();
            ValidaTxtsPostImagem();
            ValidaTxtTitulo3();
            ValidaBtnLinkAppStore();
            ValidaBtnLinkGooglePlay();
            ValidaTxtTitulo4();
            ValidaCampoAdicionarEmail();
            ValidaBtnInscreverse();
        }
    }
}
