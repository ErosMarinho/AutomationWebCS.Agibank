using AutomationWebCS.Agibank.Core_Padrao;

namespace MainProject
{
    class ValidaLayoutHomePage : PageObjects
    {
        public void LogHeader() =>
            Log("<b>MENU:</b> Home <br>" +
               "<b>TESTE:</b> Valida Layout da Tela Home <br>" +
               "<b>==========================</b><br>");
        public void ValidaLogotipo()
        {
            ValidaElementoPresente("//*[@class='custom-logo-link']", "logo tipo Agibank");
        }
        public void ValidaTxtsMenus()
        {
            var txt1 = "O Agibank";
            ValidaDados($"(//*[text()='{txt1}'])[1]", txt1, $"texto Menu: {txt1}");
            var txt2 = "Produtos";
            ValidaDados($"(//*[text()='{txt2}'])[1]", txt2, $"texto Menu: {txt2}");
            var txt3 = "Serviços";
            ValidaDados($"(//*[text()='{txt3}'])[1]", txt3, $"texto Menu: {txt3}");
            var txt4 = "Suas finanças";
            ValidaDados($"(//*[text()='{txt4}'])[1]", txt4, $"texto Menu: {txt3}");           
            var txt5 = "Sua segurança";            
            ValidaDados($"(//*[text()='{txt5}'])[1]", txt5, $"texto Menu: {txt5}");
            var txt6 = "Stories";
            ValidaDados($"(//*[text()='{txt6}'])[1]", txt6, $"texto Menu: {txt6}");
        }
        public void MoveMousePrimeiroMenu()
        {
            MoveToElemento("(//*[text()='O Agibank'])[1]", "menu O Agibank");
        }
        public void ValidaTxtsSubMenuPrimeiro()
        {
            var txt1 = "Colunas";
            ValidaDados($"(//*[text()='{txt1}'])[1]", txt1, $"texto Menu: {txt1}");
            var txt2 = "Notícias";
            ValidaDados($"(//*[text()='{txt2}'])[1]", txt2, $"texto Menu: {txt2}");
            var txt3 = "Carreira";
            ValidaDados($"(//*[text()='{txt3}'])[1]", txt3, $"texto Menu: {txt3}");            
        }
        public void MoveMouseSegundoMenu()
        {
            MoveToElemento("(//*[text()='Produtos'])[1]", "menu Produtos");
        }
        public void ValidaTxtsSubMenuSegundo()
        {            
            var txt1 = "Empréstimos";
            ValidaDados($"(//*[text()='{txt1}'])[1]", txt1, $"texto Submenu: {txt1}");
            MoveToElemento("(//*[text()='Empréstimos'])[1]", "menu Produtos");
            var txt2 = "Empréstimo Consignado";
            ValidaDados($"(//*[text()='{txt2}'])[1]", txt2, $"texto Submenu: {txt2}");
            var txt3 = "Empréstimo Pessoal";
            ValidaDados($"(//*[text()='{txt3}'])[1]", txt3, $"texto Submenu: {txt3}");
            var txt4 = "Empréstimo na Conta de Luz";
            ValidaDados($"(//*[text()='{txt4}'])[1]", txt4, $"texto Submenu: {txt3}");
            var txt5 = "Conta Corrente";
            ValidaDados($"(//*[text()='{txt5}'])[1]", txt5, $"texto Submenu: {txt5}");
            var txt6 = "Cartões";
            ValidaDados($"(//*[text()='{txt6}'])[1]", txt6, $"texto Submenu: {txt6}");
            var txt7 = "Seguros";
            ValidaDados($"(//*[text()='{txt7}'])[1]", txt7, $"texto Submenu: {txt7}");
            var txt8 = "INSS";
            ValidaDados($"(//*[text()='{txt8}'])[1]", txt8, $"texto Submenu: {txt8}");
            var txt9 = "Consórcios";
            ValidaDados($"(//*[text()='{txt9}'])[1]", txt9, $"texto Submenu: {txt9}");
            var txt10 = "PIX";
            ValidaDados($"(//*[text()='{txt10}'])[1]", txt10, $"texto Submenu: {txt10}");
        }        
        public void ValidaCampoPesquisa() 
        {            
            ValidaElementoPresente("//*[@class='search-field']", "campo de pesquisa habilitado");
        }        
        public void ValidaBtnSetaEsquerda()
        {
            ValidaElementoPresente("//*[@class='slick-prev slick-arrow']", "botão seta esquerda para visualizar post informativo");
        }
        public void ValidaBtnSetaDireita()
        {
            ValidaElementoPresente("//*[@class='slick-prev slick-arrow']", "botão seta esquerda para visualizar post informativo");
        }
        public void ValidaPostImagem()
        {
            ValidaElementoPresente("//*[@class='slick-list draggable']", "post imagem informativo");
        }
        public void ValidaTxtTitulo1()
        {
            var txt = "Últimas do Blog do Agi";
            ValidaDados($"(//*[text()='{txt}'])[1]", txt, $"texto primeiro Titulo: {txt}");
        }                
        public void ValidaTxtsSubTitulosGrid()
        {
            var txt1 = "Holerite: o que é e qual a importância desse documento";
            ValidaDados($"(//*[text()='{txt1}'])[3]", txt1, $"texto subtitulo: {txt1}");
            var txt2 = CapturaDados("//*[@id='post-4102']/div/div[2]/article[2]/h3/a", GetAttrib.innerText);
            ValidaDados($"//*[@id='post-4102']/div/div[2]/article[2]/h3/a", txt2, $"texto subtitulo: {txt2}");            
            var txt3 = "Saiba qual é o Rendimento da Poupança hoje";
            ValidaDados($"(//*[text()='{txt3}'])[3]", txt3, $"texto subtitulo: {txt3}");
            var txt4 = CapturaDados("//*[@id='post-4102']/div/div[2]/article[4]/h3/a", GetAttrib.innerText);
            ValidaDados($"//*[@id='post-4102']/div/div[2]/article[4]/h3/a", txt4, $"texto subtitulo: {txt4}");
            var txt5 = CapturaDados("//*[@id='post-4102']/div/div[2]/article[5]/h3/a", GetAttrib.innerText);
            ValidaDados($"//*[@id='post-4102']/div/div[2]/article[5]/h3/a", txt5, $"texto subtitulo: {txt5}");
            var txt6 = "Conheça os 7 golpes financeiros mais comuns no Brasil";
            ValidaDados($"(//*[text()='{txt6}'])[4]", txt6, $"texto subtitulo: {txt6}");
        }
        public void ValidaPaginacao()
        {
            ValidaElementoPresente("//*[@class='uagb-post-pagination-wrap']", "paginação");
        }
        public void ValidaTxtTitulo2()
        {
            var txt = "Tudo Sobre Empréstimo";
            ValidaDados($"(//*[text()='{txt}'])[1]", txt, $"texto segundo Titulo: {txt}");
        }
        public void ValidaTxtsPostImagem()
        {
            var txt1 = CapturaDados("//*[@id='post-4102']/div/div[5]/article[1]/h3/a", GetAttrib.innerText);
            ValidaDados($"//*[@id='post-4102']/div/div[5]/article[1]/h3/a", txt1, $"texto do post imagem: {txt1}");
            var txt2 = CapturaDados("//*[@id='post-4102']/div/div[5]/article[2]/h3/a", GetAttrib.innerText);
            ValidaDados($"//*[@id='post-4102']/div/div[5]/article[2]/h3/a", txt2, $"texto do post imagem: {txt2}");
            var txt3 = CapturaDados("//*[@id='post-4102']/div/div[5]/article[3]/h3/a", GetAttrib.innerText);
            ValidaDados($"//*[@id='post-4102']/div/div[5]/article[3]/h3/a", txt3, $"texto do post imagem: {txt3}");
        }          
    }
}
