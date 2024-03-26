using EasyAutomationFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacoesProjetos.ConversorMoedas
{
    public class BuscarMoedasMundo : WebPersonalizado
    {
        public BuscarMoedasMundo()
        {
            StartBrowser();
        }

        public List<string> BuscarMoedas()
        {
            Navigate("https://www.dadosmundiais.com/moedas/");


            WaitForElement(TypeElement.CssSelector, "#main > div:nth-child(4) > div.tablescroller > table");
            var resul = GetTableData(TypeElement.CssSelector, "#main > div:nth-child(4) > div.tablescroller > table");

            List<MoedaModel> moedas = new List<MoedaModel>();

            List<Pais> paises = new List<Pais>();

            List<string> resultado = new List<string>();

            int id = 1;
            AbrirConfigurarPaginaConversao();
            foreach (DataRow row in resul.table.Rows)
            {
                if (id < 6)
                {

                    MoedaModel moeda = new MoedaModel();
                    moeda.Id = id;
                    moeda.ISO = row[0].ToString();

                    string[] parts = row[1].ToString().Split(new string[] { "1" }, StringSplitOptions.None);
                    moeda.Nome = parts[0];
                    moeda.Descricao = parts.Length > 1 ? parts[1] : parts[0];

                    moeda.Distribuicao = row[2].ToString();

                    var paisesRetornados = moeda.Distribuicao.Split(new string[] { "," }, StringSplitOptions.None);

                    moeda.ValorEmRelacaoAoReal = RetornarValorEmRelacaoAoReal(moeda.ISO);
                    foreach (var item in paisesRetornados)
                    {
                        paises.Add(new Pais { Id = paises.Count() + 1, IdMoeda = id, Name = item });
                    }
                    moedas.Add(moeda);
                    resultado.Add($"Nome da moeda {moeda.Nome} - {moeda.ISO} valor:{moeda.ValorEmRelacaoAoReal}");
                    id++;
                }
            }
            CloseBrowser();
            return resultado;
        }
        public void AbrirConfigurarPaginaConversao()
        {
            Navigate($"https://www.bcb.gov.br/conversao");

            AssignValue(TypeElement.Name, "valorBRL", "100");

            Click(TypeElement.Id, "button-converter-de");

            WaitForElement(TypeElement.Id, "moedaBRL");

            GetListData(TypeElement.Id, "moedaBRL", "BRL");
        }

        public string RetornarValorEmRelacaoAoReal(string iso)
        {

            Click(TypeElement.Id, "button-converter-para");

            WaitForElement(TypeElement.Id, "moedaResultado1");

            GetListData(TypeElement.Id, "moedaResultado1", iso);


            Click(TypeElement.Xpath, "/html/body/app-root/app-root/div/div/main/dynamic-comp/div/div[1]/bcb-detalhesconversor/div/div[1]/form/div[2]/div[5]/div/button");

            WaitForElement(TypeElement.Xpath, "/html/body/app-root/app-root/div/div/main/dynamic-comp/div/div[1]/bcb-detalhesconversor/div/div[2]/div/div[1]/div[2]/div");

            Thread.Sleep(TimeSpan.FromSeconds(1));
            var retorno = GetValue(TypeElement.Xpath, "/html/body/app-root/app-root/div/div/main/dynamic-comp/div/div[1]/bcb-detalhesconversor/div/div[2]/div/div[1]/div[2]/div");

            string[] parts = retorno.Value.Split(new string[] { ":" }, StringSplitOptions.None);

            return parts[2];

        }
    }

}
