using System.Text;

namespace AutomationWebCS.Agibank.Core_Padrao
{
    public class LogSystem : GlobalVariables
    {
        #region Variables
        string fileName, filePath, logResult;
        public StringBuilder log = new();
        public string testOk = "<p><b>=============<br>FIM DO TESTE – OK!";
        public string testNok = "</i><p><font color = black><b>==============<br>FIM DO TESTE – <font color = red>NOK!<p align=center>";
        public string sysMsgErr = "</b><p><font color = black><b>System Message Error: </b><i>";
        #endregion

        #region Log Funcion
        public void Log(string text)
        {
            if (testPassed) log.Append($"{text}<br>");
            else log.Append($"<font color = red><b>{text}");
        }
        #endregion

        #region SaveLog
        public void SaveLog()
        {
            if (cicdMode)
            {
                filePath = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName}";
            }
            else
            {
                string folderDate = DateTime.Now.ToString("yyyy-MM-dd");
                filePath = $@"C:\Users\Eros\source\repos\TestProjectAutomationWebCS\Logs\{folderDate}\";
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            }
            if (logFileName != null) fileName = logFileName;
            else fileName = GetType().Name;
            string file = $"{filePath}{fileName}.html";
            string htmlStart = "<html><body><p><font face = Verdana size = 2>";
            string htmlEnd = "</p></font></body></html>";
            string header = "<b>ACESSO AO SISTEMA<br>==============</b><br>" + "Abriu o navegador e acessou a <b>BlogAgibank</b><p>";
            Screenshot imgCaptured = ((ITakesScreenshot)driver).GetScreenshot();
            string image = $"<img src='data:/image/png;base64, {imgCaptured} 'width='972' height='435'/>";
            StreamWriter sw = new(file);
            if (!testPassed) logResult = $"{htmlStart}{header}{log}{testNok}{image}{htmlEnd}";
            else logResult = $"{htmlStart}{header}{log}{testOk}{htmlEnd}";
            sw.Write(logResult); sw.Close(); testPassed = true;
            if (cicdMode) TestContext.AddTestAttachment(file);
        }
        #endregion
    }
}
