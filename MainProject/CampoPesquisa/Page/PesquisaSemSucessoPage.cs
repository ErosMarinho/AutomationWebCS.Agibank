using AutomationWebCS.Agibank.Core_Padrao;

namespace MainProject
{
    class PesquisaSemSucessoPage : PageObjects
    {
        public void LogHeader() =>
          Log("<b>MENU:</b> Home <br>" +
             "<b>TESTE:</b> Funcionalidade do campo Pesquisa sem sucesso <br>" +
             "<b>==========================</b><br>");

        public void PreencheCampoPesquisaSemSucesso()
        {
            EscreveTexto("//*[@class='search-field']", "Bolsa Familia", "pesquisar por: Bolsa Familia"); Enter();
        }
        public void ValidaTxtsTituloInformativo()
        {
            var txt = CapturaDados("//*[@class='page-title ast-archive-title']", GetAttrib.innerText);
            ValidaDados($"//*[@class='page-title ast-archive-title']", txt, $"texto titulo informativo: {txt}");            
        }
        public void ValidaTxtInformativoSemSucesso()
        {
            var txt = "Lamentamos, mas nada foi encontrado para sua pesquisa, tente novamente com outras palavras.";
            ValidaDados($"//*[text()='{txt}']", txt, GetAttrib.text, $"texto informativo:{txt}");
        }
        public void ValidaSegundoCampoPesquisa()
        {
            ValidaElementoPresente("(//*[@class='search-field'])[2]", "segundo campo de pesquisa");
        }
        public void ValidaSegundoBtnPesquisa()
        {
            ValidaElementoPresente("(//*[@class='search-submit ast-search-submit'])[2]", "segundo botão de pesquisa");
        }
        public void ValidaTxtPesquisaAtual()
        {
            var txt = CapturaDados("(//*[@class='search-field'])[1]", GetAttrib.innerText);
            ValidaDados($"(//*[@class='search-field'])[1]", txt, $"texto da pesquisa atual: {txt}");
        }
        public void PreencheCampoPesquisaVazio()
        {
            EscreveTexto("//*[@class='search-field']"," ", "pesquisar por: N/A"); Enter();
        }
        public void ValidaTxtInformativoCampoPesquisaVazio()
        {
            var txt = "Resultados encontrados para:";
            ValidaDados($"//*[contains(text(),'{txt}')]", txt, GetAttrib.text, $"texto informativo:{txt}");
        }
        public void PreencheCampoPesquisaSemLimiteQtdCaracteres()
        {
            EscreveTexto("//*[@class='search-field']","ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789","pesquisa sem limite de qtd de caracteres: ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"); Enter();
        }
        public void PreencheSegundoCampoPesquisaSemSucesso()
        {
            EscreveTexto("(//*[@class='search-field'])[2]","Salario","pesquisar por: Salario");
        }
        public void ClicaSegundoBtnPesquisa()
        {
            ClicaElemento("//*[@class='search-submit']","segundo botão de pesquisa");
        }
        public void ValidaTxtPesquisaAtual2()
        {
            var txt = CapturaDados("//*[@class='page-title ast-archive-title']", GetAttrib.innerText);
            ValidaDados($"//*[@class='page-title ast-archive-title']", txt, $"texto da pesquisa realizado: {txt}");
        }
    }
}