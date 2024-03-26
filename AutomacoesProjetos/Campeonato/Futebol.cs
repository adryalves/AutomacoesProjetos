using EasyAutomationFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacoesProjetos.Campeonato
{
    public class Futebol : WebPersonalizado
    {

        public Futebol()
        {
            StartBrowser();
        }
        public void SearchFootball()
        {
            Navigate("https://www.cbf.com.br/");

            Click(TypeElement.Xpath, "/html/body/div[1]/header/div/nav/ul/li[3]/a");

            Thread.Sleep(2000);

            Click(TypeElement.Xpath, "/html/body/div[1]/main/section[1]/a/i");

            var response = GetTableData(TypeElement.Xpath, "/html/body/div[1]/main/section[1]/div/div/div[1]/table");

            foreach (DataRow item in response.table.Rows)
            {
                Console.WriteLine($"Time: {item[0]} | Pontos: {item[1]}");
            }
        }
    }
}
