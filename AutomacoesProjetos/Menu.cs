using AutomacoesProjetos.Campeonato;
using AutomacoesProjetos.ConversorMoedas;
using AutomacoesProjetos.Temperatura;
using AutomacoesProjetos.Tradutor;

namespace AutomacoesProjetos
{
    public partial class Menu : Form
    {


        public Menu()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Click(object sender, EventArgs e)
        {

        }

        private void ConverterMoeda(object sender, EventArgs e)
        {

            var moedas = new BuscarMoedasMundo();
            var resultado = moedas.BuscarMoedas();
            setarValorNaTela(resultado);

        }

        private void Tradutor(object sender, EventArgs e)
        {
            var tradutor = new Traduzir();
            var resultado = tradutor.PegarListaIdiomas();
            setarValorNaTela(resultado);
        }

        private void PegarTemperatura(object sender, EventArgs e)
        {
            var temperatura = new Temp();
            temperatura.PegarTemperaturaDasCidades();
        }

        private void PegarCampeonato(object sender, EventArgs e)
        {
            var futebol = new Futebol();
            futebol.SearchFootball();
        }

        private void setarValorNaTela(List<string> resultado)
        {
            lstResultados.ResetText();
            lstResultados.View = View.Details;
            lstResultados.Columns.Add("Resultado: ", -2, HorizontalAlignment.Left);
            foreach (string item in resultado)
            {
                ListViewItem listViewItem = new ListViewItem(item);
                lstResultados.Items.Add(listViewItem);
            }
        }
    }
}
