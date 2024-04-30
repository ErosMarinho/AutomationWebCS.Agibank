namespace MainProject
{
    class PesquisaComSucessoTeste : PesquisaComSucessoPage
    {

        [Test, Category("Default Test")]
        public void FuncionalidadeCampoPesquisaComSucesso()
        {
            // Define cabeçalho do Log
            LogHeader();
            ClicaBtnIconePesquisa();
            PreencheCampoPesquisa1();
            ClicaBtnIconePesquisa();
            ValidaTxtCampoPesquisaRealizada();
            ApagarTxtCampoPesquisa();
            PreencheCampoPesquisa2();
            ClicaBtnIconePesquisa();
            ApagarTxtCampoPesquisa();
            PreencheCampoPesquisa3();
        }
    }
}
