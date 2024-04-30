using AutomationWebCS.Agibank.Core_Padrao;

namespace MainProject
{
    class PesquisaComSucessoPage : PageObjects
    {
        public void LogHeader() =>
           Log("<b>MENU:</b> Home <br>" +
              "<b>TESTE:</b> Funcionalidade do campo Pesquisa com sucesso <br>" +
              "<b>==========================</b><br>");

        public void PreencheCampoPesquisa1()
        {
            EscreveTexto("//*[@class='search-field']", "Carreira", "pesquisar por: Carreira"); Enter();
        }
        public void ValidaTxtCampoPesquisaRealizada()
        {
            var txt = CapturaDados("(//*[@class='search-field'])[1]", GetAttrib.innerText);
            ValidaDados($"(//*[@class='search-field'])[1]", txt, $"texto da pesquisa atual: {txt}");
        }
        public void PreencheCampoPesquisa2()
        {
            EscreveTexto("//*[@class='search-field']", "Emprestimo", "pesquisar por: Emprestimo"); Enter();
        }
        public void PreencheCampoPesquisa3()
        {
            EscreveTexto("//*[@class='search-field']", "Consórcios", "pesquisar por: Consórcios"); Enter();
        }
    }
}
