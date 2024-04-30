namespace MainProject
{
    class PesquisaSemSucessoTest : PesquisaSemSucessoPage
    {

        [Test, Category("Default Test")]
        public void FuncionalidadeCampoPesquisaSemSucesso()
        {
            // Define cabeçalho do Log
            LogHeader();
            ClicaBtnIconePesquisa();
            PreencheCampoPesquisaSemSucesso();
            ValidaTxtsTituloInformativo();
            ValidaTxtInformativoSemSucesso();
            ValidaSegundoCampoPesquisa();
            ValidaSegundoBtnPesquisa();
            ClicaBtnIconePesquisa();
            ValidaTxtPesquisaAtual();
            ApagarTxtCampoPesquisa();
            PreencheCampoPesquisaVazio();
            ValidaTxtInformativoCampoPesquisaVazio();
            ClicaBtnIconePesquisa();
            PreencheCampoPesquisaSemLimiteQtdCaracteres();
            PreencheSegundoCampoPesquisaSemSucesso();
            ClicaSegundoBtnPesquisa();
            ValidaTxtPesquisaAtual2();
        }
    }
}
