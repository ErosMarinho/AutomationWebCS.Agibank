namespace AutomationWebCS.Agibank.Core_Padrao
{
    public class GlobalVariables : XPathVariables
    {
        #region Global Variables

        // Define 'driver' como trigger para os WebElements
        public IWebDriver driver;

        // Define 'Fechar navegador ao final do teste' como padrão
        public bool driverQuit = false;

        // Habilita | Desabilita modo Headless
        public bool headlessMode = false;

        // Executa | Não executa parâmetros específicos para execução em CI/CD
        public bool cicdMode = false;

        // Define 'true' como padrão para o fluxo dos testes
        public bool testPassed = true;

        // Determina nome de arquivo log diferente do nome da classe
        public string logFileName = null;

        // Define 'dataStart' como hora atual
        public DateTime dataStart = DateTime.Now;

        // Define lista de atributos de elementos web
        public enum GetAttrib
        {
            text,
            innerText,
            value,
            mask,
            maxlength,
            blockedValue
        }
        public string urlAgibank = "https://blogdoagi.com.br/";

        #endregion

        #region Paths

        // Define path padrão para download dos arquivos
        public string downloadsPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads\";
        public string WebDriver = @"C:\Users\Eros\source\repos";

        #endregion
    }
}
