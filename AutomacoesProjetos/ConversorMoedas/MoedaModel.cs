using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacoesProjetos.ConversorMoedas
{
    public class MoedaModel
    {
        public int Id { get; set; }
        public string ISO { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string Distribuicao { get; set; }
        public string ValorEmRelacaoAoReal { get; set; }
    }
}
