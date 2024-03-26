using EasyAutomationFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacoesProjetos.Tradutor
{
    public class Traduzir : WebPersonalizado
    {

        public Traduzir()
        {
            StartBrowser();
        }

        public List<string> PegarListaIdiomas()
        {
            string teste = "Olá Mundo";
            Navigate("https://www.reverso.net/tradu%C3%A7%C3%A3o-texto");


            Click(TypeElement.Xpath, "/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[1]/app-language-switch/div/app-language-select[1]/div");
            //  Thread.Sleep(4000);
            var listaIdiomas = PutLangToTranslate(TypeElement.Xpath, "/html/body/div[2]/app-language-select-options/div/ul", "Português").table;
         
            AssignValue(TypeElement.Xpath, "/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[2]/div[1]/div[1]/div/div[1]/textarea", teste);
          
            Click(TypeElement.Xpath, "/html/body/app-root/app-translation/div/app-translation-box/div[1]/div[1]/div[1]/app-language-switch/div/app-language-select[2]/div/div/div");

            var resultado = TranslateAll(TypeElement.Xpath, "/html/body/div[3]/app-language-select-options/div/ul", teste);

            CloseBrowser();

            return ConvertDataTableToList(resultado.table);
        }

        static List<string> ConvertDataTableToList(DataTable table)
        {
            List<string> list = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                string value = row["StringColumn"].ToString(); // Change "StringColumn" to the actual column name
                list.Add(value);
            }

            return list;
        }
    }
}
