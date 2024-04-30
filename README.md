O projeto foi implementado no Visual Studio baseado em teste unitário usando "NUnit Test Project".
Usando o Framework .NET 8.0 e o Selenium Webdriver.
Deverá colocar o arquivo do driver na pasta antes da do projeto.
Criar uma pasta Logs junto com a pasta do projeto para ser armazenado as evidências salvas em HTML.
Deverá antes de rodar o projeto baixar o ChromeDriver com a versão do Chrome que esteva usando.
Baixar os seguintes PACKAGES com suas versões pelo gerenciador do NuGet:
ClosedXML(0.102.2)
DotNetSeleniumExtras.WaitHelpers(3.11.0)
itext7(8.0.4)
Microsoft.NET.Test.Sdk(17.9.0)
NUnit(4.0.1)
NUnit3TestAdapter(4.5.0)
Selenium.Support(4.20.0)
Selenium.WebDriver(4.20.0)
WebDriverManager(2.17.2).

Foi criado a pasta CORE_PADRAO, onde fica as classes com seus respectivos comandos:
Begin(Abertura do navegador e sistema)
DataBase(Extras para usar como gerenciador de nomes, sobrenomes, emails, cep)
DLS(As Funções dos metodos)
GlobalVariables(Para apontar as definições, habilitar, executar)
LogSystem(Para evidências caminho da pasta)
PageObjects(Distribuição de metodos para usar em varias classes de testes)
XPathVariables(Atribuir os Xpath)

Criado a pasta MainProject onde fica as classes de PAGE e TEST.
Para executar basta colocar a classe das pastas Test para rodar.
