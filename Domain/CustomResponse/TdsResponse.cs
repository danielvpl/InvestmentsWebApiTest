using System;
using System.Collections.Generic;

namespace Domain.CustomResponse
{
    public class TdsResponse
    {
        public List<TdsResponse> tds = new List<TdsResponse>();
        public double ValorInvestido { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataDeCompra { get; set; }
        public double Iof { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
    }
}
