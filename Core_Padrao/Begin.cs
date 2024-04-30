#region Bibliotecas
global using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
#endregion

namespace AutomationWebCS.Agibank.Core_Padrao
{
    public class Begin : DSL
    {
        #region Abre navegador
        public void AbreNavegador()
        {
            var headless = new ChromeOptions();
            headless.AddArgument("disable-cache");
            headless.AddArgument("window-size=1920x1080");
            headless.AddUserProfilePreference("download.default_directory", downloadsPath);
            headless.AddArgument("headless");

            var devMode = new ChromeOptions();
            devMode.AddArgument("disable-cache");
            devMode.AddArgument("start-maximized");

            if (headlessMode) driver = new ChromeDriver(WebDriver, headless);
            else driver = new ChromeDriver(WebDriver, devMode);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        #endregion

        #region Fecha navegador
        public void FechaNavegador()
        {
            if (driverQuit) driver.Quit();
            else foreach (var process in Process.GetProcessesByName("chromedriver")) process.Kill();
        }
        #endregion

        #region Define ambiente de acesso ao sistema
        public void Login()
        {
            try { AbreNavegador(); driver.Navigate().GoToUrl(urlAgibank); }
            catch { new DriverManager().SetUpDriver(new ChromeConfig()); }
        }
        #endregion

        #region SetUp
        [SetUp]
        public void Start() => Login();
        #endregion

        #region TearDown
        [TearDown]
        public void EndOfTest()
        {
            SaveLog(); FechaNavegador();
        }
        #endregion
    }
}
