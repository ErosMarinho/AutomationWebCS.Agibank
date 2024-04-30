namespace MainProject
{
    class PesquisaSemSucessoTest : PesquisaSemSucessoPage
    {

        [Test, Category("Default Test")]
        public void FuncionalidadeCampoPesquisaSemSucesso()
        {
            // Define cabeçalho do Log
            LogHeader();

            ClicaIconePesquisa();
            PreencheCampoPesquisaSemSucesso();
        }
    }
}
