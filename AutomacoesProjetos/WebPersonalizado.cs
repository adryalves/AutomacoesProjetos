using AutomacoesProjetos.ConversorMoedas;
using EasyAutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacoesProjetos
{

    
    public class WebPersonalizado : Web
    {

        public static List<string> ListaIdiomas;

        List<string> resultados = new List<string>();

        // Metodos do projeto tradução:
        public EasyReturn.Web PutLangToTranslate(TypeElement typeElement, string element, string lang, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                IList<IWebElement> linkItems = webElement.FindElements(By.TagName("li"));

                 
                List<string> topics = new List<string>();
                foreach (IWebElement item in linkItems)
                {
                    IWebElement spansInsideLi = item.FindElement(By.ClassName("lang-label"));
                    topics.Add(spansInsideLi.Text);
                    ListaIdiomas.Add(spansInsideLi.Text);

                    if (spansInsideLi.Text == lang)
                    {
                        item.Click();
                        Thread.Sleep(2000);
                        break;
                    }

                }

                DataTable dataTable = new DataTable();


                dataTable.Columns.Add("StringColumn", typeof(string)); // Change "StringColumn" to your desired column name

                // Add rows from List<string> to DataTable
                foreach (string str in topics)
                {
                    dataTable.Rows.Add(str);
                }
                //var teste = dataTable.Rows;
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true,
                    table = dataTable
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }

        public EasyReturn.Web TranslateAll(TypeElement typeElement, string element, string textoOriginal, int timeout = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                IList<IWebElement> linkItems = webElement.FindElements(By.TagName("li"));
                var i = 0;

                List<string> topics = new List<string>();

                foreach (IWebElement item in linkItems.Take(5))
                {
                    //WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                   // IWebElement spansInsideLi = item.FindElement(By.ClassName("lang-label"));
                   // topics.Add(spansInsideLi.Text);
                    ClicarBotao(element, i, timeout);
                    //PreencherLista(textoOriginal, topics[i]);
                    i++;
                }

                

                

               
               // dataTable.Columns.Add("StringColumn", typeof(string)); // Change "StringColumn" to your desired column name

                // Add rows from List<string> to DataTable
                //foreach (string str in resultados)
                //{
                //    dataTable.Rows.Add(str);
                //}
                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true,
                    table = null
                };
            }

            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }

        }

        public void ClicarBotao(string element, int i, int timeout)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IWebElement webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
            IList<IWebElement> link = webElement.FindElements(By.TagName("li"));
            link[i].Click();
            Thread.Sleep(4000);
            Click(TypeElement.Xpath, "/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[1]/app-language-switch/div/app-language-select[2]/div/div/div");

        }

        public void PreencherLista(string textoOriginal, string idioma, int timeout = 3)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IWebElement webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[2]/div[2]/div/app-context-box/div/div/app-context-item[1]/div/div[1]/div/div/span[1]")));
            // IWebElement element = driver.FindElement(By.XPath("/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[2]/div[2]/div/app-context-box/div/div/app-context-item[1]/div/div[1]/div/div/span[1]"));
            string textoTraduzido = webElement.Text;
           // resultados.Add(textoOriginal + " em " + idioma + " é: " + textoTraduzido);
        }

        // Metodos do projeto temperatura:
        public EasyReturn.Web SelecionaItem(TypeElement typeElement, string element, string cidade, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                IList<IWebElement> linkItems = webElement.FindElements(By.TagName("li"));
                string tempMinima = "0";
                string tempMaxima = "0";



                foreach (IWebElement item in linkItems)
                {


                    IWebElement spansInsideLi = item.FindElement(By.TagName("div"));


                    if (spansInsideLi.Text.Contains(cidade))
                    {
                        item.Click();
                        tempMinima = GetValue(TypeElement.Xpath, "/html/body/div[3]/div[3]/div[2]/div/div[2]/div/div/div/div[2]/div[1]/div[2]/div[2]/div[1]/b").Value.ToString();
                        tempMaxima = GetValue(TypeElement.Xpath, "/html/body/div[3]/div[3]/div[2]/div/div[2]/div/div/div/div[2]/div[1]/div[2]/div[3]/div[1]/b").Value.ToString();
                        Console.WriteLine("A temperatura mínima da cidade " + cidade + " é: " + tempMinima);
                        Console.WriteLine("A temperatura máxima da cidade " + cidade + " é: " + tempMaxima);
                        Thread.Sleep(2000);

                    }

                }



                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true,
                    table = null
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }
        // Metodos do projeto conversao moedas:
        public EasyReturn.Web GetListData(TypeElement typeElement, string element, string iso, int timeout = 3)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                IWebElement webElement = null;
                switch (typeElement)
                {
                    case TypeElement.Id:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(element)));
                        break;
                    case TypeElement.Name:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(element)));
                        break;
                    case TypeElement.Xpath:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(element)));
                        break;
                    case TypeElement.CssSelector:
                        webElement = webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                        break;
                }

                IList<IWebElement> linkItems = webElement.FindElements(By.TagName("a"));
                List<string> topics = new List<string>();
                foreach (IWebElement item in linkItems)
                {
                    if (item.Text.Contains(iso))
                    {
                        item.Click();
                        break;
                    }
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    element = webElement,
                    Sucesso = true,
                    table = null
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = "Element " + element + " not found. More info: " + ex.Message
                };
            }
        }


    }


}

