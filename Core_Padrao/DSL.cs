#region Bibliotecas
using ClosedXML.Excel;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using System.Text;
#endregion

namespace AutomationWebCS.Agibank.Core_Padrao
{
    public class DSL : LogSystem
    {
        #region Funções de manipulação

        public static void Wait(int ms) => Thread.Sleep(ms);
        public void ClickOut() => ClicaElemento("//html");
        public void AbreNovaGuia(int tab, [Optional] string url)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript(string.Format("window.open('', '_blank');")); MudaGuia(tab);
            if (!string.IsNullOrEmpty(url)) driver.Navigate().GoToUrl(url);
        }
        public void MudaGuia(int tab) => driver.SwitchTo().Window(driver.WindowHandles[tab]);
        public void RefreshPage() => driver.Navigate().Refresh();
        public void LimpaDados(string xpath)
        {
            var element = driver.FindElement(By.XPath(xpath)); element.Clear();
            Actions act = new(driver); act.DoubleClick(element).Perform(); element.SendKeys(Keys.Delete);
            element.SendKeys(Keys.Control + "a"); element.SendKeys(Keys.Delete);
            var text = CapturaDados(xpath, GetAttrib.text);
            ClicaElemento(xpath, null, 100); element.SendKeys(Keys.End);
            for (int i = 0; i < text.Length; i++) element.SendKeys(Keys.Backspace);
        }    
        public void EsperaElemento(string xpath, int seconds = 120)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
            wait.Until((d) => d.FindElement(By.XPath(xpath)));
        }
        public void EsperaElementoSumir(string xpath, int seconds = 120)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElements(By.XPath(xpath)).Count == 0);
        }
        public void AguardaLoading()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(60));
            wait.Until(d => d.FindElements(By.XPath(aguardaLoading)).Count == 0);
        }
        public bool ValidaElementoExistente(string xpath)
        {
            try { driver.FindElement(By.XPath(xpath)); return true; }
            catch (NoSuchElementException) { return false; }
        }
        #endregion

        #region Funções de interação
        public void EscreveTexto(string xpath, string value, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(value);
                if (description != null) Log($"Preencheu {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao preencher {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ClicaElemento(string xpath, [Optional] string description, int ms = 1000)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click(); Wait(ms);
                if (description != null) Log($"Clicou em {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao clicar em {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void MenuDropDown(string xpath, string value, [Optional] string description, bool absolutValue = true)
        {
            try
            {
                string xpathValue = string.Empty;
                if (absolutValue) xpathValue = $"//*[text()='{value}']";
                else xpathValue = $"//*[contains(text(),'{value}')]";
                driver.FindElement(By.XPath(xpath)).Click(); EsperaElemento(xpathValue, 10);
                driver.FindElement(By.XPath(xpathValue)).Click();
                if (description != null) Log($"Selecionou menu Dropdown {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao selecionar menu Dropdown {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void MenuDropDownByXpath(string xpath, string valueXpath, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).Click(); EsperaElemento(valueXpath, 10);
                driver.FindElement(By.XPath(valueXpath)).Click();
                if (description != null) Log($"Selecionou menu Dropdown {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao selecionar menu Dropdown {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaDados(string xpath, string value, [Optional] string description)
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath(xpath)).Text, Does.Contain(value));
                if (description != null) Log($"Validou {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao validar {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaDados(string xpath, string value, GetAttrib ga, [Optional] string description)
        {
            try
            {
                if (ga == GetAttrib.text)
                    Assert.That(driver.FindElement(By.XPath(xpath)).Text, Does.Contain(value));
                if (ga == GetAttrib.value)
                    Assert.That(driver.FindElement(By.XPath(xpath)).GetAttribute("value"), Does.Contain(value));
                if (description != null) Log($"Validou {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao validar {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaValorVariavelParcial(string variable, string value, [Optional] string description)
        {
            try
            {
                Assert.That(variable, Does.Contain(value));
                if (description != null) Log($"Validou {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao validar {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaValorVariavelAbsoluto(string var_x, string var_y, [Optional] string description)
        {
            try
            {
                Assert.That(var_x, Does.Match(var_y));
                if (description != null) Log($"Validou {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao validar {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaElementoAusente(string xpath, [Optional] string description)
        {
            var elementDisplayed = driver.FindElements(By.XPath(xpath));
            if (elementDisplayed.Count == 0)
            {
                if (description != null) Log($"Elemento {description} <b>não</b> está presente. Ok!");
            }
            else
            {
                testPassed = false; var msgErr = $"Elemento {description} está presente. Falhou!";
                if (description != null) Log(msgErr); Assert.Fail(msgErr);
            }
        }
        public void ValidaElementoPresente(string xpath, [Optional] string description)
        {
            var elementDisplayed = driver.FindElements(By.XPath(xpath));
            if (elementDisplayed.Count != 0)
            {
                if (description != null) Log($"Elemento {description} está presente.");
            }
            else
            {
                testPassed = false; var msgErr = $"Elemento {description} <b>não</b> está presente.";
                if (description != null) Log(msgErr); Assert.Fail(msgErr);
            }
        }       
        public void ValidaElementoDesabilitado(string xpath, [Optional] string description)
        {
            var elementEnabled = driver.FindElement(By.XPath(xpath)).GetAttribute("disabled");
            if (elementEnabled == "true")
            {
                if (description != null) Log($"Elemento {description} está desabilitado. Ok!");
            }
            else
            {
                testPassed = false; var msgErr = $"Elemento {description} está habilitado. Falhou!";
                if (description != null) Log(msgErr); Assert.Fail(msgErr);
            }
        }
        public void ValidaElementoDesabilitadoSemAtributo(string xpath, [Optional] string description)
        {
            var elementEnabled = driver.FindElement(By.XPath(xpath)).GetAttribute("disabled");
            if (elementEnabled != "")
            {
                if (description != null) Log($"Elemento {description} está desabilitado. Ok!");
            }
            else
            {
                testPassed = false; var msgErr = $"Elemento {description} está habilitado. Falhou!";
                if (description != null) Log(msgErr); Assert.Fail(msgErr);
            }
        }
        public void ValidaMaxLengthCampo(string xpath, string capturedValue, [Optional] string description)
        {
            try
            {
                string maxLength = CapturaDados(xpath, GetAttrib.maxlength);
                Assert.That(maxLength, Does.Match(capturedValue));
                Log($"Validou max length de {capturedValue} caracteres {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao validar max length de {capturedValue} caracteres {description}";
                Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void UploadArquivo(string input, string path, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(input)).SendKeys(path);
                if (description != null) Log($"Selecionou o arquivo {description} para upload com sucesso!");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao selecionar o arquivo {description} para upload";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaDownload([Optional] string downloadedFileName, [Optional] string description, bool deleteFile = true, int time = 90)
        {
            if (!cicdMode)
            {
                try
                {
                    string fullPathFile;
                    if (string.IsNullOrEmpty(downloadedFileName))
                    {
                        var path = new DirectoryInfo(downloadsPath);
                        var files = path.GetFiles();
                        var orderedFiles = files.OrderBy(x => x.CreationTime);
                        var lastFile = orderedFiles.Last();
                        var lastFileName = lastFile.Name;
                        fullPathFile = path + lastFileName;
                        Log($"<i>Nome do arquivo não foi informado! Arquivo capturado no diretório: <b>{lastFileName}</b></i>");
                    }
                    else
                    {
                        fullPathFile = downloadsPath + downloadedFileName;
                    }

                    bool fileExists = false;
                    WebDriverWait wait = new(driver, TimeSpan.FromSeconds(30));
                    wait.Until(x => fileExists = File.Exists(fullPathFile));

                    var length = new FileInfo(fullPathFile).Length;
                    for (var i = 0; i < time; i++)
                    {
                        Wait(1000);
                        var newLength = new FileInfo(fullPathFile).Length;
                        if (newLength == length && length != 0) break;
                        length = newLength;
                    }
                    if (deleteFile) File.Delete(fullPathFile);
                    if (description != null) Log($"Download do arquivo {description} concluído com sucesso!");
                }
                catch (Exception ex)
                {
                    testPassed = false; var msgErr = $"Erro ao fazer o download do arquivo {description}";
                    if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
                }
            }
        }
        public void EsperaElementoSerClicavel(string xpath, [Optional] string description)
        {
            try
            {
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(30));
                var elementClick = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                elementClick.Click(); if (description != null) Log($"Clicou em {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao clicar em {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaCondicaoVerdadeira(bool boolean, [Optional] string description)
        {
            try
            {
                Assert.That(boolean);
                if (description != null) Log($"Validou {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao validar {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        public void ValidaCheckboxSelecionado(string xpath, [Optional] string description)
        {
            var checkbox = driver.FindElement(By.XPath(xpath));
            if (checkbox.Selected == true)
            {
                if (description != null) Log($"Checkbox {description} está Selecionado. Ok!");
            }
            else
            {
                testPassed = false; var msgErr = $"Checkbox {description} não está selecionado. Falhou!";
                if (description != null) Log(msgErr); Assert.Fail(msgErr);
            }
        }
        public void ValidaCheckboxDesmarcado(string xpath, [Optional] string description)
        {
            var checkbox = driver.FindElement(By.XPath(xpath));
            if (checkbox.Selected == false)
            {
                if (description != null) Log($"Checkbox {description} está Desmarcado. Ok!");
            }
            else
            {
                testPassed = false; var msgErr = $"Checkbox {description} não está desmarcado. Falhou!";
                if (description != null) Log(msgErr); Assert.Fail(msgErr);
            }
        }
        public void ValidaElementoNumerico(string xpath, GetAttrib ga)
        {
            var value = string.Empty;
            if (ga == GetAttrib.text)
                value = driver.FindElement(By.XPath(xpath)).Text.Trim();
            if (ga == GetAttrib.value)
                value = driver.FindElement(By.XPath(xpath)).GetAttribute("value");
            bool result = int.TryParse(value, out _);
            try
            {
                Assert.That(result); Log($"Elemento {value} é numérico. Ok!");
            }
            catch
            {
                testPassed = false; var msgErr = $"Elemento {value} não é numérico. Falhou!";
                Log(msgErr); Assert.Fail(msgErr);
            }
        }
        #endregion

        #region Funções de atribuição
        public string CapturaDados(string xpath, GetAttrib ga)
        {
            string value = string.Empty;
            if (ga == GetAttrib.blockedValue)
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                value = $"return document.evaluate(\"{xpath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.value || document.evaluate(\"{xpath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;";
                return (string)jsExecutor.ExecuteScript(value);
            }
            if (ga == GetAttrib.innerText)
                value = driver.FindElement(By.XPath(xpath)).GetAttribute("innerText").Trim();
            if (ga == GetAttrib.value)
                value = driver.FindElement(By.XPath(xpath)).GetAttribute("value");
            if (ga == GetAttrib.mask)
                value = driver.FindElement(By.XPath(xpath)).GetAttribute("mask");
            if (ga == GetAttrib.maxlength)
                value = driver.FindElement(By.XPath(xpath)).GetAttribute("maxlength");
            return value;
        }
        public string CapturaTextoClipboard(string xpath)
        {
            var text = driver.FindElement(By.XPath(xpath)).GetAttribute("value");

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("navigator.clipboard.writeText(arguments[0]);", text);

            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(3));
            wait.Until(driver => (bool)jsExecutor.ExecuteScript("return document.hasFocus();"));

            var clipboardText = jsExecutor.ExecuteScript("return navigator.clipboard.readText();").ToString();
            return clipboardText;
        }
        public static string GeraStringPorTamanho(int times, string value)
        {
            string s = string.Empty;
            for (int i = 0; i < times; i++)
                s = string.Concat(s, value);
            return s;
        }
        public static string GeraStringAlfanumericoAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rnd = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                .Select(s => s[rnd.Next(s.Length)]).ToArray()); Wait(500);
            return result;
        }
        public static string GeraStringNumericaAleatoria(int tamanho)
        {
            var chars = "123456789";
            var rnd = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                .Select(s => s[rnd.Next(s.Length)]).ToArray()); Wait(500);
            return result;
        }
        public string PegaUrlAtual()
        {
            var urlAtual = driver.Url;
            return urlAtual.ToString();
        }
        public string PegaTituloPagina()
        {
            var title = driver.Title;
            return title.ToString();
        }
        public static string GeraNomeAleatorio()
        {
            var db = new DataBase(); var rnd = new Random();
            string[] nome = db.nomes.Split();
            string[] sobrenome = db.sobrenomes.Split();
            string nomeCompleto = $"{nome[rnd.Next(nome.Length)]} {sobrenome[rnd.Next(sobrenome.Length)]}";
            return nomeCompleto;
        }
        public static string GeraEmailAleatorio()
        {
            var db = new DataBase(); var rnd = new Random();
            int num = rnd.Next(1, 9999);
            string[] nome = db.nomes.Split();
            string[] sobrenome = db.sobrenomes.Split();
            string[] dominio = db.dominios.Split();
            string email = $"{nome[rnd.Next(nome.Length)]}{sobrenome[rnd.Next(sobrenome.Length)]}" + 
                $"{num}{dominio[rnd.Next(dominio.Length)]}"; return email.ToLower();
        }
        public static string GeraDataNascimento()
        {
            var rnd = new Random();
            int dia = rnd.Next(1, 28);
            int mes = rnd.Next(1, 12);
            int ano = rnd.Next(1950, 2000);
            string data = dia.ToString().PadLeft(2, '0')
                + mes.ToString().PadLeft(2, '0')
                + ano; return data;
        }
        public static string GeraTelefoneFixo()
        {
            var rnd = new Random();
            string digit = string.Empty;
            for (int i = 0; i < 10; i++)
                digit = string.Concat(digit, rnd.Next(10));
            return digit;
        }
        public static string GeraCelular()
        {
            var rnd = new Random();
            string digit = string.Empty;
            for (int i = 0; i < 11; i++)
                digit = string.Concat(digit, rnd.Next(10));
            return digit;
        }
        public static string GeraCEP()
        {
            var db = new DataBase(); var rnd = new Random();
            string[] cep = db.cep.Split();
            string cepString = cep[rnd.Next(cep.Length)];
            return cepString;
        }
        public static string GeraCPF()
        {
            int soma = 0, resto; string cpf = string.Empty;
            Random rnd = new();
            for (int i = 0; i < 9; i++) cpf += rnd.Next(0, 9);
            for (int i = 0; i < 9; i++) soma += int.Parse(cpf[i].ToString()) * (10 - i);
            resto = soma % 11;
            if (resto < 2) cpf += "0"; else cpf += (11 - resto);
            soma = 0;
            for (int i = 0; i < 10; i++) soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            if (resto < 2) cpf += "0"; else cpf += 11 - resto;
            return cpf;
        }
        public static string GeraCNPJ()
        {
            int[] times1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] times2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            var rnd = new Random();
            string cnpj = rnd.Next(10000000, 99999999).ToString() + "0001";
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * times1[i];
            int div = soma % 11;
            if (div < 2) div = 0; else div = 11 - div;
            cnpj += div; soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpj[i].ToString()) * times2[i];
            div = soma % 11;
            if (div < 2) div = 0; else div = 11 - div;
            return cnpj + div.ToString();
        }
        public string PdfReader(string fileName, bool deleteFile = true)
        {
            string dataResult = string.Empty;
            var pdfFile = downloadsPath + fileName;
            var pdfReader = new PdfReader(pdfFile);
            var pdfDoc = new PdfDocument(pdfReader);
            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                ITextExtractionStrategy data = new SimpleTextExtractionStrategy();
                dataResult += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), data);
            }
            pdfDoc.Close(); Wait(500);
            if (deleteFile) File.Delete(pdfFile);
            return dataResult;
        }
        public string ExcelReader(string excelFileName, bool deleteFile = true)
        {
            string resultData = string.Empty;
            var fullPathFile = downloadsPath + excelFileName;
            var wbook = new XLWorkbook(fullPathFile);
            var ws = wbook.Worksheets.First();
            var range = ws.RangeUsed();
            for (int i = 1; i < range.RowCount() + 1; i++)
            {
                for (int j = 1; j < range.ColumnCount() + 1; j++)
                {
                    resultData += ws.Cell(i, j).GetValue<string>() + " ";
                }
            }
            if (deleteFile) File.Delete(fullPathFile);
            return resultData;
        }
        public string TextReader(string fileName, [Optional] string charset, bool deleteFile = true)
        {
            var txtFile = downloadsPath + fileName; string resultData;
            if (charset != null) resultData = File.ReadAllText(txtFile, Encoding.Unicode);
            else resultData = File.ReadAllText(txtFile, Encoding.Default);
            if (deleteFile) File.Delete(txtFile);
            return resultData;
        }       
        #endregion

        #region Funções de simulação de teclas
        public void Tab(int timer = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Tab).Perform(); Wait(timer);
        }
        public void Enter(int timer = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Enter).Perform(); Wait(timer);
        }
        public void Delete(int timer = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Delete).Perform(); Wait(timer);
        }
        public void PageDown(int timer = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.PageDown).Perform(); Wait(timer);
        }
        public void PageUp(int timer = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.PageUp).Perform(); Wait(timer);
        }
        public void Backspace(int timer = 100)
        {
            Actions act = new(driver);
            act.SendKeys(Keys.Backspace).Perform(); Wait(timer);
        }
        #endregion

        #region Função Mouse Hover
        public void MoveToElemento(string xpath, [Optional] string description, int timer = 100)
        {
            try
            {
                Actions act = new(driver);
                act.MoveToElement(driver.FindElement(By.XPath(xpath))).Build().Perform();
                Wait(timer);
                if (description != null) Log($"Moveu para: {description}");
            }
            catch (Exception ex)
            {
                testPassed = false; var msgErr = $"Erro ao mover para {description}";
                if (description != null) Log($"{msgErr} {sysMsgErr} {ex.Message}"); Assert.Fail(msgErr);
            }
        }
        #endregion
    }
}
